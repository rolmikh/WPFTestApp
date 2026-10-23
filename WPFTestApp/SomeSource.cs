using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTestApp
{
    public class SomeSource
    {
        private static InputWindow _window;

        public async Task<string> GetData()
        {
            if (_window == null)
            {
                InputWindow inputWindow = new InputWindow();

                _window = inputWindow;
                inputWindow.Show();

            }
            try
            {
                return await _window.inputTask.Task;
            }
            finally{

                _window = null;
            }


        }

      

    }
}
