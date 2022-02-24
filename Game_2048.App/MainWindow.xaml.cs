using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game_2048.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            RandomBlock();
        }

        private void RandomBlock()
        {
            var block = new Button
            {
                Content = "2",
                Background = new SolidColorBrush(Colors.Gold)
            };
            SetPosition(block, 0, 0);
            Board.Children.Add(block);
        }

        private void SetPosition(Button block, int row, int column)
        {
            Grid.SetColumn(block, column);
            Grid.SetRow(block, row);
        }

        private void Top_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void Right_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Bottom_OnClick(object sender, RoutedEventArgs e)
        {
            var blocks = Board.Children;
            foreach (Button block in blocks)
            {
                var row = Grid.GetRow(block);
                row += 3;
                Grid.SetRow(block, row);
            }
            
            RandomBlock();
        }

        private void Left_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}