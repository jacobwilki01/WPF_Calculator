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
        public ControlsViewModel controls = new();

        public DisplayViewModel display = new();

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

        private void UpdateOperands(string operation)
        {
            display.Update(calculator.UpdateOperation(operation));
        }

        private void Calculate()
        {
            display.Update(calculator.Calculate());
        }

        private void Clear()
        {
            display.Update(calculator.Clear());
        }

        private void AllClear()
        {
            display.Update(calculator.AllClear());
        }
    }
}
