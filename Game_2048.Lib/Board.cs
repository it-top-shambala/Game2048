using System;

namespace Game_2048.Lib
{
    public class Board
    {
        private readonly uint _sizeRow;
        private readonly uint _sizeCol;

        //private readonly Block[,] _board;
        public readonly int?[,] board;

        private const int Count = 2;

        public Board(uint size)
        {
            _sizeRow = size;
            _sizeCol = size;
            //_board = new Block[_sizeRow, _sizeCol];
            board = new int?[_sizeRow, _sizeCol];
            InitBoard();
        }

        private void InitBoard()
        {
            for (int i = 0; i < _sizeRow; i++)
            {
                for (int j = 0; j < _sizeCol; j++)
                {
                    board[i, j] = null;
                }
            }
        }

        private bool IsFull()
        {
            for (int i = 0; i < _sizeRow; i++)
            {
                for (int j = 0; j < _sizeCol; j++)
                {
                    if (board[i, j] is null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsNull(int x, int y) => board[x, y] is null;

        private void InsertBlock(int x, int y, int count)
        {
            /*_board[x, y] = new Block
            {
                Count = count,
                //X = x,
                //Y = y
            };*/
            board[x, y] = count;
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
                for (int k = (int)_sizeCol - 2; k >= 0; k--)
                {
                    for (int j = k; j < _sizeCol - 1; j++)
                    {
                        if (IsNull(i, j + 1))
                        {
                            board[i, j + 1] = board[i, j];
                            board[i, j] = null;
                        }
                        else if (board[i, j] == board[i, j + 1])
                        {
                            board[i, j + 1] += board[i, j];
                            board[i, j] = null;
                        }
                    }
                }
            }
        }
    }
}