using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    public class ControlsViewModel : BaseViewModel
    {
        public Command<string> NumberButtonPressed { get; set; }

        public Command<string> OperationButtonPressed { get; set; }

        public Command EqualsButtonPressed { get; set; }

        public Command ClearButtonPressed { get; set; }

        public Command AllClearButtonPressed { get; set; }

        public event Action<string>? OnNumberButtonPressed;

        public event Action<string>? OnOperationButtonPressed;

        public event Action? OnEqualsButtonPressed;

        public event Action? OnClearButtonPressed;

        public event Action? OnAllClearButtonPressed;

        public ControlsViewModel() 
        {
            NumberButtonPressed = new(Handle_NumberButtonPressed);
            OperationButtonPressed = new(Handle_OperationButtonPressed);
            EqualsButtonPressed = new(Handle_EqualsButtonPressed);
            ClearButtonPressed = new(Handle_ClearButtonPressed);
            AllClearButtonPressed = new(Handle_AllClearButtonPressed);
        }

        private void Handle_NumberButtonPressed(string value)
        {
            OnNumberButtonPressed?.Invoke(value);
        }

        private void Handle_OperationButtonPressed(string operation)
        {
            OnOperationButtonPressed?.Invoke(operation);
        }

        private void Handle_EqualsButtonPressed()
        {
            OnEqualsButtonPressed?.Invoke();
        }

        private void Handle_ClearButtonPressed()
        {
            OnClearButtonPressed?.Invoke();
        }

        private void Handle_AllClearButtonPressed()
        {
            OnAllClearButtonPressed?.Invoke();
        }
    }
}
