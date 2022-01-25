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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public enum op
    {
        addition,
        subtraction,
        multiplication,
        division
    }

    public class simpleMath
    {
        public static double add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double sub(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double divide(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported","Wrong operation",MessageBoxButton.OK,MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
    }
    public partial class MainWindow : Window
    {
        double lastvalue, result;
        op lastop;

        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += AcButton_Click;
            negationButton.Click += NegationButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newvalue;
            if (Double.TryParse(resultLabel.Content.ToString(), out newvalue))
            {
                switch (lastop) 
                {
                    case op.addition:
                        resultLabel.Content = simpleMath.add(lastvalue, newvalue).ToString();
                        break;
                    case op.subtraction:
                        resultLabel.Content = simpleMath.sub(lastvalue, newvalue).ToString();
                        break;
                    case op.multiplication:
                        resultLabel.Content = simpleMath.multiply(lastvalue, newvalue).ToString();
                        break;
                    case op.division:
                        resultLabel.Content = simpleMath.divide(lastvalue, newvalue).ToString();
                        break;
                }
            }

        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double temp;
            if (Double.TryParse(resultLabel.Content.ToString(), out temp))
            {
                temp = temp / 100;
                temp *= lastvalue;
                resultLabel.Content = temp.ToString();
            }
        }

        private void NegationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(resultLabel.Content.ToString(), out lastvalue))
            {
                lastvalue = lastvalue * -1;
                resultLabel.Content = lastvalue.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastvalue = 0;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(resultLabel.Content.ToString(), out lastvalue))
            {
                resultLabel.Content = "0";
            }

            if (sender == additionButton) 
            {
                lastop = op.addition;
            }
            if (sender == subtractionButton)
            {
                lastop = op.subtraction;
            }
            if (sender == multiplicationButton)
            {
                lastop = op.multiplication;
            }
            if (sender == divisonButton)
            {
                lastop = op.division;
            }
        }


        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains(".")) 
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string temp = (sender as Button).Content.ToString();

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{temp}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{temp}";
            }
        }
    }


}
