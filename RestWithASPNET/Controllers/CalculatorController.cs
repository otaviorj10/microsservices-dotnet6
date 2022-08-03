using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumer}")]
        public IActionResult Sum(string firstNumber, string secondNumer)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumer))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumer);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("subtract/{firstNumber}/{secondNumer}")]
        public IActionResult Subctraction(string firstNumber, string secondNumer)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumer))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumer);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumer}")]
        public IActionResult Multiplication(string firstNumber, string secondNumer)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumer))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumer);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("divide/{firstNumber}/{secondNumer}")]
        public IActionResult Division(string firstNumber, string secondNumer)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumer))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumer);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("average/{firstNumber}/{secondNumer}")]
        public IActionResult Average(string firstNumber, string secondNumer)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumer))
            {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumer) ) /2;
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }


        [HttpGet("squareRoot/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {

            if (IsNumeric(firstNumber))
            {
                double sqrt = Math.Sqrt(double.Parse(firstNumber));
                var sum = (ConvertToDecimal(sqrt.ToString()));
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }


        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }


    }
}
