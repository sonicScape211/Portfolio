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
        [Required]
        public string FullName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

        public int Zipcode { get; set; }

        public DateTime SignedDate { get; set; }

        

        public override string ToString()
        {
            return $"{base.ToString()}: License Number = {LicenseNumber}";
        }
    }

}