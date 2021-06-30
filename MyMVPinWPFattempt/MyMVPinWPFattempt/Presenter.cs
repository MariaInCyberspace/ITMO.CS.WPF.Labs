using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMVPinWPFattempt
{
    public class Presenter
    {
        private Model _model = new Model();
        private IView _view;

        public Presenter(IView view)
        {
            _view = view;
            _view.a_WasSet += new EventHandler<EventArgs>(A_whenSet);
            _view.b_WasSet += new EventHandler<EventArgs>(B_whenSet);
        }

        private void B_whenSet(object sender, EventArgs e)
        {
            _model.b = _view.input_b;
            setValues();
            _view.getResult = _model.CalcThis();
        }

        private void A_whenSet(object sender, EventArgs e)
        {
            _model.a = _view.input_a;
            setValues();
        }

        private void setValues()
        {
            _view.Set_a(_model.a);
            _view.Set_b(_model.b);
        }
    }
}
