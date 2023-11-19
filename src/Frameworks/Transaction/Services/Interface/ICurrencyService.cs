namespace Transaction.Framework.Services.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Transaction.Framework.Domain;

    public interface ICurrencyService
    {
        Task<string> GetCurrency(Data request);
    }
}
