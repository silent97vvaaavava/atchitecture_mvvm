namespace CodeBase.Services.Interfaces
{
    /// <summary>
    /// For Authorization in social services ass Google, Google Play Console and etc.
    /// </summary>
    public interface IAuthorizationSocial : IAuthorization
    {
        string Token { get; set; }
    }
}