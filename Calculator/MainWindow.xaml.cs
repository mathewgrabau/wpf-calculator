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
    public partial class MainWindow : Window
    {
        double _lastNumber, _result;
        CalculatorOperation _selectedOperation;

        public MainWindow()
        {
            InitializeComponent();

            ClearButton.Click += ClearButton_Click;
            NegativeButton.Click += NegativeButton_Click;
            PercentButton.Click += PercentButton_Click;
            EqualsButton.Click += EqualsButton_Click;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the second value.
            double newNumber;
            if (double.TryParse(ResultLabel.Content.ToString(), out newNumber))
            {
                // Perform the operation now
                switch (_selectedOperation)
                {
                    case CalculatorOperation.Addition:
                        _result = SimpleMath.Add(_lastNumber, newNumber);
                        break;
                    case CalculatorOperation.Subtraction:
                        _result = SimpleMath.Subtract(_lastNumber, newNumber);
                        break;
                    case CalculatorOperation.Multiplication:
                        _result = SimpleMath.Multiply(_lastNumber, newNumber);
                        break;
                    case CalculatorOperation.Division:
                        _result = SimpleMath.Divide(_lastNumber, newNumber);
                        break;
                }

                ResultLabel.Content = _result.ToString();
            }
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out _lastNumber))
            {
                _lastNumber = _lastNumber / 100;
                ResultLabel.Content = _lastNumber.ToString();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out _lastNumber))
            {
                _lastNumber *= -1;
                ResultLabel.Content = _lastNumber.ToString();
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            // Storing the previous number to be able to start the computation now.
            if (double.TryParse(ResultLabel.Content.ToString(), out _lastNumber))
            {
                ResultLabel.Content = "0";  // Clearing it back to receive the next button.
            }

            if (sender == MultiplyButton)
            {
                _selectedOperation = CalculatorOperation.Multiplication;
            }
            if (sender == DivideButton)
            {
                _selectedOperation = CalculatorOperation.Division;
            }
            if (sender == AddButton)
            {
                _selectedOperation = CalculatorOperation.Addition;
            }
            if (sender == SubtractButton)
            {
                _selectedOperation = CalculatorOperation.Subtraction;
            }
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ResultLabel.Content.ToString().Contains("."))
            {
                ResultLabel.Content = $"{ResultLabel.Content}.";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedValue = 0;

            if (sender == OneButton)
                selectedValue = 1;
            if (sender == TwoButton)
            {
                selectedValue = 2;
            }
            if (sender == ThreeButton)
            {
                selectedValue = 3;
            }
            if (sender == FourButton)
            {
                selectedValue = 4;
            }
            if (sender == FiveButton)
            {
                selectedValue = 5;
            }
            if (sender == SixButton)
            {
                selectedValue = 6;
            }
            if (sender == SevenButton)
            {
                selectedValue = 7;
            }
            if (sender == EightButton)
            {
                selectedValue = 8;
            }
            if (sender == NineButton)
            {
                selectedValue = 9;
            }

            if (ResultLabel.Content.ToString() == "0")
            {
                ResultLabel.Content = $"{ selectedValue }";
            }
            else
            {
                ResultLabel.Content = $"{ResultLabel.Content.ToString()}{selectedValue}";
            }
        }
    }

    public enum CalculatorOperation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double value1, double value2)
        {
            return value1 + value2;
        }

        public static double Subtract(double value1, double value2)
        {
            return value1 - value2;
        }

        public static double Multiply(double value1, double value2)
        {
            return value1 * value2;
        }

        public static double Divide(double value1, double value2)
        {
            if (value2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return value1 / value2;
        }
    }
}
