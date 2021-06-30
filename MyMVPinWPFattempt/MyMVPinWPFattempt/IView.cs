using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMVPinWPFattempt
{
    public interface IView
    {
        int input_a { get; }

        int input_b { get; }

        int getResult { get; set; }
        void Set_a(int a);
        void Set_b(int b);

        event EventHandler<EventArgs> a_WasSet;

        event EventHandler<EventArgs> b_WasSet;
    }
}
