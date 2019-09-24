using System.Text;
using Prism.Commands;
using Prism.Mvvm;

namespace Base64Convertor.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Base64 Converter";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _input;
        public string Input
        {
            get { return _input; }
            set { SetProperty(ref _input, value); }
        }

        private string _output;
        public string Output
        {
            get { return _output; }
            set { SetProperty(ref _output, value); }
        }

        private bool _encode = true;
        public bool Encode
        {
            get { return _encode; }
            set { SetProperty(ref _encode, value); }
        }

        private DelegateCommand<string> _convert;
        public DelegateCommand<string> Convert =>
            _convert ?? (_convert = new DelegateCommand<string>(ExecuteCommandName, CanExecuteCommandName)
                    .ObservesProperty(() => Input));


        void ExecuteCommandName(string parameter)
        {
            if (Encode)
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(Input);
                Output = System.Convert.ToBase64String(plainTextBytes);
            }
            else
            {
                var bytes = System.Convert.FromBase64String(Input);
                Output = Encoding.UTF8.GetString(bytes);
            }
        }

        bool CanExecuteCommandName(string parameter) => // true;
           !string.IsNullOrEmpty(Input);

        public MainWindowViewModel()
        {
        }
    }
}
