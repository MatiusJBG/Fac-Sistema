namespace Application.DTOs
{
    public class LoginRequestDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class LoginResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public string Token { get; set; } = string.Empty;
        public UserInfoDto? User { get; set; }
    }

    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}