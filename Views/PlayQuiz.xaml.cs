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
using System.Windows.Shapes;
using labb3._1.Views;


namespace labb3._1.Views
{
    /// <summary>
    /// Interaction logic for PlayQuiz.xaml
    /// </summary>
    public partial class PlayQuiz : Window
    {
        Quiz currentQuiz { get; set; } =  new Quiz();
        public PlayQuiz()
        {
            InitializeComponent();
        }

        private void PlayRndmQuizBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CtgryQuizBtn_Click(object sender, RoutedEventArgs e)
        {
            CategoryView categoryView = new CategoryView();
            this.Close();
            categoryView.Show();
        }

        private void backToMainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
