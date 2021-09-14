using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class SocietyMember
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Maximum 50 character allowed.")]
        public string MemberName { get; set; }
        [StringLength(11, ErrorMessage = "Maximum 11 character allowed.")]
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public int SocityInfoId { get; set; }
        [ForeignKey("SocityInfoId")]
        public virtual SocietyInfo SocietyInfo { get; set; }
    }
}
