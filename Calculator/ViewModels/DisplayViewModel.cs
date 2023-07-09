using Calculator.Enums;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    public class DisplayViewModel : BaseViewModel 
    {
        private string _display = "0";

        public string Display
        {
            get { return _display; }
            set { _display = value; NotifyPropertyChanged(); }
        }

        private DisplayStateEnum _state = DisplayStateEnum.Empty;

        public DisplayViewModel()
        {
            
        }

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

        public void UpdateState(DisplayStateEnum state)
        {
            _state = state;
        }
    }
}
