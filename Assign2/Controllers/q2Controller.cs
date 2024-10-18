using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assign2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q2Controller : ControllerBase
    {
        /// <summary>
        /// Calculates the number of leftover cupcakes after distributing one cupcake to each student in the class.
        /// Each student should receive one cupcake, and the total number of cupcakes is derived from the number of 
        /// regular and small boxes provided.
        /// </summary>
        /// <param name="regularbox">The number of regular boxes, each containing 8 cupcakes.</param>
        /// <param name="smallbox">The number of small boxes, each containing 3 cupcakes.</param>
        /// <returns>A message indicating either the number of leftover cupcakes or if there are not enough cupcakes.</returns>
        /// <example>
        /// POST: /api/q2/ccleft
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: regularbox=3&smallbox=2
        /// -> "There are 2 cupcakes left"
        /// </example>
        [HttpPost(template: "ccleft")]
        [Consumes("application/x-www-form-urlencoded")]
        public string ccleft([FromForm] int regularbox, [FromForm] int smallbox)
        {
            if (regularbox >= 0 && smallbox >= 0)
            {
                int regcake = 8 * regularbox;
                int smacake = 3 * smallbox;
                int total = regcake + smacake;
                int left = total - 28;
                if (left < 0)
                {
                    return "not enough";
                }
                else
                {

                    return "There are " + left + " cupcakes left";
                }
            }
            else
            {
                return "not valid number for boxes";
            }
        }
    }
}
