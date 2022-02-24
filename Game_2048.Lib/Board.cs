using System;

namespace Game_2048.Lib
{
    public class Board
    {
        private readonly uint _sizeRow;
        private readonly uint _sizeCol;

        //private readonly Block[,] _board;
        private readonly int?[,] _board;

        private const int Count = 2;

        public Board(uint size)
        {
            _sizeRow = size;
            _sizeCol = size;
            //_board = new Block[_sizeRow, _sizeCol];
            _board = new int?[_sizeRow, _sizeCol];
            InitBoard();
        }

        private void InitBoard()
        {
            for (int i = 0; i < _sizeRow; i++)
            {
                for (int j = 0; j < _sizeCol; j++)
                {
                    _board[i, j] = null;
                }
            }
        }

        private bool IsFull()
        {
            for (int i = 0; i < _sizeRow; i++)
            {
                for (int j = 0; j < _sizeCol; j++)
                {
                    if (_board[i, j] is null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsNull(int x, int y) => _board[x, y] is null;

        private void InsertBlock(int x, int y, int count)
        {
            /*_board[x, y] = new Block
            {
                Count = count,
                //X = x,
                //Y = y
            };*/
            _board[x, y] = count;
        }

        public void RandomInsertBlock()
        {
            if (IsFull()) return;

            var random = new Random();
            int randX;
            int randY;
            do
            {
                randX = random.Next((int)_sizeRow);
                randY = random.Next((int)_sizeCol);
            } while (!IsNull(randX, randY));

            InsertBlock(randX, randY, Count);
        }

        public void MoveToRight()
        {
            for (int i = 0; i < _sizeRow; i++)
            {
                for (int k = (int)_sizeCol - 2; k > 0; k--)
                {
                    for (int j = k; j < _sizeCol - 1; j++)
                    {
                        if (IsNull(i, j + 1))
                        {
                            _board[i, j + 1] = _board[i, j];
                            _board[i, j] = null;
                        }
                        else if (_board[i, j] == _board[i, j + 1])
                        {
                            _board[i, j + 1] += _board[i, j];
                            _board[i, j] = null;
                        }
                    }
                }
            }
        }
    }
}