using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace HelloWorld
{
    public class MainViewModel : ViewModelBase
    {
        private string _messageText;

        public MainViewModel()
        {
            GetMessageCommand = new RelayCommand(
                () => MessageText = "Hello World");
        }

        public string MessageText
        {
            get { return _messageText; }
            set { Set(ref _messageText, value); }
        }

        public RelayCommand GetMessageCommand { get; set; }
    }
}
