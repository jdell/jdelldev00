using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Diagnostics;

namespace com.mxply.net.common.Core
{
    public abstract class ViewModelBase:INotifyPropertyChanged
    {
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { if (_name != value) { _name = value; OnPropertyChanged("Name"); } }
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;

                    Mouse.OverrideCursor = value ? Cursors.Wait : Cursors.Arrow;
                    OnPropertyChanged("IsLoading");
                }
            }
        }

        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            protected set
            {
                if (!_errorMessage.Equals(value))
                {
                    _errorMessage = value;

                    if (value.Length > 0) Trace.TraceError(value);

                    OnPropertyChanged("ErrorMessage");
                    OnPropertyChanged("HasError");
                }
            }
        }
        public bool HasError
        {
            get
            {
                return _errorMessage.Length > 0;
            }
        }

        public abstract bool Initialize();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
