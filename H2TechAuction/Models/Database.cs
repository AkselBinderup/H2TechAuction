using System;
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
            sb.DataSource = "sql.itcn.dk";
            sb.InitialCatalog = "jani7.SKOLE";
            sb.UserID = "jani7.SKOLE";
            sb.Password = "g3t0He1D5K";
            connectionString = sb.ToString();
            conn = new SqlConnection(connectionString);
        }

    }
}
