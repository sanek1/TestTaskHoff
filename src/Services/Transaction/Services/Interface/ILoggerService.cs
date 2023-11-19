namespace Transaction.WebApi.Services.Interface
{
    using log4net;
    using Transaction.WebApi.Models;

    public interface ILoggerService
    {
        void SetLog(string message);
        void InitLogger();
    }
}
