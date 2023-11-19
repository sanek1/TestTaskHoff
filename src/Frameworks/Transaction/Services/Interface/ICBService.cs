namespace Transaction.Framework.Services.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Transaction.Framework.Domain;
    public interface ICBService
    {
        Task<string> GetData(Data request, DateTime? dt);
    }
}