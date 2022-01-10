using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lesson_1._Calculator.Classes
{
    [Serializable]
    public class Token
    {
        public string Id { get; set; }
        public string TrueToken { get; set; }

        public Token(string id, string token)
        {
            Id = id;
            TrueToken = token;
        }

        public void AddToken(string id, string trueToken)
        {
            if (File.Exists("saveTokens.json"))
            {
                string tmp = File.ReadAllText("saveTokens.json");
                //List<Token> tokens = JsonSerializer.Deserialize(tmp);
            }

            string str = JsonSerializer.Serialize(new Token(id, trueToken));
            //File.WriteAllText(fileName, str);
        }
    }
}
