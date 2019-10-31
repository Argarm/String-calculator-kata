using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Model;
using StringCalculatorAPI.Model;
using UseCases;

namespace StringCalculatorAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(StringCalculatorDTO), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestJSONegativesNotAllowed), (int)HttpStatusCode.BadRequest)]

    public class StringCalculatorController : ControllerBase
    {
        /// <summary>
        /// Suma los numeros de una string pasada.
        /// </summary>
        /// <remarks>
        /// Sample of usage:
        ///
        ///     POST /api/StringCalculator
        ///     {
        ///        "Numbers": "1,2,3"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        public ActionResult<StringCalculatorDTO> PostStringCalculator(StringCalculatorRequest modelo)
        {
            SaveAction action = new SaveAction(new StringCalculator());
            StringCalculatorDTO resultado = action.ExecuteAPI(modelo.Numbers);

            if(resultado == null )return BadRequest(new BadRequestJSONegativesNotAllowed());
            return resultado;
        }


    }
}