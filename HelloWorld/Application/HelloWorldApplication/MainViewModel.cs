using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace HelloWorld
{
    public class MainViewModel : ViewModelBase
    {
        private readonly HelloWorldServiceAgent _service;
        private string _messageText;

        public MainViewModel()
            : this(new HelloWorldServiceAgent())
        {
        }

        public MainViewModel(HelloWorldServiceAgent service)
        {
            _service = service;
            GetMessageCommand = new RelayCommand(
                async () => MessageText = await _service.GetMessageAsync());
        }

        public string MessageText
        {
            get { return _messageText; }
            set { Set(ref _messageText, value); }
        }

        public RelayCommand GetMessageCommand { get; set; }
    }
}
