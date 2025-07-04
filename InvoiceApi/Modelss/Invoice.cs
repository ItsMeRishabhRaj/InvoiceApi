namespace InvoiceApi.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
