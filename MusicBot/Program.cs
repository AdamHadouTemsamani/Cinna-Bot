using System.Text.Json;

namespace MusicBot
{
    class Program
    {
        static void Main(string[] args) 
        {
            ReadJsonFile();
        }

        public static void ReadJsonFile()
        {
            
            Token? token;
            using (StreamReader r = new StreamReader("config.json"))
            {
                string json = r.ReadToEnd();
                token = JsonSerializer.Deserialize<Token>(json);
            }

            Console.WriteLine(token?.token);
        }
    }
}
