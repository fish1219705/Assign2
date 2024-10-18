using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assign2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        /// <summary>
        /// Calculates the total spiciness of Ron's chili by summing up the Scoville Heat Units (SHU) of each pepper type added.
        /// 
        /// The SHU values for each type of pepper are:
        /// - Poblano: 1,500 SHU
        /// - Mirasol: 6,000 SHU
        /// - Serrano: 15,500 SHU
        /// - Cayenne: 40,000 SHU
        /// - Thai: 75,000 SHU
        /// - Habanero: 125,000 SHU
        /// 
        /// The method takes a comma-separated string of pepper names as input, determines the SHU for each type, and returns the total SHU added to Ron's chili.
        /// </summary>
        /// <param name="Ingredients">A comma-separated string containing the names of peppers (e.g., "Poblano,Serrano,Habanero").</param>
        /// <returns>
        /// The total spiciness (in SHU) of Ron's chili after all the listed peppers are added.
        /// </returns>
        /// <example>
        /// GET: /api/J2/ChiliPeppers?Ingredients=Poblano,Cayenne,Thai,Poblano
        /// -> 118000
        /// </example>
        [HttpGet(template:"ChiliPeppers")]
        public int ChiliPeppers(string Ingredients)
        {

            string[] subs = Ingredients.Split(",");
            int Poblano = 0;
            int Mirasol = 0;
            int Serrano = 0;
            int Cayenne = 0;
            int Thai = 0;
            int Habanero = 0;
            foreach (string s in subs)
            {
                if (s == "Poblano")
                {
                    Poblano++;
                } else if  (s == "Mirasol")
                {
                    Mirasol++;
                }  else if (s == "Serrano")
                {
                    Serrano++;
                } else if (s == "Cayenne")
                {
                    Cayenne++;
                }else if (s == "Thai")
                {
                    Thai++;
                }else if (s == "Habanero")
                {
                    Habanero++;
                }

            }
            int total = Poblano * 1500 + Mirasol * 6000 + Serrano * 15500 + Cayenne * 40000 + Thai * 75000 + Habanero * 125000;
            return total;

        }
    }
}