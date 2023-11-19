namespace Transaction.WebApi.Models
{
    public class TransactionResultModel
    {
        public int? AccountNumber { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
