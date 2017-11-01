using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class DMVEntry
    {
        public int ID { get; set; }

        public int LicenseNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FullName { get; set; }

        public string StreetAddress { get; set; }
        
        public string City { get; set; }

        public string State { get; set; }

        public int Zipcode { get; set; }

        public DateTime SignedDate { get; set; }
    }

}