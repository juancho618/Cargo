using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cargo.Models
{
    public class CompanyAccountViewModel
    {
        public string CompanyAccountID { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public CountryModel Fk_CountryID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string ContactName { get; set; }
        public string Fk_Agent { get; set; }
    }

    public class CountryModel
    {
        public string CountryID { get; set; }
        public string CountryName { get; set; }

    }
}