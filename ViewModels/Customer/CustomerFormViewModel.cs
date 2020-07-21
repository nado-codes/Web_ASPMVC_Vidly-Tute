using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPTute_Vidly.Models;
using ASPVidly.Models;

namespace ASPTute_Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public CustomerFormViewModel()
        {
            Customer = new Customer();
        }

    }
}