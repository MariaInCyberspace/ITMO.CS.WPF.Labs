using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMVPinWPFattempt
{
    public class Model
    {
        public int a { get; set; }
        public int b { get; set; }
        public int CalcThis()
        {
            return a + b;
        }
    }
}

