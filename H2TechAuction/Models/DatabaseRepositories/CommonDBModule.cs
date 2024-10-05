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
    private readonly string JsonPath = @"..\..\..\appsettings.json";
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
    protected int ExecuteCommandReturnId(string command)
    {
        int newId = 0;
        using var conn = GetConnection();
        
        var sqlCommand = new SqlCommand(command, conn);
        object result = sqlCommand.ExecuteScalar(); 

        if (result != null && int.TryParse(result.ToString(), out newId))
        {
            return newId;
        }
        
        return newId; 
    }
    protected bool ExecuteReaderWithParametersAsync(SqlCommand command, string field, string comparisonValue)
    {
        using var conn = GetConnection();
        command.Connection = conn;
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var fieldValue = reader[field].ToString();
            var comp = comparisonValue;

            return fieldValue == comp;
        }
        return false;
    }
    

    protected List<T> ExecuteReader<T>(SqlCommand? command) where T : new()
    {
        List<T> result = [];
        command.Connection = GetConnection();
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
                var propertyType = property.PropertyType;

                if (propertyType.IsEnum)
                {
                    var enumValue = Enum.ToObject(propertyType, reader[property.Name]);
                    property.SetValue(instance, enumValue);
                }
                else
                {
                    property.SetValue(instance, Convert.ChangeType(reader[property.Name], propertyType));
                }
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
