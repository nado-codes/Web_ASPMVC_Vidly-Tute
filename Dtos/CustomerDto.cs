using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ASPTute_Vidly.Models;

namespace ASPTute_Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
    }
}