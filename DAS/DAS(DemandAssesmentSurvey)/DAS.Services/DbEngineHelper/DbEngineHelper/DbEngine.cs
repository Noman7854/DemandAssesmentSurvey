using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Configuration;
using DAS.Modal.Modal;

namespace Services.DbEngineHelper
{
    public sealed class DbEngine
    {
        private static readonly DbEngine _Manager = new DbEngine();

        private DbEngine()
        {
        }

        public static DbEngine Manager
        {
            get
            {
                return _Manager;
            }
        }

        private string GetConnectionString()
        {
            DASdb dbContext = new DASdb();
            return ((System.Data.SqlClient.SqlConnection)dbContext.Database.Connection).ConnectionString;
        }

        public DataSet ExecuteDataSet(string Query)
        {
            try
            {
                return ExecuteDataSet(Query, null, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns dataset for the query.
        /// </summary>
        /// <param name="Query">Query to be excuted.</param>
        /// <param name="Parameters">Parameters as Dictionary<string, object></param>
        /// <param name="IsProcedure">True for stored procedure</param>
        /// <returns>Dataset</returns>
        public DataSet ExecuteDataSet(string Query, Dictionary<string, object> Parameters, bool IsProcedure)
        {

            string connectionString = string.Empty;
            string err = string.Empty;
            DataSet result = new DataSet();
            try
            {
                connectionString = GetConnectionString();
                err = err + connectionString;
                IDbConnection dbConnection = DataFactory.CreateConnection(connectionString, DbType);
                err = err + "</br> connection initialized";
                IDbCommand command = DataFactory.CreateCommand(string.Empty, DbType, dbConnection);
                err = err + "</br> command initialized";
                {
                    command.CommandType = IsProcedure ? CommandType.StoredProcedure : CommandType.Text;
                    command.CommandText = Query;
                    if (Parameters != null)
                    {
                        foreach (KeyValuePair<string, object> param in Parameters)
                        {
                            IDbDataParameter parameter = DataFactory.CreateParameter(DbType);
                            parameter.ParameterName = param.Key;
                            parameter.Value = param.Value;
                            command.Parameters.Add(parameter);
                        }
                    }
                    err = err + "</br> command parameters added";
                    IDbDataAdapter adapter = DataFactory.CreateAdapter(command, DbType);
                    adapter.Fill(result);
                    err = err + "</br> adapter filled";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public string ExecuteScalar(string Query)
        {
            return ExecuteScalar(Query, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Query">Query to be executed.</param>
        /// <param name="Parameters">Parameters as Dictionary<string, object></param>
        /// <returns>string</returns>
        public string ExecuteScalar(string Query, Dictionary<string, object> Parameters)
        {
            string result = string.Empty;
            string connectionString = GetConnectionString();
            try
            {
                IDbConnection dbConnection = DataFactory.CreateConnection(connectionString, DbType);
                using (IDbCommand command = DataFactory.CreateCommand(string.Empty, DbType, dbConnection))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = Query;
                    if (Parameters != null)
                    {
                        foreach (KeyValuePair<string, object> param in Parameters)
                        {
                            IDbDataParameter parameter = DataFactory.CreateParameter(DbType);
                            parameter.ParameterName = param.Key;
                            parameter.Value = param.Value;
                            command.Parameters.Add(parameter);
                        }
                    }

                    dbConnection.Open();
                    result = command.ExecuteScalar().ToString();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
         
        public int ExecuteNonQuery(string Query, Dictionary<string, object> Parameters, bool IsProcedure)
        {
            int result = 0;
            string connectionString = GetConnectionString();
            try
            {
                IDbConnection dbConnection = DataFactory.CreateConnection(connectionString, DbType);
                using (IDbCommand command = DataFactory.CreateCommand(string.Empty, DbType, dbConnection))
                {
                    command.CommandType = IsProcedure ? CommandType.StoredProcedure : CommandType.Text;
                    command.CommandText = Query;
                    if (Parameters != null)
                    {
                        foreach (KeyValuePair<string, object> param in Parameters)
                        {
                            IDbDataParameter parameter = DataFactory.CreateParameter(DbType);
                            parameter.ParameterName = param.Key;
                            parameter.Value = param.Value;
                            command.Parameters.Add(parameter);
                        }
                    }
                    dbConnection.Open();
                    result = command.ExecuteNonQuery();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }



        /// <summary>
        /// Get the database type from the config file
        /// </summary>
        public DatabaseType DbType
        {
            get
            {
                try
                {
                    return (DatabaseType)Convert.ToInt16(ConfigurationManager.AppSettings["DatabaseType"]);
                }
                catch (Exception)
                {
                    return DatabaseType.MSSqlServer;
                }
            }
        }
    }
}