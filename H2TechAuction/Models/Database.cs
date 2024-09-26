﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace H2TechAuction.Models
{
    public partial class Database
    {

        private readonly string connectionString;
        private readonly SqlConnection conn;
        public Database()
        {
            SqlConnectionStringBuilder sb = new();
            sb.Clear();
            sb.DataSource = "h2sql.cloudprog.org";
            sb.InitialCatalog = "H2TechAuction";
            sb.UserID = "";
            sb.Password = "";
            connectionString = sb.ToString();
            conn = new SqlConnection(connectionString);
        }

    }
}
