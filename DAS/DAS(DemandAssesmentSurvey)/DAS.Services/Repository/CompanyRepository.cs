using DAS.Modal.Modal;
using DAS.Services.Interface;
using DAS.Services.Modal;
using Services.DbEngineHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DAS.Services.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        public ResultDTO Create(CompanyModal companyModals)
        {
            try
            {
                ResultDTO result = new ResultDTO();
                using (DASdb dbContext = new DASdb())
                {
                    DataSet dataSet = new DataSet();
                    Dictionary<string, object> inParameters = new Dictionary<string, object>();
                    inParameters.Add("@CompanyName", companyModals.CompanyName);
                    inParameters.Add("@CreatedBy", companyModals.CreatedBy);

                    int count = DbEngine.Manager.ExecuteNonQuery("SP_Createcategory", inParameters, true);
                    if (count > 0)
                    {
                        result.ResultFlag = true;
                        result.Status = "Success";
                        result.Comment = "Success";
                    }
                }
                return (result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public CompanyModal Get(string whereCondition, string orderBy)
        {
            CompanyModal companyModals = null;
            using (DASdb dbContext = new DASdb())
            {
                DataSet dataSet = new DataSet();
                Dictionary<string, object> inParameters = new Dictionary<string, object>();
                inParameters.Add("@WhereClause", whereCondition);
                inParameters.Add("@OrderByClause", orderBy);


                dataSet = DbEngine.Manager.ExecuteDataSet("SP_GetCategory", inParameters, true);
                if (dataSet.HasData())
                {
                    companyModals = dataSet.GetEntity<CompanyModal>();
                }
            }
            return (companyModals);
        }


        public List<CompanyModal> GetAll(string whereCondition, string orderBy)
        {
            List<CompanyModal> companyModals = null;
            using (DASdb dbContext = new DASdb())
            {
                DataSet dataSet = new DataSet();
                Dictionary<string, object> inParameters = new Dictionary<string, object>();
                inParameters.Add("@WhereClause", whereCondition);
                inParameters.Add("@OrderByClause", orderBy);
                DataSet CheckDataset = DbEngine.Manager.ExecuteDataSet("SP_GetCategory", inParameters, true);
                if (CheckDataset.HasData())
                {
                    companyModals = CheckDataset.GetEntityList<CompanyModal>().ToList();
                }
            }
            return (companyModals);
        }

        public ResultDTO Update(CompanyModal companyModals)
        {
            try
            {
                ResultDTO result = new ResultDTO();
                using (DASdb dbContext = new DASdb())
                {
                    DataSet dataSet = new DataSet();
                    Dictionary<string, object> inParameters = new Dictionary<string, object>();
                    inParameters.Add("@CompanyId", companyModals.CompanyId);
                    inParameters.Add("@CompanyName", companyModals.CompanyName);
                    inParameters.Add("@IsDelete", companyModals.IsDelete); ;
                    inParameters.Add("@ModifiedBy", companyModals .ModifiedBy);
                    int count = DbEngine.Manager.ExecuteNonQuery("SP_EditCategory", inParameters, true);
                    if (count > 0)
                    {
                        result.ResultFlag = true;
                        result.Status = "Success";
                        result.Comment = "Success";
                    }
                }
                return (result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}