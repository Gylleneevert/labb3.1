using labb3._1.Models;
using System.Windows;

namespace labb3._1.Views
{
    /// <summary>
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : Window
    {

        Quiz newQuiz = new Quiz();

        public CategoryView()
        {
            InitializeComponent();

            this.DataContext = newQuiz;
            CatBox.ItemsSource = StaticHelper.QuestCat;

        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
