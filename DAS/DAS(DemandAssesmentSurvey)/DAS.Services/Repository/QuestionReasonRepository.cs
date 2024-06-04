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
    public class QuestionReasonRepository : IQuestionReasonRepository
    {
        public ResultDTO Create(QuestionReasonModal QuesReasModal)
        {
            try
            {
                ResultDTO result = new ResultDTO();
                using (DASdb dbContext = new DASdb())
                {
                    DataSet dataSet = new DataSet();
                    Dictionary<string, object> inParameters = new Dictionary<string, object>();
                    inParameters.Add("@QuestionId", QuesReasModal.QuestionId);
                    inParameters.Add("@Reason", QuesReasModal.Reason);
                    inParameters.Add("@CreatedBy", QuesReasModal.CreatedBy);

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
        public QuestionReasonModal Get(string whereCondition, string orderBy)
        {
            QuestionReasonModal QuesReasModal = null;
            using (DASdb dbContext = new DASdb())
            {
                DataSet dataSet = new DataSet();
                Dictionary<string, object> inParameters = new Dictionary<string, object>();
                inParameters.Add("@WhereClause", whereCondition);
                inParameters.Add("@OrderByClause", orderBy);


                dataSet = DbEngine.Manager.ExecuteDataSet("SP_GetCategory", inParameters, true);
                if (dataSet.HasData())
                {
                    QuesReasModal = dataSet.GetEntity<QuestionReasonModal>();
                }
            }
            return (QuesReasModal);
        }


        public List<QuestionReasonModal> GetAll(string whereCondition, string orderBy)
        {
            List<QuestionReasonModal> QuesReasModal = null;
            using (DASdb dbContext = new DASdb())
            {
                DataSet dataSet = new DataSet();
                Dictionary<string, object> inParameters = new Dictionary<string, object>();
                inParameters.Add("@WhereClause", whereCondition);
                inParameters.Add("@OrderByClause", orderBy);
                DataSet CheckDataset = DbEngine.Manager.ExecuteDataSet("SP_GetCategory", inParameters, true);
                if (CheckDataset.HasData())
                {
                    QuesReasModal = CheckDataset.GetEntityList<QuestionReasonModal>().ToList();
                }
            }
            return (QuesReasModal);
        }

        public ResultDTO Update(QuestionReasonModal QuesReasModal)
        {
            try
            {
                ResultDTO result = new ResultDTO();
                using (DASdb dbContext = new DASdb())
                {
                    DataSet dataSet = new DataSet();
                    Dictionary<string, object> inParameters = new Dictionary<string, object>();
                    inParameters.Add("@QuestionReasonId", QuesReasModal.QuestionReasonId);
                    inParameters.Add("@QuestionId", QuesReasModal.QuestionId);
                    inParameters.Add("@Reason", QuesReasModal.Reason);
                    inParameters.Add("@IsDelete", QuesReasModal.IsDelete); ;
                    inParameters.Add("@ModifiedBy", QuesReasModal.ModifiedBy);
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