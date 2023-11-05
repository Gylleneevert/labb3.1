using labb3._1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace labb3._1
{

    public class Quiz
    {


        public string Title { get; set; }

        public Quiz()
        {

        }
        public Quiz(string title)
        {
            Title = title;

        }
        public Questions GetRandomQuestion()
        {
            string appDataFolder = StaticHelper.GetJsonFolderPath();
            string jsonFolderPath = Path.Combine(appDataFolder, "Questions.json");

            if (File.Exists(jsonFolderPath))
            {
                string jsonData = File.ReadAllText(jsonFolderPath);
                var jsonQuestion = JsonConvert.DeserializeObject<List<Questions>>(jsonData);


                Random random = new Random();
                int randomIndex = random.Next(jsonQuestion.Count);

                return jsonQuestion[randomIndex];
            }


            return null;

        }
    }
}
