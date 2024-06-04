using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Services.DbEngineHelper
{
    public static class ExtensionMethods
    {
        private const string DateFormat = "MM/dd/yyyy";
        public static DateTime? ToDate(this string value)
        {

            if (string.IsNullOrWhiteSpace(value) == false)
            {
                DateTime date;
                if (DateTime.TryParseExact(value, DateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                {
                    return date;
                }
            }
            return null;
        }

        /// <summary>
        /// Checks whether specified dataset set has atleaset one table and one row
        /// </summary>
        public static bool HasData(this DataSet data)
        {
            if (!(data == null || data.Tables.Count == 0 || data.Tables[0].Rows.Count == 0))
            {
                return true;
            }
            return false;
        }

        public static bool HasDataChecker(this DataSet data)
        {
            if (!(data == null || data.Tables.Count == 0))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Generates list of specified type from the given dataset
        /// </summary>
        public static List<T> GetEntityList<T>(this DataSet ds) where T : new()
        {
            try
            {
                if (ds.HasData())
                {
                    return GetEntityList<T>(ds.Tables[0]);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Generates list of specified type from the given dataset
        /// </summary>
        /// <typeparam name="T">Type of list</typeparam>
        /// <param name="dt">Datatable which needs to used</param>
        /// <returns>List of specified type, null as otherwise</returns>
        public static List<T> GetEntityList<T>(this DataTable dt) where T : new()
        {
            try
            {
                List<T> entityList = new List<T>();
                var castToEntity = new T();
                var properties = typeof(T).GetProperties();
                PropertyInfo[] propertiess = (castToEntity.GetType()).GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                foreach (DataRow row in dt.Rows)
                {
                    var entity = new T();
                    foreach (DataColumn col in row.Table.Columns)
                    {
                        var tru = properties.FirstOrDefault(i => i.Name.ToLower() == col.ColumnName.ToLower());
                        if (tru != null)
                        {
                            try
                            {
                                if (tru.PropertyType == typeof(string))
                                {
                                    tru.SetValue(entity, row[tru.Name].ToString());
                                    continue;
                                }
                                else if (tru.PropertyType == typeof(DateTime))
                                {
                                    if (row[tru.Name] != DBNull.Value)
                                    {
                                        tru.SetValue(entity, Convert.ToDateTime(row[tru.Name]));
                                    }
                                }
                                else if (tru.PropertyType == typeof(Int16))
                                {
                                    if (!string.IsNullOrEmpty(row[tru.Name].ToString()))
                                        tru.SetValue(entity, Convert.ToInt16(row[tru.Name]));
                                }
                                else if (tru.PropertyType == typeof(Int32))
                                {
                                    if (!string.IsNullOrEmpty(row[tru.Name].ToString()))
                                        tru.SetValue(entity, Convert.ToInt32(row[tru.Name]));
                                }
                                else if (tru.PropertyType == typeof(string))
                                {
                                    if (!string.IsNullOrEmpty(row[tru.Name].ToString()))
                                        tru.SetValue(entity, Convert.ToString(row[tru.Name]));
                                }
                                else if (tru.PropertyType == typeof(decimal))
                                {
                                    if (!string.IsNullOrEmpty(row[tru.Name].ToString()))
                                        tru.SetValue(entity, Convert.ToDecimal(row[tru.Name]));
                                }
                                else if (tru.PropertyType == typeof(double))
                                {
                                    if (!string.IsNullOrEmpty(row[tru.Name].ToString()))
                                        tru.SetValue(entity, Convert.ToDouble(row[tru.Name].ToString()));
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(row[tru.Name].ToString()))
                                        tru.SetValue(entity, row[tru.Name]);
                                }
                            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                            {
                            }

                        }
                    }
                    entityList.Add(entity);
                }

                return entityList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Generates object and assign the values 
        /// </summary>
        /// <typeparam name="T">Type name</typeparam>
        /// <param name="ds">Dataset which needs to used</param>
        /// <returns>Object of specified type, default value as otherwise</returns>
        public static T GetEntity<T>(this DataSet ds) where T : new()
        {
            try
            {

                if (ds.HasData())
                {
                    return GetEntity<T>(ds.Tables[0]);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Generates object and assign the values 
        /// </summary>
        /// <typeparam name="T">Type name</typeparam>
        /// <param name="dt">Datatable which needs to used</param>
        /// <returns>Object of specified type, default value as otherwise</returns>
        public static T GetEntity<T>(this DataTable dt) where T : new()
        {
            try
            {
                return GetEntityList<T>(dt).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}