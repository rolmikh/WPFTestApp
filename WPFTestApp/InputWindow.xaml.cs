using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFTestApp
{
    /// <summary>
    /// Логика взаимодействия для InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {

        public string Result {  get; set; }

        public TaskCompletionSource<string> inputTask = new TaskCompletionSource<string>();

        public InputWindow()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            Result = tbInput.Text;
            inputTask.SetResult(Result);
            Close();

        }

        private void tbInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            btOk.IsEnabled = !string.IsNullOrWhiteSpace(tbInput.Text);

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!inputTask.Task.IsCompleted)
            {
                e.Cancel = true;
            }

        }
    }
}
