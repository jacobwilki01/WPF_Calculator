using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Calculator.Managers;

namespace Calculator.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// The controls.
        /// </summary>
        public ControlsViewModel controls { get; set; } = new();

        /// <summary>
        /// The display.
        /// </summary>
        public DisplayViewModel display { get; set; } = new();

        /// <summary>
        /// The calculation manager.
        /// </summary>
        public CalculationManager calculator = new();

        public MainViewModel()
        {
            controls.OnNumberButtonPressed += display.Update;
            controls.OnNumberButtonPressed += calculator.UpdateValue;
            controls.OnOperationButtonPressed += UpdateOperands;
            controls.OnEqualsButtonPressed += Calculate;
            controls.OnClearButtonPressed += Clear;
            controls.OnAllClearButtonPressed += AllClear;

            calculator.OnDisplayStateUpdate += display.UpdateState;
        }

        /// <summary>
        /// Handler for updating the operands based on an operation switch.
        /// </summary>
        /// <param name="operation">The operation selected.</param>
        private void UpdateOperands(string operation)
        {
            display.Update(calculator.UpdateOperation(operation));
        }

        /// <summary>
        /// Handler for calling the calculation manager's calculate method and updating the display.
        /// </summary>
        private void Calculate()
        {
            display.Update(calculator.Calculate());
        }

        /// <summary>
        /// Handler for clearing the calculator and the display.
        /// </summary>
        private void Clear()
        {
            display.Update(calculator.Clear());
        }

        /// <summary>
        /// Handler for clearing the calculator's memory and the display.
        /// </summary>
        private void AllClear()
        {
            display.Update(calculator.AllClear());
        }
    }
}
