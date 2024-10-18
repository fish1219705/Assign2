using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assign2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q5Controller : ControllerBase
    {

        /// <summary>
        /// Determines the score required for the bronze level and counts how many participants achieved that score.
        /// The bronze level is awarded to all participants who achieve the third highest score.
        /// </summary>
        /// <param name="scores">A comma-separated string of participant scores.</param>
        /// <returns>A string indicating the bronze score and the count of participants who achieved it.</returns>
        /// <example>
        /// GET: api/q5/bronze?scores=70,62,58,73
        /// -> "The score required for bronze level is 62 and 1 participant achieved this score."
        /// GET: api/q5/bronze?scores=75,70,60,70,70,60,75,70
        /// -> "The score required for bronze level is 60 and 2 participant achieved this score."
        /// </example>
        [HttpGet(template: "bronze")]
        public string bronze(string scores)
        {
            string[] scoreStrings = scores.Split(',');
            int[] scoreArray = new int[scoreStrings.Length];
            int scoreIndex = 0;

            foreach (string scoreString in scoreStrings)
            {
                int score;
                if (int.TryParse(scoreString, out score))
                {
                    scoreArray[scoreIndex] = score;
                    scoreIndex++;
                }
            }

            int[] validScores = new int[scoreIndex];
            for (int i = 0; i < scoreIndex; i++)
            {
                validScores[i] = scoreArray[i]; 
            }

            int[] uniqueScores = validScores.Distinct().OrderByDescending(s => s).ToArray();
            if (uniqueScores.Length < 3)
            {
                return "Not enough unique scores to determine the bronze level.";
            }

            int bronzeScore = uniqueScores[2];
            int participantsWithBronze = validScores.Count(s => s == bronzeScore);

            return "The score required for bronze level is " + bronzeScore + " and " + participantsWithBronze + " participant achieved this score.";
            
        }

                
        
    }
    
}





