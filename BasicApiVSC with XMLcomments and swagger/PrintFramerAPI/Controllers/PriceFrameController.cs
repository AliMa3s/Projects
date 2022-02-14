using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace PrintFramerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceFrameController : ControllerBase
    {

        /// <summary>
        /// Returns the price of a frame based on its dimensions.
        /// </summary>
        /// <param name="Height">The height of the frame.</param>
        /// <param name="Width">The width of the frame.</param>
        /// <returns>The price, in dollars, of the picture frame.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/priceframe/5/10
        ///
        /// </remarks>
        /// <response code="200">Returns the cost of the frame in dollars.</response>
        /// <response code="400">If the amount of frame material needed is less than 20 inches or greater than 1000 inches.</response>
        [HttpGet("{Height}/{Width}", Name = nameof(GetPrice))]
        [Produces("text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> GetPrice(string Height, string Width)
        {
            string result;
            result = CalculatePrice(Double.Parse(Height), Double.Parse(Width));
            if (result == "not valid")
            {
                return BadRequest(result);
            }
            else
            {
                return Ok($"The cost of a {Height}x{Width} frame is ${result}");
            }
        }

        private string CalculatePrice(double height, double width)
        {
            double perimeter;
            perimeter = (2 * height) + (2 * width);

            if ((perimeter > 20.00) && (perimeter <= 50.00))
            {
                return "20.00";
            }
            if ((perimeter > 50.00) && (perimeter <= 100.00))
            {
                return "50.00";
            }
            if ((perimeter > 100.00) && (perimeter <= 1000.00))
            {
                return "100.00";
            }
            return "not valid";
        }
    }
}
