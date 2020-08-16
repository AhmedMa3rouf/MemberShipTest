using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberShip.ViewModels
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserProfile, UserProfileVM>();
            CreateMap<UserProfileVM, UserProfile>();

            CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(d => d.UserFrofile, map => map.MapFrom(x => x.UserProfile));

            CreateMap<UserViewModel, ApplicationUser>()
                .ForMember(d => d.Roles, map => map.Ignore())
                .ForMember(d => d.Id, map => map.Condition(src => src.Id != null))
                .ForMember(d => d.UserProfile, map => map.MapFrom(src => src.UserFrofile));

            //CreateMap<ApplicationUser, UserViewModel>();
            //CreateMap<UserViewModel, ApplicationUser>()
            //    .ForMember(d => d.Roles, map => map.Ignore())
            //    .ForMember(d => d.Id, map => map.Condition(src => src.Id != null));

            CreateMap<ApplicationUser, UserEditViewModel>();
            CreateMap<UserEditViewModel, ApplicationUser>()
                .ForMember(d => d.Roles, map => map.Ignore())
                .ForMember(d => d.Id, map => map.Condition(src => src.Id != null));

            CreateMap<ApplicationUser, RegistrationVM>();
            //.ForMember(d => d.Roles, map => map.Ignore());
            CreateMap<RegistrationVM, ApplicationUser>()
                .ForMember(d => d.UserName, map => map.MapFrom(x => x.Email))
                .ForMember(d => d.Roles, map => map.Ignore())
                .ForMember(d => d.Id, map => map.Condition(src => src.Id != null));

        }
    }
}
