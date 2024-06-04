using DAS.Modal.Modal;
using DAS.Services.Interface;
using DAS.Services.Modal;
using Services.DbEngineHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DAS.Services
{
    public class ProductRepository : IProductRepository
    {
        public ResultDTO Create(ProductModal productModal)
        {
            try
            {
                ResultDTO result = new ResultDTO();
                using (DASdb dbContext = new DASdb())
                {
                    DataSet dataSet = new DataSet();
                    Dictionary<string, object> inParameters = new Dictionary<string, object>();
                    inParameters.Add("@CompanyId", productModal.CompanyId);
                    inParameters.Add("@ProductName", productModal.ProductName);
                    inParameters.Add("@ProductType", productModal.ProductType);
                    inParameters.Add("@CreatedBy", productModal.CreatedBy);

                    int count = DbEngine.Manager.ExecuteNonQuery("SP_CreateProduct", inParameters, true);
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

        public ProductModal Get(string whereCondition, string orderBy)
        {
            ProductModal productModals = null;
            using (DASdb dbContext = new DASdb())
            {
                DataSet dataSet = new DataSet();
                Dictionary<string, object> inParameters = new Dictionary<string, object>();
                inParameters.Add("@WhereClause", whereCondition);
                inParameters.Add("@OrderByClause", orderBy);


                dataSet = DbEngine.Manager.ExecuteDataSet("SP_GetCategory", inParameters, true);
                if (dataSet.HasData())
                {
                    productModals = dataSet.GetEntity<ProductModal>();
                }
            }
            return (productModals);
        }

        public List<ProductModal> GetAll(string whereCondition, string orderBy)
        {
            List<ProductModal> productModals = null;
            using (DASdb dbContext = new DASdb())
            {
                DataSet dataSet = new DataSet();
                Dictionary<string, object> inParameters = new Dictionary<string, object>();
                inParameters.Add("@WhereClause", whereCondition);
                inParameters.Add("@OrderByClause", orderBy);
                DataSet CheckDataset = DbEngine.Manager.ExecuteDataSet("SP_GetCategory", inParameters, true);
                if (CheckDataset.HasData())
                {
                    productModals = CheckDataset.GetEntityList<ProductModal>().ToList();
                }
            }
            return (productModals);
        }

        public ResultDTO Update(ProductModal productModal)
        {
            try
            {
                ResultDTO result = new ResultDTO();
                using (DASdb dbContext = new DASdb())
                {
                    DataSet dataSet = new DataSet();
                    Dictionary<string, object> inParameters = new Dictionary<string, object>();
                    inParameters.Add("@ProductId", productModal.ProductId);
                    inParameters.Add("@CompanyId", productModal.CompanyId);
                    inParameters.Add("@ProductName", productModal.ProductName);
                    inParameters.Add("@ProductType", productModal.ProductType);
                    inParameters.Add("@IsDelete", productModal.IsDelete);
                    inParameters.Add("@ModifiedBy", productModal.ModifiedBy);
                    int count = DbEngine.Manager.ExecuteNonQuery("SP_EditProduct", inParameters, true);
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
                throw;
            }
        }
    }
}