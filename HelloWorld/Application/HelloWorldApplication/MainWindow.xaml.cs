using System;
using System.Windows;

namespace HelloWorld
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetMessageButton_Click(object sender, RoutedEventArgs e)
        {
            MessageTextBox.Text = "Hello World";
        }
    }
}
