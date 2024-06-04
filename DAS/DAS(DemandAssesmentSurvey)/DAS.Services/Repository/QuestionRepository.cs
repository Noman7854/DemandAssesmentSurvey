using DAS.Modal.Modal;
using DAS.Services.Interface;
using DAS.Services.Modal;
using DAS.Services.Model;
using Services.DbEngineHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DAS.Services.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        public ResultDTO Create(QuestionModal questionModel)
        {
            try
            {
                ResultDTO result = new ResultDTO();
                using (DASdb dbContext = new DASdb())
                {
                    DataSet dataSet = new DataSet();
                    Dictionary<string, object> inParameters = new Dictionary<string, object>();
                    inParameters.Add("@CompanyId", questionModel.CompanyId);
                    inParameters.Add("@Question", questionModel.Question);
                    inParameters.Add("@QuestionYear", questionModel.QuestionYear);
                    inParameters.Add("@QuestionYear", questionModel.QuestionYear);
                    inParameters.Add("@CreatedBy", questionModel.CreatedBy);

                    int count = DbEngine.Manager.ExecuteNonQuery("SP_CreateQuestion", inParameters, true);
                    if (count > 0)
                    {
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

        public QuestionModal Get(string whereCondition, string orderBy)
        {
            QuestionModal  questionModel = null;
            using (DASdb dbContext = new DASdb())
            {
                DataSet dataSet = new DataSet();
                Dictionary<string, object> inParameters = new Dictionary<string, object>();
                inParameters.Add("@WhereClause", whereCondition);
                inParameters.Add("@OrderByClause", orderBy);


                dataSet = DbEngine.Manager.ExecuteDataSet("SP_GetQuestion", inParameters, true);
                if (dataSet.HasData())
                {
                    questionModel = dataSet.GetEntity<QuestionModal>();
                }
            }
            return (questionModel);
        }

        public List<QuestionModal> GetAll(string whereCondition, string orderBy)
        {
            List<QuestionModal> questionModel = null;
            using (DASdb dbContext = new DASdb())
            {
                DataSet dataSet = new DataSet();
                Dictionary<string, object> inParameters = new Dictionary<string, object>();
                inParameters.Add("@WhereClause", whereCondition);
                inParameters.Add("@OrderByClause", orderBy);

                DataSet CheckDataset = DbEngine.Manager.ExecuteDataSet("SP_GetQuestion", inParameters, true);
                if (CheckDataset.HasData())
                {
                    questionModel = CheckDataset.GetEntityList<QuestionModal>().ToList();
                }
            }
            return (questionModel);
        }

        public ResultDTO Update(QuestionModal questionModel)
        {
            try
            {
                ResultDTO result = new ResultDTO();
                using (DASdb dbContext = new DASdb())
                {
                    DataSet dataSet = new DataSet();
                    Dictionary<string, object> inParameters = new Dictionary<string, object>();
                    inParameters.Add("@QuestionId", questionModel.QuestionId);
                    inParameters.Add("@CompanyId", questionModel.CompanyId);
                    inParameters.Add("@Question", questionModel.Question);
                    inParameters.Add("@QuestionYear", questionModel.QuestionYear);
                    inParameters.Add("@QuestionYear", questionModel.QuestionYear);
                    inParameters.Add("@IsDelete", questionModel.IsDelete);
                    inParameters.Add("@ModifiedBy", questionModel.ModifiedBy);

                    int count = DbEngine.Manager.ExecuteNonQuery("SP_EditQuestion", inParameters, true);
                    if (count > 0)
                    {
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
    }
}