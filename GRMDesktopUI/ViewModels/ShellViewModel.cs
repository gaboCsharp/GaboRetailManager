﻿using Caliburn.Micro;
using GRMDesktopUI.EventModels;
using GRMDesktopUI.Library.Api;
using GRMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {

        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private ILoggedInUserModel _user;
        private IAPIHelper _apiHelper;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM,
             ILoggedInUserModel user, IAPIHelper apiHelper)
        {
            _events = events;  
            _salesVM = salesVM;
            _user = user;
            _apiHelper = apiHelper;

            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());          
        }


        public bool IsLoggedIn
        {
            get
            {
                bool output = false;

                if (!string.IsNullOrWhiteSpace(_user.Token))
                {
                    output = true;
                }

                return output;
            }
        }
      
        public void ExitApplication()
        {
            TryClose();
        }

        public void LogOut()
        {
            _user.LogOffUser();
            _apiHelper.LogOffUser();
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
            NotifyOfPropertyChange(() => IsLoggedIn);
            
        }
    }
}
