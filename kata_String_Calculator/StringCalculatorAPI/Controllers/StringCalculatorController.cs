using System.Net;
using Microsoft.AspNetCore.Mvc;
using Model;
using StringCalculatorAPI.Model;
using UseCases;

namespace StringCalculatorAPI.Controllers
{
    [Produces("application/json")]
   
    [ApiController]
    [ProducesResponseType(typeof(StringCalculatorDTO), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestJSONegativesNotAllowed), (int)HttpStatusCode.BadRequest)]    

    public class StringCalculatorController : Controller
    {
        [ApiVersion("1.0")]
        [HttpPost, Route("api/v{version:apiVersion}/[controller]")]
        public ActionResult<StringCalculatorDTO> PostStringCalculator(StringCalculatorRequest modelo)
        {
            SaveAction action = new SaveAction(new StringCalculator());
            StringCalculatorDTO resultado = action.ExecuteAPI(modelo.Numbers);

            if(resultado == null )return BadRequest(new BadRequestJSONegativesNotAllowed());
            return resultado;
        }


        [ApiVersion("2.0")]
        
        [HttpPost, Route("api/v{version:apiVersion}/[controller]")]
        public ActionResult<StringCalculatorDTO> PostStringCalculatorv2(StringCalculatorv2Request modelo)
        {
            SaveAction action = new SaveAction(new StringCalculator());
            //StringCalculatorDTO resFirstSummand = action.ExecuteAPI(modelo.firstSummand);
            StringCalculatorDTO resSecondSummand = action.ExecuteAPI(modelo.secondSummad);

            //if (resFirstSummand == null) return BadRequest(new BadRequestJSONegativesNotAllowed());
            if (resSecondSummand == null) return BadRequest(new BadRequestJSONegativesNotAllowed());
            return resSecondSummand;
        }

    }
}