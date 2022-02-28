using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Game_2048.Lib;

namespace Game_2048.App
{
    public partial class MainWindow : Window
    {
        private Board _board;
        private Dictionary<int, SolidColorBrush> _colorBrushes;
        public MainWindow()
        {
            InitializeComponent();
            _board = new Board(4);
            _colorBrushes = new Dictionary<int, SolidColorBrush>
            {
                { 2, new SolidColorBrush(Colors.Yellow) },
                { 4, new SolidColorBrush(Colors.Orange) },
                { 8, new SolidColorBrush(Colors.Red) }
            };

            _board.RandomInsertBlock();
            ShowBoard();
        }

        private void ShowBoard()
        {
            var row = 4;
            var col = 4;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    var val = 0;
                    var block = new Button();
                    Grid.SetRow(block, i);
                    Grid.SetColumn(block, j);
                    if (!_board.IsNull(i, j))
                    {
                        val = (int)_board.board[i, j];
                        block.Content = val.ToString();
                        block.Style = (Style)this.Resources[val.ToString()];
                    }
                    Board.Children.Add(block);
                }
            }
        }
        
        private void Top_OnClick(object sender, RoutedEventArgs e)
        { }

        private void Right_OnClick(object sender, RoutedEventArgs e)
        {
            _board.MoveToRight();
            _board.RandomInsertBlock();
            ShowBoard();
        }

        private void Bottom_OnClick(object sender, RoutedEventArgs e)
        { }

        private void Left_OnClick(object sender, RoutedEventArgs e)
        { }
    }
}