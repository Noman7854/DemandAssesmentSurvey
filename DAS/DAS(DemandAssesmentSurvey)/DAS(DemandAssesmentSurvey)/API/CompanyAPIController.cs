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
    [RoutePrefix("api/company")]
    public class CompanyAPIController : ApiController
    {
        private ICompanyRepository companyRepository;
        ResultDTO result = new ResultDTO();
        public CompanyAPIController()
        {
            companyRepository = new CompanyRepository();
        }
        [HttpPost]
        [Route("getall")]
        public async Task<IHttpActionResult> GetAll([FromBody] FilterModal filterModel)
        {
            string whereClause = String.Empty;
            string orderBy = String.Empty;


            List<CompanyModal> companyDetails = companyRepository.GetAll(whereClause, orderBy);
            //companyDetails = companyDetails.OrderBy(x => x.zCompanyId).ToList();

            if (companyDetails != null)
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
            return Ok(companyDetails);


        }
        [HttpPost]
        [Route("get")]
        public async Task<IHttpActionResult> Get([FromBody] FilterModal filterModel)
        {
            string whereClause = String.Empty;
            string orderBy = String.Empty;
            whereClause += " c.CompanyId='" + Convert.ToInt32(filterModel.FilterValue) + "'";
            CompanyModal companyModel = companyRepository.Get(whereClause, orderBy);
            if (companyModel != null)
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
            return Ok(companyModel);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> Create([FromBody] CompanyModal companyModal)
        {
            result = companyRepository.Create(companyModal);

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
        public async Task<IHttpActionResult> Update([FromBody] CompanyModal companyModal)
        {

            result = companyRepository.Update(companyModal);

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