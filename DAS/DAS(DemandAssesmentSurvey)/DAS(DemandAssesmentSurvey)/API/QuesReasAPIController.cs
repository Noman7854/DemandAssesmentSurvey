using DAS.Services.Interface;
using DAS.Services.Modal;
using DAS.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DemandAssesmentSurvey_DAS_.API
{
    [RoutePrefix("api/questionreason")]
    public class QuesReasAPIController : ApiController
    {
        private IQuestionReasonRepository questionReasonRepository;
        ResultDTO result = new ResultDTO();
        public QuesReasAPIController()
        {
            questionReasonRepository = new QuestionReasonRepository();
        }
        [HttpPost]
        [Route("getall")]
        public async Task<IHttpActionResult> GetAll([FromBody] FilterModal filterModel)
        {
            string whereClause = String.Empty;
            string orderBy = String.Empty;


            List<QuestionReasonModal> quesReasDetails = questionReasonRepository.GetAll(whereClause, orderBy);
            //categoryDetails = categoryDetails.OrderBy(x => x.DomainId).ToList();

            if (quesReasDetails != null)
            {
                result.ResultFlag = true;
                result.Status = "Success";
                result.Comment = "Success";
            }
            else
            {
                result.ResultFlag = false;
                result.Status = "Failed";
                result.Comment = "Failed";
            }
            await Task.Delay(0);
            return Ok(quesReasDetails);


        }
        [HttpPost]
        [Route("get")]
        public async Task<IHttpActionResult> Get([FromBody] FilterModal filterModel)
        {
            string whereClause = String.Empty;
            string orderBy = String.Empty;
            whereClause += " qr.QuestionReasonId='" + Convert.ToInt32(filterModel.FilterValue) + "'";
            QuestionReasonModal quesReasModal = questionReasonRepository.Get(whereClause, orderBy);
            if (quesReasModal != null)
            {
                result.ResultFlag = true;
                result.Status = "Success";
                result.Comment = "Success";
            }
            else
            {
                result.ResultFlag = false;
                result.Status = "Failed";
                result.Comment = "Failed";
            }
            await Task.Delay(0);
            return Ok(quesReasModal);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> Create([FromBody] QuestionReasonModal quesReasModal)
        {
            result = questionReasonRepository.Create(quesReasModal);

            if (result.ResultFlag == true)
            {
                result.ResultFlag = true;
                result.Status = "Success";
                result.Comment = "Success";
            }
            else
            {
                result.ResultFlag = false;
                result.Status = "Failed";
                result.Comment = "Failed";
            }


            await Task.Delay(0);
            return Ok(result);
        }
        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> Update([FromBody] QuestionReasonModal quesReasModal)
        {

            result = questionReasonRepository.Update(quesReasModal);

            if (result.ResultFlag == true)
            {
                result.ResultFlag = true;
                result.Status = "Success";
                result.Comment = "Success";
            }
            else
            {
                result.ResultFlag = false;
                result.Status = "Failed";
                result.Comment = "Failed";
            }
            await Task.Delay(0);
            return Ok(result);
        }
    }
}