namespace _8mpBl.Factory.Interfaces
{
    public interface IUserApi
    {
        string ValidateUserAndPasswordWithAccess(string user, string password, string station);
    }
}
