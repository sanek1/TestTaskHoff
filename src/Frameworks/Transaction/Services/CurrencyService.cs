namespace Transaction.Framework.Services
{
    using System;
    using System.Threading.Tasks;
    using Transaction.Framework.Domain;
    using Transaction.Framework.Services.Interface;
    using Transaction.Framework.Exceptions;

    public class CurrencyService : ICurrencyService
    {
        private readonly ICBService _CBService;
        private long _radius = 2;

        public CurrencyService( ICBService cbService)
        {
            _CBService = cbService;
        }
        public async Task<string> GetCurrency(Data request)
        {
            await request.Validate(request);
            bool check = Math.Pow((request.X - 0), 2) + Math.Pow((request.Y - 0), 2) <= Math.Pow(request.Radius, request.Radius);
            if (!check) {
                throw new InvalidValueExceededException(request.X, request.Y);
                await Task.CompletedTask;
            } 
            var x = request.X > 0 ? 1 : -1;
            var y = request.Y > 0 ? 1 : -1;
            DateTime? dt = null;
            if (x > 0 && y > 0) dt = DateTime.UtcNow;
            if (x < 0 && y > 0) dt = DateTime.UtcNow.AddDays(-1);
            if (x < 0 && y < 0) dt = DateTime.UtcNow.AddDays(-2);
            if (x > 0 && y < 0) dt = DateTime.UtcNow.AddDays(+1);

            return await _CBService.GetData(request, dt);
        }

    }
}
