using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class SqlConneciton
{ 
    static string SQLConnectionString = "Server=mssql02.trwww.com;Database=***;User Id=***;Password=****;";
    static SqlConnection sqlConnection = new SqlConnection();
    static SqlCommand sqlCommand = new SqlCommand();

    private static void SetAdonetConnection()
    {
        sqlConnection.ConnectionString = SQLConnectionString;
        sqlCommand.Connection = sqlConnection;
    }

    public static bool ExecuteData(string commandText)
    {
        try
        {
            SetAdonetConnection();
            sqlCommand.CommandText = commandText;
            sqlConnection.Open();
            int effectedRows = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return effectedRows > 0 ? true : false;
        }
        catch (Exception ex)
        {
            return false;
        }
        
    }

    public static DataTable GetData(string TableName, string fieldName = "*", string condition = null)
    {
        try
        {
            SetAdonetConnection();

            DataTable result = new DataTable();
            string query = $"select {fieldName} from {TableName} ";
            if (condition != null)
            {
                query += $"where {condition}";
            }
            sqlCommand.CommandText = query;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            sqlConnection.Open();
            adapter.Fill(result);
            sqlConnection.Close();
            return result;

        }
        catch (Exception ex)
        {
            return new DataTable();
        }

    }

    public static string CreateInsertString(string tableName, Hashtable htData)
    {
        string query = string.Empty;
        string colums = string.Empty;
        string values = string.Empty;
        //insert into (col1,col2) values (deg1,deg2)
        foreach (var item in htData.Keys) //colums
        {
            string ItemValue = htData[item].ToString();
            colums += item + ",";
            values += ItemValue + ",";
        }
        colums = colums.TrimEnd(',');
        values = values.TrimEnd(',');
        query = $"insert into {tableName} ({colums}) values({values})";

        return query;
    }

    public static bool InsertData(string tableName, Hashtable htData)
    {
        try
        {
            return ExecuteData(CreateInsertString(tableName, htData));
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static string CreateUpdateString(string tableName, Hashtable htData, string condition = null)
    {
        string result = string.Empty;
        string sets = string.Empty;
        //update tabloismi set coll=degeri, col2=deger2 where id=3
        foreach (var item in htData.Keys)
        {
            string ItemValue = htData[item].ToString();
            sets += $"{item}={ItemValue},";
        }
        sets = sets.TrimEnd(',');
        result = $"update {tableName} set {sets} where {condition}";
        return result;
    }
    public static bool UpdateData(string tableName, Hashtable htData, string condition = null)
    {
        try
        {
            return ExecuteData(CreateUpdateString(tableName, htData, condition));

        }
        catch (Exception)
        {
            return false;
        }

    }

    public static bool DeleteData(string tableName, string condition)
    {
        try
        {
            string query = $"delete from {tableName} ";
            query += condition != null ? $"where {condition} " : "";
            return ExecuteData(query);
        }
        catch (Exception)
        {
            return false;
        }
    }
}
