namespace FSAproject.Services
{
    using FSAproject.Models;

    public interface IAuthService
    {
        string GenerateToken(Utilisateur user);
    }
}
