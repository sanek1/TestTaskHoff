namespace Transaction.WebApi.Services.Interface
{
    using Transaction.WebApi.Models;

    public interface IIdentityService
    {
        IdentityModel GetIdentity();
    }
}
