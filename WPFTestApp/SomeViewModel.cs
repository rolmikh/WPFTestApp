using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WPFTestApp
{
    public class SomeViewModel : INotifyPropertyChanged
    {
        private string _data;

        public string Data { 
            get => _data;
            set {
                if (_data != value)
                {
                    _data = value;
                    OnPropertyChanged();
                }
            }
        
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand GetDataCommand
        {
            get
            {
                return new AsyncRelayCommand(async () =>
                {
                    var ds = new SomeSource();
                    Data = await ds.GetData();
                });
            }
        }
    }
}
