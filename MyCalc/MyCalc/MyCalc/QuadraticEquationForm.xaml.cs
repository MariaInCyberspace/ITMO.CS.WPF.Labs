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
using System.Windows.Shapes;

namespace MyCalc
{
    /// <summary>
    /// Логика взаимодействия для QuadraticEquationForm.xaml
    /// </summary>
    public partial class QuadraticEquationForm : Window
    {
        MainWindow main = null;
        public QuadraticEquationForm()
        {
            InitializeComponent();
        }


        private void submitCoef_Click(object sender, RoutedEventArgs e)
        {
            main = Owner as MainWindow;
            double a = Convert.ToDouble(textBox_a.Text);
            double b = Convert.ToDouble(textBox_b.Text);
            double c = Convert.ToDouble(textBox_c.Text);
            main.OutputDisplay.Text = CalcEngine.CalcQuadEq(a, b, c);
            textBox_a.Text = string.Empty;
            textBox_b.Text = string.Empty;
            textBox_c.Text = string.Empty;
            this.Hide();
        }
    }
}
