using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.AuthenticationServices;
using SimpleTrader.WPF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        //private readonly IAccountStore _accountStore;

        
        public Authenticator(IAuthenticationService authenticationService)//, IAccountStore accountStore)
        {
            _authenticationService = authenticationService;
            //_accountStore = accountStore;
        }

        private Account _currentAccount;
        public Account CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            set
            {
                _currentAccount = value;
                OnPropertyChanged(nameof(CurrentAccount));
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }
        //{
        //    get
        //    { 
        //        return _accountStore.CurrentAccount;
        //    }
        //    private set
        //    {
        //        _accountStore.CurrentAccount = value;
        //        StateChanged?.Invoke();
        //    }
        //}

        public bool IsLoggedIn => CurrentAccount != null;

        public event Action StateChanged;

        public async Task<bool> Login(string username, string password)
        {
            //CurrentAccount = await _authenticationService.Login(username, password);
            bool success = true;

            try
            { 
                CurrentAccount = await _authenticationService.Login(username, password);
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            return await _authenticationService.Register(email, username, password, confirmPassword);
        }
    }
}
