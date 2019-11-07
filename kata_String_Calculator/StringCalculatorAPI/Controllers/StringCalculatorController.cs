using System.Net;
using Microsoft.AspNetCore.Mvc;
using Model;
using StringCalculatorAPI.Model;
using UseCases;

namespace StringCalculatorAPI.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    [ProducesResponseType(typeof(StringCalculatorDTO), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestJSONegativesNotAllowed), (int)HttpStatusCode.BadRequest)]    

    public class StringCalculatorController : Controller
    {
        [MapToApiVersion("1.0")]
        [MapToApiVersion("2.0")]
        [Route("api/v{version:apiVersion}")]
        [HttpPost]
        public ActionResult<StringCalculatorDTO> PostStringCalculator(StringCalculatorRequest modelo)
        {
            SaveAction action = new SaveAction(new StringCalculator());
            StringCalculatorDTO resultado = action.ExecuteAPI(modelo.Numbers);

            if(resultado == null )return BadRequest(new BadRequestJSONegativesNotAllowed());
            return resultado;
        }


        [MapToApiVersion("2.0")]
        [Route("api/v{version:apiVersion}/[controller]")]
        [HttpPost]
        public ActionResult<StringCalculatorDTOV2> PostStringCalculatorv2(StringCalculatorRequestV2 modelo)
        {
            SaveAction action = new SaveAction(new StringCalculator());
            StringCalculatorDTO first = action.ExecuteAPI(modelo.firstSummand);
            StringCalculatorDTO second = action.ExecuteAPI(modelo.secondSummand);
            StringCalculatorDTOV2 result = new StringCalculatorDTOV2(){ FirstResult = first, SecondResult = second};
            if (first == null || second == null) return BadRequest(new BadRequestJSONegativesNotAllowed());
            return result;
        }

    }


}