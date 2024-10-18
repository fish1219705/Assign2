using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assign2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        /// <summary>
        /// Calculates the final score for the Delivedroid game based on deliveries and collisions.
        /// The score is computed using the following rules:
        /// - Gain 50 points for each package delivered.
        /// - Lose 10 points for each collision with an obstacle.
        /// - Earn a bonus of 500 points if the number of packages delivered exceeds the number of collisions.
        /// </summary>
        /// <param name="Collisions">The number of collisions with obstacles.</param>
        /// <param name="Deliveries">The number of packages successfully delivered.</param>
        /// <returns>
        /// An integer representing the final score after all calculations, including the bonus if applicable.
        /// </returns>
        /// <example>
        /// POST: /api/J1/Delievdroid
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: Collisions=2&Deliveries=5
        /// -> 730
        /// </example>
        [HttpPost(template:"Delievdroid")]
        [Consumes("application/x-www-form-urlencoded")]
        public int Delievdroid([FromForm]int Collisions, [FromForm]int Deliveries)
        {
            int del = 50 * Deliveries;
            int col = -10 * Collisions;
            int bonus;
            if (Deliveries > Collisions)
            {
                bonus = 500;
            }
            else
            {
                bonus = 0;
            }
            int final = del + col + bonus;
            return final;
        }
    }
}
