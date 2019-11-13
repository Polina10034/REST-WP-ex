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

        // GET api/values/MostRepetativeWord
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

        // GET api/values/ReverseString
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

        // GET api/values/shorterString
        [HttpGet("shorterString")]
        public string shorterString(string s)
        {
            char[] charArr = s.ToCharArray();

            int length = charArr.Length;
            char[] newArr = new char[length - 1];
            for (int i = 1; i < length; i++)
            {
                int currindex = (i - 1);
                newArr[currindex] = charArr[i];

            }
            string newstr = new string(newArr);
            return newstr;
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
