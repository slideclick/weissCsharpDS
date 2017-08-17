using System;
using System.Collections.Generic;
using System.Linq;

namespace Evaluate
{
    class Program
    {
        static void Main(string[] args)
        {
            string testExpress = "(1+((2+3)*(4*5)))";
            Console.WriteLine(Evaluate(testExpress));
        }

        //DijkStra
        static double Evaluate(string express)
        {
            var expressChars = express.ToArray<char>();
            Stack<char> ops = new Stack<char>();
            Stack<double> vals = new Stack<double>();
            if (express.Length > 0)
            {
                foreach (var opt in expressChars)
                {
                    switch (opt)
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            ops.Push(opt);
                            break;
                        case ')':
                            var op = ops.Pop();
                            var v = vals.Pop();
                            switch (op)
                            {
                                case '+':
                                    v += vals.Pop();
                                    break;
                                case '-':
                                    v = vals.Pop() - v;
                                    break;
                                case '*':
                                    v *= vals.Pop();
                                    break;
                                case '/':
                                    v = vals.Pop() / v;
                                    break;
                            }
                            vals.Push(v);
                            break;
                        case ' ':
                        case '(':
                            break;
                        default:
                            vals.Push(double.Parse(opt.ToString()));
                            break;
                    }
                }
                return vals.Pop();

            }
            return double.MaxValue;
        }
    }
}