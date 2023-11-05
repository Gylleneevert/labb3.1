using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace labb3._1
{
    /// <summary>
    /// Interaction logic for QuizGameRun.xaml
    /// </summary>
    public partial class QuizGameRun : Window
    {
        List<Questions> questionList;
        List<Quiz> quizList;
        private int currentQuestionIndex = 1;
        private Button selectedOptionButton = null;


        public QuizGameRun(List<Questions> question, List<Quiz> quiz)
        {
            InitializeComponent();

            questionList = question;
            this.DataContext = questionList[currentQuestionIndex];
            quizList = quiz;

            ShowQuestion(currentQuestionIndex);


        }

        private void ShowQuestion(int questionIndex)
        {
            if (questionIndex >= 0 && questionIndex < questionList.Count)
            {

                Questions currentQuestion = questionList[questionIndex];
                QuestionTextBlock.Text = currentQuestion.Statement;

                if (currentQuestion.Image != null)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = new MemoryStream(currentQuestion.Image);
                    bitmapImage.EndInit();
                    QuestionImage.Source = bitmapImage;
                }
                else
                {

                    QuestionImage.Source = null;
                }


                Option1.Content = currentQuestion.Answers[0];
                Option2.Content = currentQuestion.Answers[1];
                Option3.Content = currentQuestion.Answers[2];
                Option4.Content = currentQuestion.Answers[3];

                Option1.Background = Brushes.Transparent;
                Option2.Background = Brushes.Transparent;
                Option3.Background = Brushes.Transparent;
                Option4.Background = Brushes.Transparent;
            }
        }


        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            Questions question = new Questions();
            Button clickedButton = (Button)sender;
            string selectedAnswer = clickedButton.Content.ToString();

            if (selectedOptionButton != null)
            {

                selectedOptionButton.Background = Brushes.Transparent;
            }

            selectedOptionButton = clickedButton;
            selectedOptionButton.Background = Brushes.Blue;


            if (currentQuestionIndex >= 0 && currentQuestionIndex < questionList.Count)
            {
                Questions currentQuestion = questionList[currentQuestionIndex];
                if (selectedAnswer == currentQuestion.Answers[currentQuestion.CorrectAnswer])
                {


                    currentQuestion.CorrectAnswer++;
                }

            }

            currentQuestionIndex++;

            if (currentQuestionIndex >= questionList.Count)
            {
                double percentege = (double)question.CorrectAnswer / questionList.Count * 100;

                ScoreLabel.Content = "Score" + percentege.ToString("F1") + "%";
            }

        }

        private void NextQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            currentQuestionIndex++;

            if (currentQuestionIndex >= questionList.Count)
            {
                ShowQuestion(currentQuestionIndex);
            }
            else
            {
                MessageBox.Show("End game, score , precentege");
            }
        }
    }
}
