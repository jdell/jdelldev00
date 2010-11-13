using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.net.common.Core
{
    public class ProgressEventArgs : EventArgs
    {
        string _infoProcess;


        public string InfoProcess
        {
            get { return _infoProcess; }
            set { _infoProcess = value; }
        }
        int _currentProcess;


        public int CurrentProcess
        {
            get { return _currentProcess; }
            set { _currentProcess = value; }
        }
        int _totalProcess;


        public int TotalProcess
        {
            get { return _totalProcess; }
            set { _totalProcess = value; }
        }


        public ProgressEventArgs(string info, int current, int total)
        {
            _infoProcess = info;
            _currentProcess = current;
            _totalProcess = total;
        }
    }
}
