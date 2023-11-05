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

namespace labb3._1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SetupQuiz : Window
    {
        public SetupQuiz()
        {
            InitializeComponent();
        }

        private void BackToMainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }

        private void createQuiz_Click(object sender, RoutedEventArgs e)
        {
            CreateQuiz createQuiz = new CreateQuiz();
            this.Close();
            createQuiz.ShowDialog();
        }

        private void EditQuiz_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
