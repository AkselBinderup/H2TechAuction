using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models
{
    internal class User
    {
        public int Id { get; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Zipcode { get; set; }


    }
}
