using System;
using Xamarin.Forms;

namespace App1.Views
{
    public partial class AboutPage : ContentPage
    {
        string currentInput = string.Empty;
        double result = 0;
        string currentOperator = string.Empty;
        const int MaxInputLength = 20; // Límite máximo de dígitos

        public AboutPage()
        {
            InitializeComponent();
        }

        private void OnNumberButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // Verificar si la longitud actual de currentInput es menor que MaxInputLength
            if (currentInput.Length < MaxInputLength)
            {
                currentInput += button.Text;
                display.Text = currentInput;
            }
            else
            {
                // Puedes mostrar un mensaje o manejar el exceso de dígitos de alguna manera
                DisplayAlert("Advertencia", "Ha alcanzado el límite máximo de 20 caracteres.", "OK");
            }
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
