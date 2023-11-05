namespace labb3._1
{
    public class Questions
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public string Statement { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }
        public byte[] Image { get; set; }

        public Questions(byte[] image)
        {
            Image = image;
        }

        public Questions()
        {

        }
        public Questions(int id, string category, string statement, int correctAnswers, string[] answers)
        {
            ID = id;
            Category = category;
            Statement = statement;
            CorrectAnswer = correctAnswers;
            Answers = answers;

        }








    }


}

