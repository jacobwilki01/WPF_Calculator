using Calculator.Enums;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    /// <summary>
    /// View Model that handles the display.
    /// </summary>
    public class DisplayViewModel : BaseViewModel 
    {
        private string _display = "0";
        /// <summary>
        /// The value displayed in the display.
        /// </summary>
        public string Display
        {
            get { return _display; }
            set { _display = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// The display state.
        /// </summary>
        private DisplayStateEnum _state = DisplayStateEnum.Empty;

        public DisplayViewModel()
        {
            
        }

        /// <summary>
        /// Method to update the value in the display.
        /// </summary>
        /// <param name="value">The value being pushed into it.</param>
        public void Update(string value)
        {
            if (_state != DisplayStateEnum.Editable)
            {
                Display = value;
                if (!value.Equals("0") && _state != DisplayStateEnum.SwitchOperands)
                    UpdateState(DisplayStateEnum.Editable);
            }
            else
                Display += value;
        }

        /// <summary>
        /// Method to update the state of the display.
        /// </summary>
        /// <param name="state">The state to change it to.</param>
        public void UpdateState(DisplayStateEnum state)
        {
            _state = state;
        }
    }
}
