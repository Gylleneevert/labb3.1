using labb3._1.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace labb3._1
{
    /// <summary>
    /// Interaction logic for CreateQuiz.xaml
    /// </summary>
    public partial class CreateQuiz : Window
    {



        Questions newQuestion = new Questions();

        private int _QuestionID;


        public CreateQuiz()
        {
            InitializeComponent();



        }



        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {


            Quiz newQuiz = new Quiz();

            newQuiz.Title = QuizName.Text;

            List<Questions> questionsList = new List<Questions>();

            foreach (var item in MyListBox.Items)
            {
                if (item is Questions question)
                {
                    questionsList.Add(question);
                }
            }

            StaticHelper.ListOfNewQuestions = questionsList;

            StaticHelper.ListOfNewQuiz.Add(newQuiz);

            QuizName.Text = String.Empty;

            MyListBox.ItemsSource = StaticHelper.ListOfNewQuiz;

            SavedQuiz.Items.Refresh();

            SavedQuiz.ItemsSource = StaticHelper.ListOfNewQuiz;







        }



        private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bildfiler (*.png; *.jpg; *.jpeg; *.gif)|*.png; *.jpg; *.jpeg; *.gif";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;

                byte[] imageBytes = File.ReadAllBytes(selectedImagePath);

                newQuestion.Image = imageBytes;

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(imageBytes);
                bitmapImage.EndInit();
                QuestionImage.Source = bitmapImage;
            }
        }


        private void RemoveQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedQuestion = MyListBox.SelectedIndex;

            if (selectedQuestion >= 0 && selectedQuestion < StaticHelper.ListOfNewQuestions.Count)
            {
                StaticHelper.ListOfNewQuestions.RemoveAt(selectedQuestion);
                MyListBox.ItemsSource = null;
                MyListBox.ItemsSource = StaticHelper.ListOfNewQuestions;
            }
        }


        private void QuestionSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Questions newQuestion = new Questions();
            newQuestion.ID = _QuestionID;
            newQuestion.Category = "";
            newQuestion.Statement = Question.Text;


            newQuestion.Answers = new string[] { Svar1.Text, svar2.Text, svar3.Text, svar4.Text };

            StaticHelper.ListOfNewQuestions.Add(newQuestion);

            MyListBox.ItemsSource = StaticHelper.ListOfNewQuestions;

            MyListBox.Items.Refresh();

            Question.Text = string.Empty;
            Svar1.Text = string.Empty;
            svar2.Text = string.Empty;
            svar3.Text = string.Empty;
            svar4.Text = string.Empty;


            RB0.IsChecked = false;
            RB1.IsChecked = false;
            RB2.IsChecked = false;
            RB3.IsChecked = false;



            MyListBox.ItemsSource = StaticHelper.ListOfNewQuestions;
            QuestionImage.Source = null;
        }

        private void PlayQuizBtn_Click(object sender, RoutedEventArgs e)
        {


            if (SavedQuiz.Items.Count == 0)
            {

                MessageBox.Show("You Need To Create A Game");
            }
            else
            {
                QuizGameRun runGame = new QuizGameRun(StaticHelper.ListOfNewQuestions, StaticHelper.ListOfNewQuiz);
                this.Close();
                runGame.Show();
            }
        }
    }
}






