using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyMVPinWPFattempt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public event EventHandler<EventArgs> a_WasSet;
        public event EventHandler<EventArgs> b_WasSet;

        public MainWindow()
        {
            InitializeComponent();
            Presenter p = new Presenter(this);
            txtBox1.TextChanged += new TextChangedEventHandler(txtBox1_TextChanged);
            txtBox2.TextChanged += new TextChangedEventHandler(txtBox2_TextChanged);
        }

        private void txtBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (a_WasSet != null)
            {
                this.a_WasSet(this, e);
            }
        }

        private void txtBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (b_WasSet != null)
            {
                this.b_WasSet(this, e);
                txtBox3.Text = this.getResult.ToString();
            }
        }

        public void Set_a(int a)
        {
            txtBox1.Text = this.input_a.ToString();
        }

        public void Set_b(int b)
        {
            txtBox2.Text = this.input_b.ToString();
        }

        public int input_a
        {
            get { return Convert.ToInt32(this.txtBox1.Text); }
        }

        public int input_b
        {
            get { return Convert.ToInt32(txtBox2.Text); }
        }

        public int getResult
        {
            get; set;
        }
    }

}
