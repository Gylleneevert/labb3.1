using labb3._1.Models;
using labb3._1.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace labb3._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Quiz newQuiz = new Quiz();

        public MainWindow()
        {
            InitializeComponent();
            
            StaticHelper.GetJsonFolderPath();
            StaticHelper.CategoryQuestions();
            StaticHelper.LoadJsonData();
        }

        private void SetupQuizBtn_Click(object sender, RoutedEventArgs e)
        {
            SetupQuiz setUpQuiz = new SetupQuiz();
            this.Close();
            setUpQuiz.Show();

        }

        private void PlayQuizBtn(object sender, RoutedEventArgs e)
        {
            PlayQuiz playQuiz = new PlayQuiz();
            
            this.Close();
            playQuiz.Show();
        }

        
    }
}
