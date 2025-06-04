using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Tools.Database
{
    public static class DbConnectionExtensions
    {
        public static object? ExecuteScalar(this DbConnection dbConnection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            using (DbCommand dbCommand = CreateCommand(dbConnection, query, isStoredProcedure, parameters))
            {                
                object? result = dbCommand.ExecuteScalar();
                return result is DBNull ? null : result;
            }
        }

        public static int ExecuteNonQuery(this DbConnection dbConnection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            using (DbCommand dbCommand = CreateCommand(dbConnection, query, isStoredProcedure, parameters))
            {
                return dbCommand.ExecuteNonQuery();
            }
        }

        public static IEnumerable<T> ExecuteReader<T>(this DbConnection dbConnection, string query, Func<IDataRecord, T> selector, bool isStoredProcedure = false, object? parameters = null)
        {
            using (DbCommand dbCommand = CreateCommand(dbConnection, query, isStoredProcedure, parameters))
            {
                using (DbDataReader reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return selector(reader);
                    }
                }
            }
        }

        private static DbCommand CreateCommand(DbConnection connection, string query, bool isStoredProcedure, object? parameters)
        {
            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;
            if (isStoredProcedure)
                dbCommand.CommandType = CommandType.StoredProcedure;

            if(parameters is not null)
            {
                Type parameterType = parameters.GetType();

                IEnumerable<PropertyInfo> propertyInfos = parameterType.GetProperties().Where(p => p.CanRead); ;
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    DbParameter dbParameter = dbCommand.CreateParameter();
                    dbParameter.ParameterName = propertyInfo.Name;
                    dbParameter.Value = propertyInfo.GetValue(parameters) ?? DBNull.Value;
                    dbCommand.Parameters.Add(dbParameter);
                }
            }


            return dbCommand;
        }
    }
}
