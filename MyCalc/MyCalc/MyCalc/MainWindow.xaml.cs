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

namespace MyCalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button factBut;
        Button sqrt;
        Button pow;
        Button powUniv;
        Button revBut;
        Button cubeRoot;
        Expander exp;

        public static InputGestureCollection coll;
        // Output Display Constants.
        private const string oneOut = "1";
        private const string twoOut = "2";
        private const string threeOut = "3";
        private const string fourOut = "4";
        private const string fiveOut = "5";
        private const string sixOut = "6";
        private const string sevenOut = "7";
        private const string eightOut = "8";
        private const string nineOut = "9";
        private const string zeroOut = "0";

        public MainWindow()
        {
            InitializeComponent();
            OutputDisplay.Text = "0";

            InputGestureCollection coll = new InputGestureCollection();
            coll.Add(new KeyGesture(Key.A, ModifierKeys.Control, "Ctrl+A"));
        }

        public static RoutedCommand HelpCmd = new RoutedCommand("About", typeof(MainWindow), coll);


        private void OutputDisplay_TextChanged(object sender, TextChangedEventArgs e)
        {
            OutputDisplay.Focus();
        }

        private void itemHelp_Click(object sender, RoutedEventArgs e)
        {
            //  MessageBox.Show("Программа вычисления \nпростых арифметических операций", "Калькулятор", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Программа вычисления \nпростых арифметических операций", "Калькулятор", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Программа вычисления \nпростых арифметических операций", "Калькулятор", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void myGrid_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fEl = e.Source as FrameworkElement;

            switch (fEl.Name)
            {
                case "KeyDate":
                    OutputDisplay.Text = CalcEngine.GetDate();
                    CalcEngine.CalcReset();
                    break;
                case "KeyExit":
                    this.Close();
                    break;
                case "KeyPlus":
                    CalcEngine.CalcOperation(CalcEngine.Operator.eAdd);
                    break;
                case "KeyMinus":
                    CalcEngine.CalcOperation(CalcEngine.Operator.eSubtract);
                    break;
                case "KeySign":
                    OutputDisplay.Text = CalcEngine.CalcSign();
                    break;
                case "KeyDivide":
                    CalcEngine.CalcOperation(CalcEngine.Operator.eDivide);
                    CalcEngine.Result = OutputDisplay.Text;
                    break;
                case "KeyMultiply":
                    CalcEngine.CalcOperation(CalcEngine.Operator.eMultiply);
                    break;
                case "KeyPowUniv":
                    CalcEngine.CalcOperation(CalcEngine.Operator.ePowUniv);
                    break;
                case "KeyClear":
                    OutputDisplay.Text = "0";
                    CalcEngine.Result = OutputDisplay.Text;
                    CalcEngine.CalcReset();
                    break;
                case "KeyPoint":
                    OutputDisplay.Text = CalcEngine.CalcDecimal();
                    break;
                case "KeyEqual":
                    OutputDisplay.Text = CalcEngine.CalcEqual();
                    CalcEngine.Result = OutputDisplay.Text;
                    CalcEngine.CalcReset();
                    break;
                case "KeyZero":
                    OutputDisplay.Text = CalcEngine.CalcNumber(zeroOut);
                    break;
                case "KeyOne":
                    OutputDisplay.Text = CalcEngine.CalcNumber(oneOut);
                    break;
                case "KeyTwo":
                    OutputDisplay.Text = CalcEngine.CalcNumber(twoOut);
                    break;
                case "KeyThree":
                    OutputDisplay.Text = CalcEngine.CalcNumber(threeOut);
                    break;
                case "KeyFour":
                    OutputDisplay.Text = CalcEngine.CalcNumber(fourOut);
                    break;
                case "KeyFive":
                    OutputDisplay.Text = CalcEngine.CalcNumber(fiveOut);
                    break;
                case "KeySix":
                    OutputDisplay.Text = CalcEngine.CalcNumber(sixOut);
                    break;
                case "KeySeven":
                    OutputDisplay.Text = CalcEngine.CalcNumber(sevenOut);
                    break;
                case "KeyEight":
                    OutputDisplay.Text = CalcEngine.CalcNumber(eightOut);
                    break;
                case "KeyNine":
                    OutputDisplay.Text = CalcEngine.CalcNumber(nineOut);
                    break;
            }
            e.Handled = true;
        }

        public void ExpandedView()
        {
            exp = new Expander();
            StackPanel expStack = new StackPanel();
            expStack.Orientation = Orientation.Horizontal;

            factBut = new Button();
            factBut.ToolTip = "Calculate the factorial of a number";
            factBut.Content = "n!";
            factBut.Click += FactBut_Click;

            sqrt = new Button();
            sqrt.ToolTip = "Calculate the square root of a number";
            sqrt.Content = "√";
            sqrt.Click += Sqrt_Click;

            cubeRoot = new Button();
            cubeRoot.ToolTip = "Calculate the cube root of a number";
            cubeRoot.Content = "∛";
            cubeRoot.Click += CubeRoot_Click;

            pow = new Button();
            pow.ToolTip = "Raise the number to the power of 2";
            pow.Content = "x^2";
            pow.Click += Pow_Click;

            powUniv = new Button();
            powUniv.ToolTip = "Raise the number to the power of a number you input next";
            powUniv.Name = "KeyPowUniv";
            powUniv.Content = " x^n ";

            revBut = new Button();
            revBut.ToolTip = "Calculate the reverse of a number";
            revBut.Content = " 1/x ";
            revBut.Click += RevBut_Click;


            var newColumn = new ColumnDefinition { Width = GridLength.Auto };
            var newRow = new RowDefinition { Height = GridLength.Auto };
            myGrid.ColumnDefinitions.Add(newColumn);
            myGrid.RowDefinitions.Add(newRow);

            myGrid.Children.Add(factBut);
            myGrid.Children.Add(sqrt);
            myGrid.Children.Add(pow);
            myGrid.Children.Add(cubeRoot);
            myGrid.Children.Add(exp);

            exp.Header = "More";
            exp.ToolTip = exp.ToolTip = "Press the arrow symbol to find additional functionality";
            exp.Content = expStack;
            expStack.Children.Add(powUniv);
            expStack.Children.Add(revBut);
          
            Grid.SetColumn(factBut, 6);
            Grid.SetRow(factBut, 2);
            Grid.SetColumn(sqrt, 6);
            Grid.SetRow(sqrt, 3);
            Grid.SetColumn(pow, 6);
            Grid.SetRow(pow, 4);
            Grid.SetColumn(cubeRoot, 6);
            Grid.SetRow(cubeRoot, 5);
            Grid.SetColumnSpan(exp, 3);
            Grid.SetRowSpan(exp, 2);
            Grid.SetColumn(exp, 0);
            Grid.SetRow(exp, 5);
        }

        private void CubeRoot_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcCubeRoot();
        }

        private void RevBut_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcReverse();
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcSqrt();
        }

        private void FactBut_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcFactorial();
        }

        private void expandedView_Click(object sender, RoutedEventArgs e)
        {
            this.Width += 50;
            this.Height += 50;
            if (factBut == null && exp == null && sqrt == null && pow == null && powUniv == null)
            {
                ExpandedView();
            }
        }

        private void standardView_Click(object sender, RoutedEventArgs e)
        {
            myGrid.Children.Remove(factBut);
            myGrid.Children.Remove(sqrt);
            myGrid.Children.Remove(exp);
            myGrid.Children.Remove(pow);
            myGrid.Children.Remove(cubeRoot);
            this.Width -= 50;
            this.Height -= 50;
            factBut = null;
            sqrt = null;
            exp = null;
            pow = null;
            revBut = null;
            cubeRoot = null;
            powUniv = null;
        }

        private void Pow_Click(object sender, RoutedEventArgs e)
        {
            OutputDisplay.Text = CalcEngine.CalcPow();
        }
    }

}
