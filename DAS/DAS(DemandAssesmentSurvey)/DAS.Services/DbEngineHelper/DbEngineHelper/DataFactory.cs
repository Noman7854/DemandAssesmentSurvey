using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.DbEngineHelper
{
    public static class DataFactory
    {
        public static IDbConnection CreateConnection(string connectionString, DatabaseType dbType)
        {
            IDbConnection cnn;

            switch (dbType)
            {
                case DatabaseType.Access:
                    cnn = new OleDbConnection(connectionString);
                    break;
                case DatabaseType.MSSqlServer:
                    cnn = new SqlConnection(connectionString);
                    //   break;
                    //case DatabaseType.Oracle:
                    //   cnn = new OracleConnection
                    //      (ConnectionString);
                    break;
                default:
                    cnn = new SqlConnection(connectionString);
                    break;
            }

            return cnn;
        }

        public static IDbCommand CreateCommand(string commandText, DatabaseType dbType, IDbConnection cnn)
        {
            IDbCommand cmd;
            switch (dbType)
            {
                case DatabaseType.Access:
                    cmd = new OleDbCommand(commandText, (OleDbConnection)cnn);
                    break;

                case DatabaseType.MSSqlServer:
                    cmd = new SqlCommand(commandText, (SqlConnection)cnn);
                    break;

                //case DatabaseType.Oracle:
                //   cmd = new OracleCommand
                //      (CommandText,
                //      (OracleConnection)cnn);
                //   break;
                default:
                    cmd = new SqlCommand(commandText, (SqlConnection)cnn);
                    break;
            }

            return cmd;
        }

        public static IDbDataAdapter CreateAdapter(IDbCommand command, DatabaseType dbType)
        {
            IDbDataAdapter da;
            switch (dbType)
            {
                case DatabaseType.Access:
                    da = new OleDbDataAdapter((OleDbCommand)command);
                    break;

                case DatabaseType.MSSqlServer:
                    da = new SqlDataAdapter((SqlCommand)command);
                    break;

                //case DatabaseType.Oracle:
                //   da = new OracleDataAdapter
                //      ((OracleCommand)cmd); 
                //   break;

                default:
                    da = new SqlDataAdapter((SqlCommand)command);
                    break;
            }

            return da;
        }

        public static IDbDataParameter CreateParameter(DatabaseType dbType)
        {
            IDbDataParameter dataParameter;
            switch (dbType)
            {
                case DatabaseType.Access:
                    dataParameter = new OleDbParameter();
                    break;

                case DatabaseType.MSSqlServer:
                    dataParameter = new SqlParameter();
                    break;

                //case DatabaseType.Oracle:
                //   da = new OracleDataAdapter
                //      ((OracleCommand)cmd); 
                //   break;

                default:
                    dataParameter = new SqlParameter();
                    break;
            }

            return dataParameter;
        }
    }
}