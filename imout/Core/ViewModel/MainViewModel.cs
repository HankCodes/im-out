using System;
using System.ComponentModel;

namespace imout.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        string inputValue = String.Empty;
        public string InputValue
        {
            get => inputValue;
            set
            {
                if (inputValue == value) return;
                inputValue = value;
                OnChangeHandler(nameof(InputValue));
                OnChangeHandler(nameof(DisplayInput));

            }
        }
        public string DisplayInput => inputValue;
        public event PropertyChangedEventHandler PropertyChanged;

        void OnChangeHandler(string newInput)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(newInput));
        }
    }
}
