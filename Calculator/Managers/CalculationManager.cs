using Calculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.Managers
{
    public class CalculationManager
    {
        private const string ZERO = "0";

        private string operandOne = string.Empty;

        private string operandTwo = string.Empty;

        private string operation = string.Empty;

        private bool savedOne = false;

        public event Action<DisplayStateEnum>? OnDisplayStateUpdate;

        public CalculationManager() { }

        public void UpdateValue(string value)
        {
            if (!savedOne)
                operandOne += value;
            else
                operandTwo += value;
        }

        public string UpdateOperation(string operation)
        {
            this.operation = operation;
            OnDisplayStateUpdate?.Invoke(DisplayStateEnum.SwitchOperands);

            if (savedOne)
                return Calculate();
            else
            {
                savedOne = true;
                return operandOne;
            }
        }

        public string Calculate()
        {
            if (operandTwo.Equals(string.Empty) || operation.Equals(string.Empty))
                return ZERO;

            if (float.TryParse(operandOne, out float numOne) && float.TryParse(operandTwo, out float numTwo))
            {
                float? result = null;

                switch (operation)
                {
                    case "+":
                        result = numOne + numTwo;
                        break;
                    case "-":
                        result = numOne - numTwo;
                        break;
                    case "*":
                        result = numOne * numTwo;
                        break;
                    case "/":
                        if (numTwo != 0)
                            result = numOne / numTwo;
                        break;
                    default:
                        break;
                }

                operandOne = result?.ToString() ?? ZERO;
                operandTwo = string.Empty;

                return operandOne;
            }

            return ZERO;
        }


        public string Clear()
        {
            if (!savedOne)
                operandOne = string.Empty;
            else
                operandTwo = string.Empty;

            OnDisplayStateUpdate?.Invoke(DisplayStateEnum.SwitchOperands);

            return ZERO;
        }

        public string AllClear()
        {
            operandOne = string.Empty;
            operandTwo = string.Empty;
            operation = string.Empty;
            savedOne = false;

            OnDisplayStateUpdate?.Invoke(DisplayStateEnum.Empty);

            return ZERO;
        }
    }
}
