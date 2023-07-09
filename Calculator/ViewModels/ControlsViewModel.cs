using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    /// <summary>
    /// ViewModel that handles the display of the button controls.
    /// </summary>
    public class ControlsViewModel : BaseViewModel
    {
        #region Commands
        /// <summary>
        /// Command when a number button is pressed.
        /// </summary>
        public Command<string> NumberButtonPressed { get; set; }

        /// <summary>
        /// Command when an operation is pressed.
        /// </summary>
        public Command<string> OperationButtonPressed { get; set; }

        /// <summary>
        /// Command when equals is pressed.
        /// </summary>
        public Command EqualsButtonPressed { get; set; }

        /// <summary>
        /// Command when "clear" is pressed.
        /// </summary>
        public Command ClearButtonPressed { get; set; }

        /// <summary>
        /// Command when "all clear" is pressed.
        /// </summary>
        public Command AllClearButtonPressed { get; set; }
        #endregion

        #region
        /// <summary>
        /// Event invoked when a number button is pressed.
        /// </summary>
        public event Action<string>? OnNumberButtonPressed;

        /// <summary>
        /// Event invoked when an operation is selected.
        /// </summary>
        public event Action<string>? OnOperationButtonPressed;

        /// <summary>
        /// Event invoked when equals is pressed.
        /// </summary>
        public event Action? OnEqualsButtonPressed;

        /// <summary>
        /// Event invoked when clear is pressed.
        /// </summary>
        public event Action? OnClearButtonPressed;

        /// <summary>
        /// Event invoked when all clear is pressed.
        /// </summary>
        public event Action? OnAllClearButtonPressed;
        #endregion

        public ControlsViewModel() 
        {
            NumberButtonPressed = new(Handle_NumberButtonPressed);
            OperationButtonPressed = new(Handle_OperationButtonPressed);
            EqualsButtonPressed = new(Handle_EqualsButtonPressed);
            ClearButtonPressed = new(Handle_ClearButtonPressed);
            AllClearButtonPressed = new(Handle_AllClearButtonPressed);
        }

        /// <summary>
        /// Handler for the number button command.
        /// </summary>
        /// <param name="value">The value selected.</param>
        private void Handle_NumberButtonPressed(string value)
        {
            OnNumberButtonPressed?.Invoke(value);
        }

        /// <summary>
        /// Handler for the operation button command.
        /// </summary>
        /// <param name="operation">The operation selected.</param>
        private void Handle_OperationButtonPressed(string operation)
        {
            OnOperationButtonPressed?.Invoke(operation);
        }

        /// <summary>
        /// Handler for the equals button.
        /// </summary>
        private void Handle_EqualsButtonPressed()
        {
            OnEqualsButtonPressed?.Invoke();
        }

        /// <summary>
        /// Handler for the clear button.
        /// </summary>
        private void Handle_ClearButtonPressed()
        {
            OnClearButtonPressed?.Invoke();
        }

        /// <summary>
        /// Handler for the all clear button.
        /// </summary>
        private void Handle_AllClearButtonPressed()
        {
            OnAllClearButtonPressed?.Invoke();
        }
    }
}
