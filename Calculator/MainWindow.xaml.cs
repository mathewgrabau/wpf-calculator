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

        private void SevenButton_Click(object sender, RoutedEventArgs e)
        {
            if (ResultLabel.Content.ToString() == "0")
            {
                ResultLabel.Content = "7";
            }
            else
            {
                ResultLabel.Content = $"{ResultLabel.Content.ToString()}7";
            }

            _lastNumber = double.Parse(ResultLabel.Content.ToString());
        }
    }
}
