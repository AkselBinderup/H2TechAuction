using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models
{
    internal class PrivateUser : User
    {
        public string cprNumber { get; }

        public PrivateUser(string cprNumber)
        {
            this.cprNumber = cprNumber;
            //DB createPrivateUser
        }
    }
}
