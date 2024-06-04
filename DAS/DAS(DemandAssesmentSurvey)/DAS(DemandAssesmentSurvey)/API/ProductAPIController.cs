using DAS.Services;
using DAS.Services.Interface;
using DAS.Services.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DAS_DemandAssesmentSurvey_.API
{
    [RoutePrefix("api/product")]
    public class ProductAPIController : ApiController
    {
        private IProductRepository productRepository;
        ResultDTO result = new ResultDTO();
        public ProductAPIController()
        {
            productRepository = new ProductRepository();
        }
        [HttpPost]
        [Route("getall")]
        public async Task<IHttpActionResult> GetAll([FromBody] FilterModal filterModel)
        {
            string whereClause = String.Empty;
            string orderBy = String.Empty;


            List<ProductModal> productDetails = productRepository.GetAll(whereClause, orderBy);
            //categoryDetails = categoryDetails.OrderBy(x => x.DomainId).ToList();

            if (productDetails != null)
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
            return Ok(productDetails);


        }
        [HttpPost]
        [Route("get")]
        public async Task<IHttpActionResult> Get([FromBody] FilterModal filterModel)
        {
            string whereClause = String.Empty;
            string orderBy = String.Empty;
            whereClause += " c.CategoryId='" + Convert.ToInt32(filterModel.FilterValue) + "'";
            ProductModal productModal = productRepository.Get(whereClause, orderBy);
            if (productModal != null)
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
            return Ok(productModal);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> Create([FromBody] ProductModal productModal)
        {
            result = productRepository.Create(productModal);

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
        public async Task<IHttpActionResult> Update([FromBody] ProductModal productModal)
        {

            result = productRepository.Update(productModal);

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
