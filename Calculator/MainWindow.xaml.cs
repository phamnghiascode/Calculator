using System.Text;
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
        private double lastNumber;
        private SelectedOperator selectedOperator;
        private double result;
        public MainWindow()
        {
            InitializeComponent();
        }

       private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if(lbResult.Content.ToString() == "0")
            {
                lbResult.Content = $"{selectedValue}";
            }
            else
            {
                lbResult.Content = $"{lbResult.Content}{selectedValue}";
            }
        }

        private void btnAC_Click(object sender, RoutedEventArgs e)
        {
            lbResult.Content = "0";
        }

        private void btnNegative_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(lbResult.Content.ToString(), out lastNumber))
            {
                lastNumber = -1 * lastNumber;
                lbResult.Content = lastNumber.ToString();   
            }
        }

        private void btnPercentage_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if(double.TryParse(lbResult.Content.ToString(), out tempNumber))
            {
                tempNumber = tempNumber / 100;
                if(lastNumber != 0)
                    tempNumber *= lastNumber;
                lbResult.Content = tempNumber.ToString();
            }
        }
        
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lbResult.Content.ToString(), out lastNumber))
            {
                lbResult.Content = "0";
            }

            if(sender == btnPlus)
            {
                selectedOperator = SelectedOperator.Addition;
            }
            if (sender == btnMinus)
            {
                selectedOperator = SelectedOperator.Sustraction;
            }
            if (sender == btnMultiple)
            {
                selectedOperator = SelectedOperator.Mutiplication;
            }
            if (sender == btnDivice)
            {
                selectedOperator = SelectedOperator.Division;
            }

        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(lbResult.Content.ToString(), out double newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition: result = newNumber + lastNumber;break;

                    case SelectedOperator.Sustraction: result = lastNumber - newNumber; break;

                    case SelectedOperator.Mutiplication:  result = newNumber * lastNumber; break;

                    case SelectedOperator.Division: 
                        if (newNumber == 0) 
                            { 
                                MessageBox.Show("Không thể chia cho 0! Vui lòng thực hiện phép tính khác", "Lỗi", MessageBoxButton.OK);
                                break; 
                            } else 
                            { 
                                result = lastNumber / newNumber; 
                                break; 
                            }
                }
                lbResult.Content = result.ToString();
            }
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if(lbResult.Content.ToString().Contains(".")) 
            {
                //do nothing here
            }
            else
            {
            lbResult.Content = $"{lbResult.Content}.";
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Sustraction,
        Mutiplication,
        Division
    }

}