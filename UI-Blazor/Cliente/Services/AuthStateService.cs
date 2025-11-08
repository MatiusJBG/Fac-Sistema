using Application.DTOs;

namespace Cliente.Services
{
    public class AuthStateService
    {
        private LoginResponseDto? _currentUser;
        public event Action? OnAuthStateChanged;

        public LoginResponseDto? CurrentUser => _currentUser;
        public bool IsAuthenticated => _currentUser != null;

        public void SetUser(LoginResponseDto? user)
        {
            _currentUser = user;
            OnAuthStateChanged?.Invoke();
        }

        public void Logout()
        {
            _currentUser = null;
            OnAuthStateChanged?.Invoke();
        }
    }
}