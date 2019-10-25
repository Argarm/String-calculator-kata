using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controlador;
using kata_String_Calculator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StringCalculatorAPI.Model
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringCalculatorController : ControllerBase
    {
        [HttpPost]
        public ActionResult<StringCalculatorDTO> PostStringCalculator(StringCalculatorModel modelo)
        {
            var badRequestMessage = "{\"type\": \"Negatives not allowed\",\"title\": \"Bad Request\",\"status\": 400}";
            SaveAction action = new SaveAction(new StringCalculator());
            StringCalculatorDTO resultado = action.ExecuteAPI(modelo.Numbers);

            if(resultado == null )return BadRequest(badRequestMessage);
            return resultado;
        }


    }
}