// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Core
{
    public enum Gender
    {
        //[Display(Name = "Prefered To Not Say")]
        //None,

        [Display(Name = "أنذى")]
        Female,

        [Display(Name = "ذكر")]
        Male
    }
}
