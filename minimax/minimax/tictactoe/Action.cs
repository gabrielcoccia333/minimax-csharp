using System;
using System.Collections.Generic;
using System.Text;

namespace minimax.tictactoe
{
    class Action
    {
        public int row;
        public int col;
        public Action(int Row, int Col)
        {
            this.row = Row;
            this.col = Col;
        }
        public int Row
        {
            get { return row; }
        }
        public int Col
        {
            get { return col; }
        }
    }
}
