using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoW.DocCore.DataObjects.ADO.NET
{
    public static class Db
    {
        private static Dictionary<string, DbProviderFactory> factoryList = null;

        public enum QueryType
        {
            Inline,
            StoredProcedure
        }

        #region Fast Data Reading

        /// <summary>
        /// Read of individual item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="make"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static T Read<T>(QueryType queryType, string sql, Func<IDataReader, T> make, string connectionString = null, object[] parms = null)
        {
            // Factory Design Pattern - 
            DbProviderFactory factory = GetFactory(connectionString);
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = GetConnectionString(connectionString);

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = queryType == QueryType.Inline ? CommandType.Text : CommandType.StoredProcedure;
                    command.CommandText = sql;
                    command.SetParameters(parms);  // Extension method

                    connection.Open();

                    T t = default(T);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                        t = make(reader);

                    return t;
                }
            }
        }

        /// <summary>
        /// Read list of items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="make"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static List<T> ReadList<T>(QueryType queryType, string sql, Func<IDataReader, T> make, string connectionString = null, object[] parms = null)
        {
            DbProviderFactory factory = GetFactory(connectionString);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = GetConnectionString(connectionString);
                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms);
                    command.CommandType = queryType == QueryType.Inline ? CommandType.Text : CommandType.StoredProcedure;

                    connection.Open();

                    var list = new List<T>();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        list.Add(make(reader));

                    return list;
                }
            }
        }

        /// <summary>
        /// Get a record count
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static int GetCount(string sql, string connectionString = null, object[] parms = null)
        {
            return GetScalar(sql, connectionString, parms).AsInt();
        }

        /// <summary>
        /// Get any scalar value
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static object GetScalar(string sql, string connectionString = null, object[] parms = null)
        {
            DbProviderFactory factory = GetFactory(connectionString);
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = GetConnectionString(connectionString);

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms);

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }
       
        #endregion

        #region Data update section

        /// <summary>
        /// Inserts an item into the database
        /// </summary>
        /// <param name="queryType">Query Type</param>
        /// <param name="sql">Inline query or Stored Procedure name</param>
        /// <param name="connectionStringName">AppSettings Connection Name</param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static int Insert(QueryType queryType, string sql, string connectionString = null, object[] parms = null)
        {
            DbProviderFactory factory = GetFactory(connectionString);
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = GetConnectionString(connectionString);

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = queryType == QueryType.Inline ? CommandType.Text : CommandType.StoredProcedure;
                    command.SetParameters(parms);                     // Extension method  
                    command.CommandText = queryType == QueryType.Inline ? sql.AppendIdentitySelect() : sql; // Extension method

                    connection.Open();

                    return command.ExecuteScalar().AsInt();
                }
            }

        }

        /// <summary>
        /// Updates an item in the database
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        public static int Update(QueryType queryType, string sql, string connectionString = null, object[] parms = null)
        {
            DbProviderFactory factory = GetFactory(connectionString);
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = GetConnectionString(connectionString);

                using (var command = factory.CreateCommand())
                {
                    command.CommandType = queryType == QueryType.Inline ? CommandType.Text : CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes an item from the database.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        public static int Delete(QueryType queryType, string sql, string connectionString = null, object[] parms = null)
        {
            return Update(queryType, sql, connectionString, parms);
        }

        #endregion

        #region Private Utilities

        private static DbProviderFactory GetFactory(string ConnectionString = null)
        {
            // Enable the lazy loading here for the factoryList
            if (factoryList == null)
            {
                factoryList = new Dictionary<string, DbProviderFactory>();
                ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
                //We are using Configuration String instead of Enum. so it can be changed at Runtime
                foreach (ConnectionStringSettings conn in connectionStrings)
                {
                    try
                    {

                        string dataProvider = conn.ProviderName;
                        string connectionString = conn.ConnectionString;
                        string connectionStringName = conn.Name;
                        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
                        factoryList.Add(connectionStringName, factory);
                    }
                    catch (Exception) { }
                }
            }

            if (factoryList.Count > 0)
            {
                if (ConnectionString == null)
                    return factoryList.ElementAt(0).Value;
                else if (factoryList.ContainsKey(ConnectionString))
                    return factoryList[ConnectionString];
                else
                    return null;
            }
            else
                return null;
        }

        private static string GetDataProvider(string ConnectionString = null)
        {
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            if (connectionStrings.Count > 0)
            {
                if (ConnectionString == null)
                    return connectionStrings[0].ProviderName;
                else
                    return connectionStrings[ConnectionString].ProviderName;
            }
            else
                return null;
        }

        #endregion

        #region Public Utilities

        public static string GetConnectionString(string ConnectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        }
        
        #endregion

        #region Extension methods

        /// <summary>
        /// Extension method: Appends the db specific syntax to sql string 
        /// for retrieving newly generated identity (autonumber) value.
        /// </summary>
        /// <param name="sql">The sql string to which to append syntax.</param>
        /// <returns>Sql string with identity select.</returns>
        private static string AppendIdentitySelect(this string sql, string ConnectionString = null)
        {
            switch (GetDataProvider(ConnectionString))
            {
                // Microsoft Access does not support multistatement batch commands
                case "System.Data.OleDb": return sql;
                case "System.Data.SqlClient": return sql + ";SELECT SCOPE_IDENTITY()";
                case "System.Data.OracleClient": return sql + ";SELECT MySequence.NEXTVAL FROM DUAL";
                default: return sql + ";SELECT @@IDENTITY";
            }
        }

        /// <summary>
        /// Extention method. Adds query parameters to command object.
        /// </summary>
        /// <param name="command">Command object.</param>
        /// <param name="parms">Array of name-value query parameters.</param>
        private static void SetParameters(this DbCommand command, object[] parms)
        {
            if (parms != null && parms.Length > 0)
            {
                // NOTE: Processes a name/value pair at each iteration
                for (int i = 0; i < parms.Length; i += 2)
                {
                    string name = parms[i].ToString();

                    // No empty strings to the database
                    if (parms[i + 1] is string && (string)parms[i + 1] == "")
                        parms[i + 1] = null;

                    // If null, set to DbNull
                    object value = parms[i + 1] ?? DBNull.Value;

                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = name;
                    dbParameter.Value = value;

                    command.Parameters.Add(dbParameter);
                }
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">The reader.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultVal">The default val.</param>
        /// <returns></returns>
        public static T GetValue<T>(IDataReader reader, string key, T defaultVal)
        {
            if (reader[key] == null)
                return defaultVal;
            else
            {
                try
                {
                    object value = reader[key];
                    if (typeof(T) == typeof(int))
                        return (T)(object)int.Parse(value.ToString());
                    else if (typeof(T) == typeof(float))
                        return (T)(object)float.Parse(value.ToString());
                    else if (typeof(T) == typeof(decimal))
                        return (T)(object)decimal.Parse(value.ToString());
                    else if (typeof(T) == typeof(DateTime))
                        return (T)(object)DateTime.Parse(value.ToString());
                    else if (typeof(T) == typeof(double))
                        return (T)(object)double.Parse(value.ToString());

                    else
                        return (T)reader[key];
                }
                catch (Exception)
                {
                    return default(T);
                }
            }
        }

        #endregion
    }
}
