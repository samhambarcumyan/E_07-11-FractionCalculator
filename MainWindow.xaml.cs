using System.Windows;
using System.Windows.Controls;
namespace WpfApp1;
#region MainWindow
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    /// <summary>
    /// Clears all the input fields and the answer labels when the "Clear" button is clicked.
    /// </summary>
    private void btnClear_Click(object sender, RoutedEventArgs e)
    {
        num1.Text = string.Empty;
        den1.Text = string.Empty;
        num2.Text = string.Empty;
        den2.Text = string.Empty;
        lblAnsNum.Content = string.Empty;
        lblAnsDen.Content = string.Empty;
    }
    /// <summary>
    /// Calculates the result of the selected operation on two fractions when the "Calculate" button is clicked.
    /// </summary>
    private void btnCalculate_Click(object sender, RoutedEventArgs e)
    {
        while (oper.SelectedItem == null)
        {
            MessageBox.Show("Please select an operation.");
            return;
        }
        string op = ((ComboBoxItem)oper.SelectedItem).Content.ToString() ?? "null";
        try
        {
            int numerator1 = int.Parse(num1.Text);
            int denominator1 = int.Parse(den1.Text);
            int numerator2 = int.Parse(num2.Text);
            int denominator2 = int.Parse(den2.Text);


            FractionLib.Fraction fraction1 = new FractionLib.Fraction(numerator1, denominator1);
            FractionLib.Fraction fraction2 = new FractionLib.Fraction(numerator2, denominator2);
            switch (op)
            {
                case "+":
                    FractionLib.Fraction resultAdd = fraction1 + fraction2;
                    lblAnsNum.Content = resultAdd.Numerator.ToString();
                    lblAnsDen.Content = resultAdd.Denominator.ToString();
                    break;
                case "-":
                    FractionLib.Fraction resultSub = fraction1 - fraction2;
                    lblAnsNum.Content = resultSub.Numerator.ToString();
                    lblAnsDen.Content = resultSub.Denominator.ToString();
                    break;
                case "*":
                    FractionLib.Fraction resultMul = fraction1 * fraction2;
                    lblAnsNum.Content = resultMul.Numerator.ToString();
                    lblAnsDen.Content = resultMul.Denominator.ToString();
                    break;
                case "/":
                    FractionLib.Fraction resultDiv = fraction1 / fraction2;
                    lblAnsNum.Content = resultDiv.Numerator.ToString();
                    lblAnsDen.Content = resultDiv.Denominator.ToString();
                    break;
            }
        }
        catch (FormatException)
        {
            MessageBox.Show($"user input is not in valid format");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"an error occurred: {ex.Message}");
        }
    }
}
#endregion