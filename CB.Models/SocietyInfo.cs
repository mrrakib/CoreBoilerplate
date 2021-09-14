using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("SocietyInfo")]
    public class SocietyInfo
    {
        public int Id { get; set; }
        [StringLength(150, ErrorMessage = "Maximum 150 character allowed.")]
        public string SocietyName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<SocietyMember> SocietyMembers { get; set; }
    }
}
