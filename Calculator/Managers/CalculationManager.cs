using Calculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.Managers
{
    /// <summary>
    /// Manager that handles the backend of calculation.
    /// </summary>
    public class CalculationManager
    {
        #region Constants
        /// <summary>
        /// Constant value for zero, to return for resetting the display.
        /// </summary>
        private const string ZERO = "0";
        #endregion

        #region Calculation Strings
        /// <summary>
        /// String that represents the first operand of the equation.
        /// </summary>
        private string operandOne = string.Empty;

        /// <summary>
        /// String that represents the second operand of the equation.
        /// </summary>
        private string operandTwo = string.Empty;

        /// <summary>
        /// String that represents the selected operation.
        /// </summary>
        private string operation = string.Empty;
        #endregion

        /// <summary>
        /// Bool that represents whether or not we've switched operands.
        /// </summary>
        private bool savedOne = false;

        /// <summary>
        /// Event called when the display state needs to be updated.
        /// </summary>
        public event Action<DisplayStateEnum>? OnDisplayStateUpdate;

        public CalculationManager() { }

        /// <summary>
        /// Method that updates the value of the selected operand.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public void UpdateValue(string value)
        {
            if (!savedOne)
                operandOne += value;
            else
                operandTwo += value;
        }

        /// <summary>
        /// Method that updates the selected operation.
        /// </summary>
        /// <param name="operation">The operation being selected.</param>
        /// <returns>The new operand to display, either the current one or the calculated result.</returns>
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

        /// <summary>
        /// Method to handle calculation.
        /// </summary>
        /// <returns>The end result as a string.</returns>
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

        /// <summary>
        /// Method to clear the display and saved memory of the current operand.
        /// </summary>
        /// <returns>Value to update the display to.</returns>
        public string Clear()
        {
            if (!savedOne)
                operandOne = string.Empty;
            else
                operandTwo = string.Empty;

            OnDisplayStateUpdate?.Invoke(DisplayStateEnum.SwitchOperands);

            return ZERO;
        }

        /// <summary>
        /// Method to clear all saved information, including the operation and not currently displayed operand.
        /// </summary>
        /// <returns>Value to update the display to.</returns>
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
