using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // GET api/values/GetFiveRandomNumbers
        [HttpGet("GetFiveRandomNumbers")]
        public List<int> GetFiveRandomNumbers()
        {
            var numbers = new List<int>();
            var rnd = new Random();
            int count = 0;

            while (count < 5)
            {
                int newNum = rnd.Next(1, 21);

                if (!numbers.Contains(newNum))
                {
                    numbers.Add(newNum);
                    count++;
                }
            }
            return numbers;
        }

        // GET api/values/MostRepetativeWord             task no. 6
        [HttpGet("MostRepetativeWord")]
        public int MostRepetativeWord(string s)
        {
            string[] words = s.Split(' ');
            int count = 1, tempCount;
            string frequentWord = words[0];
            string tempWord;
            for (int i = 0; i < words.Length - 1; i++)
            {
                tempWord = words[i];
                tempCount = 0;
                for (int j = 0; j < words.Length - 1; j++)
                {
                    if ((string.Compare(tempWord, words[j])) == 0)
                        tempCount++;
                }
                if (tempCount > count)
                {
                    frequentWord = tempWord;
                    count = tempCount;
                }
            }
            return count;
        }

        // GET api/values/ReverseString                  task no. 11
        [HttpGet("ReverseString")]
        public string ReverseString(string s)
        {
            char[] charArr = s.ToCharArray();
                     
            int length = charArr.Length;
            char[] newArr = new char[length];
            for (int i = length - 1; i >= 0 ; i--)
            {
                int currindex = length - (i+1);
                newArr[currindex] = charArr[i];
                
            }
            string newstr = new string(newArr);
            return newstr;
        }

        // GET api/values/shorterString              task no. 12
        [HttpGet("shorterString")]
        public string shorterString(string s)
        {
            char[] charArr = s.ToCharArray();

            int length = charArr.Length;
            char[] newArr = new char[length - 2];
            for (int i = 1; i < length-1; i++)
            {
                int currindex = (i - 1);
                newArr[currindex] = charArr[i];

            }
            string newstr = new string(newArr);
            return newstr;
        }

        // GET api/values/twoNumCalculator          task no. 13
        [HttpGet("twoNumCalculator")]
        public string twoNumCalculator(double num1 , double num2)
        {
            double[] resultsArr = { num1 + num2, num1 - num2, num1 * num2, num1 / num2 };
            string[] tempArr = new string[5];
            
            
            for (int i = 0; i < resultsArr.Length ; i++)
            {
                tempArr[i] = resultsArr[i].ToString("N2");
            }

            string newstr = string.Join(",", tempArr);
            return newstr;
        }

        // GET api/values/findMaxNum          task no. 15
        [HttpGet("findMaxNum")]
        public int findMaxNum(int num1, int num2, int num3)
        {
            int max = num1;
            if(num2 > max)
            {
                max = num2;
                if(num3 > max)
                {
                    max = num3;
                }
            }
            return max;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
