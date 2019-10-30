using controlador;
using Model;
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
            SaveAction action = new SaveAction(new StringCalculator());
            StringCalculatorDTO resultado = action.ExecuteAPI(modelo.Numbers);

            if(resultado == null )return BadRequest(new BadRequestJSONegativesNotAllowed());
            return resultado;
        }


    }
}