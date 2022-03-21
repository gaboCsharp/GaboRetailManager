using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDesktopUI.ViewModels
{
    public class StatusInfoViewModel : Screen
    {
        public string Header { get; set; }
        public string Message { get; set; }

        public void UpdateMessage(string header, string message)
        {
            Message = message;
            Header = header;    

            NotifyOfPropertyChange(() => Header);
            NotifyOfPropertyChange(() => Message);
        }

        public void Close()
        {
            TryClose();
        }

    }
}
