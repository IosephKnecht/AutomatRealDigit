using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Automat
    {
        private int str_num = 0;

        private readonly int[,] transition_matrix = new int[,]
        {
            { 1,2,4,-1 }, //S
            {1,-1,3,5}, //[A]
            { 1,-1,4,-1 }, //B
            {3,-1,-1,5 }, //[C]
            { 3,-1,-1,-1 }, //D
            {-1,6,-1,-1 }, //E
            {7,-1,-1,-1 }, //F
            {7,-1,-1,-1 },//[G]
        };

        private readonly int[] ExitNode = new int[] { 1, 3, 7 };

        public string input { get; set; }

        private int ReturnNum(char sym)
        {
            char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] operators = new char[] { '+', '-' };
            if (digits.Contains(sym)) return 0;
            else
            if (operators.Contains(sym)) return 1;
            else
            if (sym == ',') return 2;
            else
            if (sym == 'E') return 3;
            return -2;
        }

        private void cash(int ret_num)
        {
            try
            {
                str_num = transition_matrix[str_num, ret_num];
            }
            catch { str_num = -1; }
        }

        public bool Test()
        {
            int length = 0;
            foreach (char sym in input)
            {
                int ret_num = ReturnNum(sym);
                cash(ret_num);
                if (str_num < 0) return false;
                if (input.Length == length)
                    if (!ExitNode.Contains(str_num)) return false;
                length++;
            }

            return true;
        }
    }
}
