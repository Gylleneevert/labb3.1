using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace labb3._1.Models
{
    public static class StaticHelper
    {
        public static List<string> QuestCat = new List<string>();
        public static List<Questions> jsonQuestions = new List<Questions>();
        public static List<string> ListOfStatements = new List<string>();
        public static List<Questions?> ListOfNewQuestions = new List<Questions>();
        public static List<Quiz> ListOfNewQuiz = new List<Quiz>();




        public static void CategoryQuestions()
        {
            string folderName = "AAQuestion";
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string jsonFolder = Path.Combine(appDataFolder, folderName);

            AddQuestion(1, "Fotboll", "Vilket land vann fotbolls-VM år 2018?", 3, new string[] { "A) Brasilien", "B) Argentina", "C) Frankrike", "D) Tyskland" });
            AddQuestion(2, "Fotboll", "Vem är världens mest kända fotbollsspelare?", 2, new string[] { "A) Cristiano Ronaldo", "B) Lionel Messi", "C) Neymar", "D) Zlatan Ibrahimović" });
            AddQuestion(3, "Fotboll", "Vilken fotbollsklubb är känd som 'The Red Devils'?", 2, new string[] { "A) FC Barcelona", "B) Manchester United", "C) Real Madrid", "D) Bayern München" });
            AddQuestion(4, "Fotboll", "Vilken spelare har rekordet för flest antal mål i en enda fotbollssäsong?", 1, new string[] { "A) Lionel Messi", "B) Cristiano Ronaldo", "C) Pelé", "D) Diego Maradona" });
            AddQuestion(5, "Fotboll", "Vilket land är känt för att ha skapat fotbollsspelet 'säkerhet' (tiki-taka)?", 1, new string[] { "A) Spanien", "B) Italien", "C) Tyskland", "D) Brasilien" });


            AddQuestion(6, "Geografi", "Vilket är världens största land till yta?", 2, new string[] { "A) Kina", "B) USA", "C) Ryssland", "D) Kanada" });
            AddQuestion(7, "Geografi", "Vad är huvudstaden i Frankrike?", 3, new string[] { "A) London", "B) Berlin", "C) Madrid", "D) Paris" });
            AddQuestion(8, "Geografi", "Vilket land är känt som 'Soluppgårdens land'?", 3, new string[] { "A) Egypten", "B) Grekland", "C) Japan", "D) Australien" });
            AddQuestion(9, "Geografi", "Vad är den längsta floden i världen?", 1, new string[] { "A) Nilen", "B) Amazonas", "C) Mississippi", "D) Yangtze" });
            AddQuestion(10, "Geografi", "Vilket land har flest invånare?", 1, new string[] { "A) Indien", "B) Kina", "C) USA", "D) Brasilien" });


            AddQuestion(11, "Matematik", "Vad är kvadratroten av 25?", 3, new string[] { "A) 3", "B) 4", "C) 5", "D) 6" });
            AddQuestion(12, "Matematik", "Hur många grader är en rät vinkel?", 2, new string[] { "A) 45 grader", "B) 90 grader", "C) 180 grader", "D) 360 grader" });
            AddQuestion(13, "Matematik", "Vilket tal är en primtalsfaktor i 18?", 2, new string[] { "A) 2", "B) 3", "C) 6", "D) 9" });
            AddQuestion(14, "Matematik", "Vad är 7 x 9?", 1, new string[] { "A) 56", "B) 63", "C) 72", "D) 81" });
            AddQuestion(15, "Matematik", "Om x + 3 = 10, vad är värdet av x?", 1, new string[] { "A) 3", "B) 7", "C) 10", "D) 13" });


            AddQuestion(16, "Konsumtion", "Vilket företag tillverkar iPhone-smartphones?", 3, new string[] { "A) Samsung", "B) Google", "C) Apple", "D) Microsoft" });
            AddQuestion(17, "Konsumtion", "Vilken dryck är känd som 'världens kolsyrade dryck'?", 1, new string[] { "A) Coca-Cola", "B) Pepsi", "C) Sprite", "D) Fanta" });
            AddQuestion(18, "Konsumtion", "Vad är den mest konsumerade typen av mat i världen?", 1, new string[] { "A) Ris", "B) Potatis", "C) Pasta", "D) Bröd" });
            AddQuestion(19, "Konsumtion", "Vilken webbplats är känd för att vara 'världens största online-auktion'?", 1, new string[] { "A) eBay", "B) Amazon", "C) Alibaba", "D) Craigslist" });
            AddQuestion(20, "Konsumtion", "Vilket företag är känd för sina färgglada byggklossar och leksaker?", 1, new string[] { "A) LEGO", "B) Mattel", "C) Hasbro", "D) Fisher-Price" });


            SaveQuizData();
        }




        public static void AddQuestion(int id, string category, string statement, int correctAnswer, params string[] answers)
        {
            if (jsonQuestions == null)
            {
                jsonQuestions = new List<Questions>();
            }
            if (!QuestCat.Contains(category))
            {
                QuestCat.Add(category);
            }
            if (!ListOfStatements.Contains(statement))
            {
                ListOfStatements.Add(statement);
            }
            jsonQuestions.Add(new Questions(id, category, statement, correctAnswer, answers));

        }
        public static void SaveQuizData()
        {


            string appDataFolder = GetJsonFolderPath();
            string jsonFilePath = Path.Combine(appDataFolder, "Questions.json");

            string jsonData = JsonConvert.SerializeObject(jsonQuestions);
            File.WriteAllText(jsonFilePath, jsonData);

        }

        public static void RemoveQuestion(int index)
        {

            if (index >= 0 && index < jsonQuestions.Count)
            {
                jsonQuestions.RemoveAt(index);
            }
        }

        public static string GetJsonFolderPath()
        {
            string folderName = "AAQuestion";
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string jsonFolder = Path.Combine(appDataFolder, folderName);

            if (!Directory.Exists(jsonFolder))
            {
                Directory.CreateDirectory(jsonFolder);
                CategoryQuestions();
            }

            return jsonFolder;

        }
        public static List<Questions> LoadJsonData()
        {



            string appDataFolder = GetJsonFolderPath();
            string jsonFilePath = Path.Combine(appDataFolder, "Questions.json");

            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                return JsonConvert.DeserializeObject<List<Questions>>(jsonData);
            }
            else
            {

                return new List<Questions>();
            }
        }


    }
}

