namespace LearningMauiC_
{
    public partial class MainPage : ContentPage
    {
        string valueA;
        string operatorValue;
        string valueB;
        string viewResult;

        public MainPage()
        {
            InitializeComponent();
        }

        private void getBtnValue(object sender, EventArgs e)
        {
            string buttonText = GetButtonText(sender);

            if (valueA == null)
            {
                valueA = buttonText; 
            }
            else
            {
                switch (buttonText)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        operatorValue = buttonText;
                        break;
                    case "DEL":
                        // Limpa tudo
                        operatorValue = null;
                        valueA = null;
                        valueB = null;
                        resultLabel.Text = "";
                        return;
                    default:
                        // Se não houver um operador, acumula em valueB
                        if (operatorValue == null) 
                        {
                            valueA += buttonText; 
                        }
                        else
                        {
                            valueB += buttonText; 
                        }
                        break;
                }
            }

            // Exibe o resultado
            string viewResult = $"{valueA} {operatorValue} {valueB}";
            resultLabel.Text = viewResult;
        }

        private void onEqualsClicked(object sender, EventArgs e)
        {
            // Se valueB estiver definido, calcula o resultado
            if (!string.IsNullOrEmpty(valueB) && !string.IsNullOrEmpty(operatorValue))
            {
                double a = Convert.ToDouble(valueA);
                double b = Convert.ToDouble(valueB);
                double result = 0;

                switch (operatorValue)
                {
                    case "+":
                        result = a + b;
                        valueA = null;
                        valueB = null;
                        operatorValue = null;
                        break;
                    case "-":
                        result = a - b;
                        valueA = null;
                        valueB = null;
                        operatorValue = null;
                        break;
                    case "*":
                        result = a * b;
                        valueA = null;
                        valueB = null;
                        operatorValue = null;
                        break;
                    case "/":
                        result = a / b;
                        valueA = null;
                        valueB = null;
                        operatorValue = null;
                        break;
                }

                // Exibe o resultado final
                resultLabel.Text = result.ToString();
                return;
            }
        }

        private string GetButtonText(object sender)
        {
            // Converte o sender para um Button
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                return clickedButton.Text;
            }

            return "0";
        }
    }
}
