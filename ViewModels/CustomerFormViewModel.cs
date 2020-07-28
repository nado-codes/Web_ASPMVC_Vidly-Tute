using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ASPTute_Vidly.Models;
using ASPVidly.Models;

namespace ASPTute_Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "You need to enter a name!")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [DisplayName("Membership Type")]
        public byte MembershipTypeId { get; set; }

        [DisplayName("Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }

        public string Title => Id != 0 ? "Edit Customer" : "New Customer";
    }
}