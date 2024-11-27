using FromRouteAndFromeQueryAndFromeURI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FromRouteAndFromeQueryAndFromeURI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FromRoute : ControllerBase
    {
        #region FromRoute Attribute
        [HttpGet]
        [Route("Sip-Details/{SipId}/{SipHealthCheckupType}")]
        public async Task<IActionResult> Details([FromRoute] string SipId, [FromRoute] string SipHealthCheckupType)
        {
            var Id = SipId;
            var CheckupType = SipHealthCheckupType;
            return Ok(Id + " - " + CheckupType);
        }
        [HttpGet("Sip-Comment /{SipHealthCheckupDetailID}")]
        public async Task<IActionResult> Comment([FromRoute] long SipHealthCheckupDetailID)
        {
            var SHCDI = SipHealthCheckupDetailID;
            return Ok(SHCDI);
        }
        [HttpGet("Sip-QuestionResponse/healthCheckDetailId/{SipHealthCheckUpDetailId}/healthCheckType/{SipHealthCheckType}/folderId/{SipFolder}")]
        public async Task<IActionResult> SipQuestionResponse([FromRoute] int SipHealthCheckUpDetailId, [FromRoute] string SipHealthCheckType, [FromRoute] string SipFolder)
        {
            return Ok(SipHealthCheckUpDetailId + ' ' + SipHealthCheckType + ' ' + SipFolder);
        }
        [HttpGet("SipEngagementSelection/healthCheckType/{healthCheckType}/questionId/{questionId}")]
        public async Task<IActionResult> SipGet([FromRoute] string healthCheckType, [FromRoute] string questionId)
        {
            return Ok(healthCheckType + " " + questionId);
        }
        #endregion

        #region FromQuery AttributeUsage
        [HttpGet("SearchProducts")]
        public async Task<IActionResult> SearchProducts([FromQuery] string name, [FromQuery] string category)
        {
            return Ok($"Searching for{name}in{category}category");
        }
        #endregion

        #region Combination of [FromRoute] and [FromQuery]
        [HttpGet("{OrderId:int}")]
        public IActionResult GetOrderDetails([FromRoute]int OrderId, [FromQuery]string Status)
        {
            return Ok($"OrderId:{OrderId},Status:{Status}");
        }
        #endregion

        #region Combination Of Complex Binding
        [HttpGet("filter")]
        public IActionResult FilterProductDetails([FromQuery] ProductFilter filter)
        {
            return Ok($"Filtring{filter.Name}with min price{filter.Minprice}");
        }
        #endregion

    }
}
