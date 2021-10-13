namespace LogIn.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}