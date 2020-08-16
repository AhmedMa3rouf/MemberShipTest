using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberShip.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DAL.Core;
using AutoMapper;
using DAL.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using MemberShip.Services;
using System.Net.Http;
using Newtonsoft.Json;

namespace MemberShip.Controllers
{
    public enum PaymentProviders
    {
        TelrPay,
        PayTabs,
        HayperPay
    }
    public class PayTabPageResponse
    {
        public string result { get; set; }
        public string response_code { get; set; }
        public string payment_url { get; set; }
        public string p_id { get; set; }
        public string error_code { get; set; }
    }
    public class AccountController : HelperController
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger<AccountController> _logger;
        readonly SignInManager<ApplicationUser> _signInManager;
        #endregion
        #region Constructor
        public AccountController(IMapper mapper, IAccountManager accountManager, ILogger<AccountController> logger,
            SignInManager<ApplicationUser> loginManager) : base(accountManager,logger)
        {
            _mapper = mapper;
            _accountManager = accountManager;
            //_authorizationService = authorizationService;
            _logger = logger;
            _signInManager = loginManager;
        }
        #endregion

        #region HelperMethod
        
        private void ViewDataReg1()
        {
            //List<Gender> genders = db.C_CountriesLoc.Where(x => x.LanguageId == LangId && x.C_Countries.IsActive == true).ToList();
            //ViewData["Countries"] = new SelectList(countries, "CountryId", "Title", "");

            //List<C_CategoriesLoc> categories = db.C_CategoriesLoc.Include(x => x.C_Categories).Where(x => x.LanguageId == LangId && x.C_Categories.CatVocId == 2 && x.C_Categories.ParentId != null && x.C_Categories.ParentId < 4 && x.C_Categories.IsActive == true).ToList();
            //ViewData["Categories"] = new SelectList(categories, "CatId", "Title", "");

            //ViewBag.LangId = LangId;
        }
        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> CheckEmailExistsAsync(string Email)
        {

            bool UserExists = false;
            try
            {
                var user = await _accountManager.GetUserByEmailAsync(Email);
                return Json(user == null);

            }

            catch (Exception)
            {
                return Json(false);
            }

        }
        #endregion

        #region Action Methods
        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginVM { ReturnUrl = returnUrl };
            return View(model);
            //if (HttpContext.Session["UserDetails"] == null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl = null)
        {
            return await UserLoginAsync(model, returnUrl);
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserEmail,
                   model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    //if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    //{
                    //    return Redirect(model.ReturnUrl);
                    //}
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            AddError("", "Invalid login attempt");
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(RegistrationVM userModel)
        {
            const string userRoleName = "user";
            if (ModelState.IsValid)
            {
                if (userModel == null)
                    return BadRequest($"{nameof(userModel)} cannot be null");


                ApplicationUser appUser = _mapper.Map<ApplicationUser>(userModel);

                appUser.UserName = userModel.Email;
                appUser.UserProfile = new UserProfile
                {
                    FullName = userModel.FullName,
                    IDNo = userModel.IDNo,
                    Gender = userModel.Gender,
                    ParentPhone = userModel.ParentPhone
                };

                string strURL = GetPaymentURL(PaymentProviders.PayTabs, userModel.FullName, userModel.Email);
                //string strURL = GetPaymentURL(PaymentProviders.TelrPay, userModel.FullName, userModel.Email);
                if (strURL != "")
                {
                    return Redirect(strURL);
                    return RedirectToAction("ProcessPayment", new { strRefrence = strURL });
                }
                    //return Redirect(strURL);
                {
                    var result = await _accountManager.CreateUserAsync(appUser, (new string[] { userRoleName }).Distinct(), userModel.Password);
                    if (result.Succeeded)
                    {
                        //string strURL = ProcessPayment(userModel.FullName, userModel.Email);
                        //if (strURL != "")
                        //    return Redirect(strURL);
                        //return Content("<script>window.top.location.href = '" + strURL + "'; </script>");
                        //return RedirectToAction("Index", "Home");
                        //UserViewModel userVM = await GetUserViewModelHelper(appUser.Id);
                        //return CreatedAtAction(GetUserByIdActionName, new { id = userVM.Id }, userVM);
                    }
                    else
                    {
                        AddError(result.Errors);
                        return View(userModel);
                    }
                }
            }

            return BadRequest(ModelState);
            //return View(userModel);
        }
        string GetPaymentURL(PaymentProviders paymentProviders, string strFullName, string strEmail)
        {
            using (var client = new HttpClient())
            {
                string strCartID = $"PL{(new Random()).Next()}{DateTime.Now.ToFileTime()}";
                if (paymentProviders == PaymentProviders.PayTabs)
                {
                    var tmp = new PayTabPageResponse();
                    client.BaseAddress = new Uri("https://www.paytabs.com/apiv2/");
                    client.DefaultRequestHeaders.ExpectContinue = false;

                    var result = client.PostAsync("create_pay_page",
                   new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
                   {
                    new KeyValuePair<string, string>("merchant_email", "maljafen@pl4tech.com"),
                    new KeyValuePair<string, string>("secret_key", "qfGUoC0uMa7Lstz7rlz5n2jwxMI0cffDuWxTyxnlIv7aYGip1SvpUOWrBFsNUIrpEYidwGzebGpanIzpA5OuTLWvqpjl7KLMJ40f"),
                    new KeyValuePair<string, string>("site_url", "https://localhost:44314"),
                    new KeyValuePair<string, string>("return_url", "https://localhost:44314"),
                    new KeyValuePair<string, string>("title", "Bill To Blatinum Package"),
                    new KeyValuePair<string, string>("cc_first_name", strFullName),
                    new KeyValuePair<string, string>("cc_last_name", strFullName),
                    new KeyValuePair<string, string>("cc_phone_number","00966"),
                    new KeyValuePair<string, string>("phone_number","123569854"),
                    new KeyValuePair<string, string>("email", strEmail),
                    new KeyValuePair<string, string>("products_per_title", "Product"),
                    new KeyValuePair<string, string>("unit_price", "100"),
                    new KeyValuePair<string, string>("quantity", "1"),
                    new KeyValuePair<string, string>("other_charges", "0"),
                    new KeyValuePair<string, string>("amount", "100"),
                    new KeyValuePair<string, string>("discount", "0"),
                    new KeyValuePair<string, string>("currency", "SAR"),
                    new KeyValuePair<string, string>("reference_no", strCartID),
                    new KeyValuePair<string, string>("ip_customer", System.Net.Dns.GetHostName()),
                    new KeyValuePair<string, string>("ip_merchant","100.100.100.100"),
                    new KeyValuePair<string, string>("billing_address","billing address"),
                    new KeyValuePair<string, string>("state","state here"),
                    new KeyValuePair<string, string>("city","Cite here"),
                    new KeyValuePair<string, string>("postal_code","25698"),
                    new KeyValuePair<string, string>("country","SAU"),
                    new KeyValuePair<string, string>("shipping_first_name","Shipping First Name"),
                    new KeyValuePair<string, string>("shipping_last_name","Shipping Last Name"),
                    new KeyValuePair<string, string>("address_shipping","address shipping"),
                    new KeyValuePair<string, string>("city_shipping","city shipping"),
                    new KeyValuePair<string, string>("state_shipping","state shipping"),
                    new KeyValuePair<string, string>("postal_code_shipping","postal code shipping"),
                    new KeyValuePair<string, string>("country_shipping","SAU"),
                    new KeyValuePair<string, string>("msg_lang","Arabic"),
                    new KeyValuePair<string, string>("cms_with_version","API")
                   })).Result;
                    if (result.IsSuccessStatusCode)
                    {

                        dynamic data = (result.Content.ReadAsStringAsync().Result);
                        tmp = JsonConvert.DeserializeObject<PayTabPageResponse>(data);

                        if (tmp.payment_url != "")
                        {
                            return tmp.payment_url;
                            //Set Payment Active URL to session
                            //                var activeClient = (Models.Settings)Session["ActiveClient"];
                            var CurrentActivePaymentID = tmp.payment_url;
                            var LastPaymentReferenceNumber = tmp.p_id;
                            //Helper.PayTabsSession.PageRequestList = new List<Models.PayPageRequest>();
                            //objrequest.PaymentReference = tmp.p_id;

                            //var paymentList = new Models.PaymentsList();
                            //paymentList.PayPageRequests = new List<Models.PayPageRequest>();
                            //if (HttpRuntime.Cache["PAYTABS_PAYMENTS"] != null)
                            //{
                            //    paymentList = HttpRuntime.Cache["PAYTABS_PAYMENTS"] as Models.PaymentsList;

                            //    //Remove the Old
                            //    HttpRuntime.Cache.Remove("PAYTABS_PAYMENTS");
                            //}

                            //paymentList.PayPageRequests.Add(objrequest);

                            //HttpRuntime.Cache.Insert("PAYTABS_PAYMENTS", paymentList, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(60));

                            //Helper.PayTabsSession.PageRequestList.Add(objrequest);

                            ////Redirect to Hosted Page
                            //Response.Redirect("~/ClientHost.aspx");
                        }
                    }
                    else
                    {
                        var x = result;
                    }

                }
                if (paymentProviders == PaymentProviders.TelrPay)
                {
                    client.BaseAddress = new Uri("https://secure.telr.com/");
                    client.DefaultRequestHeaders.ExpectContinue = false;

                     var result = client.PostAsync("gateway/order.json",
                    new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
                    {
                    new KeyValuePair<string, string>("ivp_method", "create"),
                    new KeyValuePair<string, string>("ivp_store", "23236"),
                    new KeyValuePair<string, string>("ivp_authkey", "St3GP^Bjx4q~GvtM"),
                    new KeyValuePair<string, string>("ivp_cart", strCartID),
                    new KeyValuePair<string, string>("ivp_desc", "Test Desc"),
                    new KeyValuePair<string, string>("ivp_test", "1"),
                    new KeyValuePair<string, string>("ivp_amount", "5"),
                    new KeyValuePair<string, string>("ivp_currency","SAR"),
                    new KeyValuePair<string, string>("return_auth", "https://localhost:44314"),
                    new KeyValuePair<string, string>("return_can", "https://localhost:44314"),
                    new KeyValuePair<string, string>("return_decl", "https://localhost:44314"),
                    new KeyValuePair<string, string>("bill_title", "MR"),
                    new KeyValuePair<string, string>("bill_fname", strFullName),
                    new KeyValuePair<string, string>("bill_sname", strFullName),
                    new KeyValuePair<string, string>("bill_addr1", "Test"),
                    new KeyValuePair<string, string>("bill_city", "Cairo"),
                    //new KeyValuePair<string, string>("bill_region","Maharashtra"),
                    new KeyValuePair<string, string>("bill_country", "SA"),
                    //new KeyValuePair<string, string>("bill_zip", "400002"),
                    new KeyValuePair<string, string>("bill_email", strEmail),
                    //new KeyValuePair<string,string>("ivp_update_url","www.urdomain.com"),
                    new KeyValuePair<string,string>("ivp_framed","2")
                    })).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        dynamic data = (result.Content.ReadAsStringAsync().Result);
                        data = JsonConvert.DeserializeObject(data).ToString();
                        string[] arrayResponse = data.Split(':');

                        string[] arr = arrayResponse[4].Split('\"');
                        string val = arr[1];

                        // Access variables from the returned JSON object
                        //var appHref = data.links.applications.href;
                        //Session["RefNO"] = val;
                        string IFrameURL = "https://secure.telr.com/gateway/process_framed_full.html?o={val}";
                        string URL = $"https://secure.telr.com/gateway/process.html?o={val}";
                        return val;
                        //Response.Redirect(URL);

                    }
                    else
                    {
                        var x = result;
                    }
                }
                return "";
            }
        }

        public ActionResult ProcessPayment(string strRefrence)
        {
            ViewBag.PaymentURL = strRefrence;
            return View(ViewBag);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        //[Authorize(Roles = "user", AuthenticationSchemes = "UserAuth")]
        public IActionResult UserProfile()
        {
            return View();
        }
        #endregion
    }
}