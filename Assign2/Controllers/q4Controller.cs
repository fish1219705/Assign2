using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assign2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q4Controller : ControllerBase
    {
        /// <summary>
        /// Analyzes the mood expressed in the input message based on emoticons.
        /// The method counts occurrences of happy (:-)) and sad (:-() emoticons to determine the overall mood.
        /// </summary>
        /// <param name="input">The input message containing emoticons.</param>
        /// <returns>
        /// A string indicating the overall mood:
        /// "none" if there are no emoticons,
        /// "unsure" if there are equal numbers of happy and sad emoticons,
        /// "happy" if there are more happy emoticons,
        /// or "sad" if there are more sad emoticons.
        /// </returns>
        /// <example>
        /// GET: api/q4/mood?input=How are you :-) doing :-( today :-)?
        /// -> "happy"
        /// GET: api/q4/mood?input=:)
        /// -> "none"
        /// GET: api/q4/mood?input=This:-(is str:-(:-(ange te:-)xt.
        /// -> "sad"
        /// GET: api/q4/mood?input=choose :-) or :-(
        /// -> "unsure"
        /// </example>
        [HttpGet(template: "mood")]
        public string mood(string input)
        {
            string emo1 = ":-)";
            string emo2 = ":-(";

            int happy = input.Split(emo1).Length - 1;
            int sad = input.Split(emo2).Length - 1;

            if (happy == 0 && sad == 0)
            {
                return "none";
            } else if (happy == sad)
            {
                return "unsure";
            } else if (happy > sad)
            {
                return "happy";
            } else return "sad";
            }
        }
    }

