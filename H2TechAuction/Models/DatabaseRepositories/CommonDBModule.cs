using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;


public partial class CommonDBModule <T>
{
    private readonly string JsonPath = @"H2TechAuction\appsettings.json";
    protected SqlConnection GetConnection()
    {
        var JsonContent = File.ReadAllText(JsonPath);
        JObject? keys = (JObject?)JsonConvert.DeserializeObject(JsonContent);
        var Environment = keys?["ConnectionStrings"]?["Dev"]?.Value<string>();
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

    protected List<T> ExecuteReader<T>(SqlCommand? command) where T : new()
    {
        List<T> result = [];

        using SqlDataReader reader = command.ExecuteReader();

        PropertyInfo[] properties = typeof(T).GetProperties();
        while (reader.Read())
        {
            T instance = new();
            foreach (var property in properties)
            {
                if (!reader.HasColumn(property.Name) || reader[property.Name] == DBNull.Value)
                {
                    continue;
                }
                property.SetValue(instance, Convert.ChangeType(reader[property.Name], property.PropertyType));
            }
            result.Add(instance);
        }

        return result;
    }
}
public static class SqlDataReaderExtensions 
{
    public static bool HasColumn(this SqlDataReader reader, string columnName)
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}
