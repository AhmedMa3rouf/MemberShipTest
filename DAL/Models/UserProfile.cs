using DAL.Core;
using DAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL.Models
{
    public class UserProfile: IAuditableEntity
    {
        [Required]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IDNo { get; set; }
        public Gender Gender { get; set; }
        public string ParentPhone { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
