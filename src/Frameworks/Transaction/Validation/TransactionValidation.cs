namespace Transaction.Framework.Services
{
    using System.Threading.Tasks;
    using Transaction.Framework.Domain;
    using Transaction.Framework.Exceptions;
    using Transaction.Framework.Types;

    public static class TransactionValidation
    {

        public static async Task Validate(this Data request2, Data request)
        {

            if (request.ValutaCode == null)
            {
                throw new InvalidValutaCodeException(request.ValutaCode);
            }
            if (request.X == null || request.Y == null)
            {
                throw new InvalidСoordinatesException();
            }
            if (request.Radius == null )
            {
                throw new InvalidСoordinatesException();
            }

            await Task.CompletedTask;
        }
    }
}
