using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ICalculatorService
    {
        public int Add(int a, int b);
        public int Multiplication(int a, int b);
    }
}
