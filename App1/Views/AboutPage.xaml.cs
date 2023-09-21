using System;
using Xamarin.Forms;

namespace App1.Views
{
    public partial class AboutPage : ContentPage
    {
        string currentInput = string.Empty;
        double result = 0;
        string currentOperator = string.Empty;

        public AboutPage()
        {
            InitializeComponent();
        }

        private void OnNumberButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            display.Text = currentInput;
        }

        private void OnOperatorButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!string.IsNullOrEmpty(currentInput))
            {
                currentOperator = button.Text;
                result = double.Parse(currentInput);
                currentInput = string.Empty;
                display.Text = currentOperator;
            }
        }

        private void OnEqualButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput) && !string.IsNullOrEmpty(currentOperator))
            {
                double secondOperand = double.Parse(currentInput);
                switch (currentOperator)
                {
                    case "+":
                        result += secondOperand;
                        break;
                    case "-":
                        result -= secondOperand;
                        break;
                    case "*":
                        result *= secondOperand;
                        break;
                    case "/":
                        if (secondOperand != 0)
                        {
                            result /= secondOperand;
                        }
                        else
                        {
                            display.Text = "Error: División por cero.";
                            return;
                        }
                        break;
                }
                display.Text = result.ToString();
                currentInput = result.ToString();
                currentOperator = string.Empty;
            }
        }

        private void OnClearButtonClicked(object sender, EventArgs e)
        {
            currentInput = string.Empty;
            result = 0;
            currentOperator = string.Empty;
            display.Text = "0";
        }
    }
}
