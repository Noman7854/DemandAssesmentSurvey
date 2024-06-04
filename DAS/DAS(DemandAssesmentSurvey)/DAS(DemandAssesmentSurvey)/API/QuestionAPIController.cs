using DAS.Services.Interface;
using DAS.Services.Modal;
using DAS.Services.Model;
using DAS.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DemandAssessmentServey_DAS_.API
{
    [RoutePrefix("api/question")]
    public class QuestionAPIController : ApiController
    {
        private IQuestionRepository questionRepository;
        ResultDTO resultDTO = new ResultDTO();
        public QuestionAPIController()
        {
            questionRepository = new QuestionRepository();
        }

        [HttpPost]
        [Route("getall")]
        public async Task<IHttpActionResult> GetAll([FromBody] FilterModal filterModel)
        {
            string whereClause = String.Empty;
            string orderBy = String.Empty;

            List<QuestionModal> questionDelails = questionRepository.GetAll(whereClause, orderBy);
            questionDelails = questionDelails.OrderBy(x => x.Question).ToList();
            if (questionDelails != null)
            {
                resultDTO.ResultFlag = true;
                resultDTO.Status = "Success";
                resultDTO.Comment = "Success";
            }
            else
            {
                resultDTO.ResultFlag = false;
                resultDTO.Status = "Failed";
                resultDTO.Comment = "Failed";
            }
            await Task.Delay(0);
            return Ok(questionDelails);


        }

        [HttpPost]
        [Route("get")]
        public async Task<IHttpActionResult> Get([FromBody] FilterModal filterModel)
        {
            string whereClause = String.Empty;
            string orderBy = String.Empty;
            whereClause += " q.QuestionId='" + Convert.ToInt32(filterModel.FilterValue) + "'";
            QuestionModal questionDletails = questionRepository.Get(whereClause, orderBy);
            if (questionDletails != null)
            {
                resultDTO.ResultFlag = true;
                resultDTO.Status = "Success";
                resultDTO.Comment = "Success";
            }
            else
            {
                resultDTO.ResultFlag = false;
                resultDTO.Status = "Failed";
                resultDTO.Comment = "Failed";
            }
            await Task.Delay(0);
            return Ok(questionDletails);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> Create([FromBody] QuestionModal questionModel)
        {

            resultDTO = questionRepository.Create(questionModel);

            if (resultDTO.ResultFlag == true)
            {
                resultDTO.ResultFlag = true;
                resultDTO.Status = "Success";
                resultDTO.Comment = "Success";
            }
            else
            {
                resultDTO.ResultFlag = false;
                resultDTO.Status = "Failed";
                resultDTO.Comment = "Failed";
            }


            await Task.Delay(0);
            return Ok(resultDTO);
        }  
        
        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> Update([FromBody] QuestionModal questionModel)
        {

            resultDTO = questionRepository.Update(questionModel);

            if (resultDTO.ResultFlag == true)
            {
                resultDTO.ResultFlag = true;
                resultDTO.Status = "Success";
                resultDTO.Comment = "Success";
            }
            else
            {
                resultDTO.ResultFlag = false;
                resultDTO.Status = "Failed";
                resultDTO.Comment = "Failed";
            }


            await Task.Delay(0);
            return Ok(resultDTO);
        }
    }
}
