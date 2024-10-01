using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;


public partial class CommonDBModule
{
    //path To connectionString 
    private readonly string JsonPath = @"MainProgram\Client\appsettings.json";
    protected SqlConnection GetConnection()
    {
        var JsonContent = File.ReadAllText(JsonPath);
        JObject keys = (JObject)JsonConvert.DeserializeObject(JsonContent);
        var Environment = keys["ConnectionStrings"]["Dev"].Value<string>();
        var conn = new SqlConnection(Environment);
        conn.Open();
        return conn;
    }
    protected bool ExecuteCommand(string command)
    {
        var conn = GetConnection();
        var Command = new SqlCommand(command, conn);
        var res = Command.ExecuteNonQuery() > 0;
        conn.Close();
        return res;
    }

}
