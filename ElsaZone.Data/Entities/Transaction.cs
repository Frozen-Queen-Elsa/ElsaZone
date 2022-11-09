using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace ElsaZone.Data.Entities;
[Table("Transactions")]
public class Transaction
{
    public int TransactionId { set; get; }
    public string TransactionDate { set; get; }
    public int ExternalTransactionId { set; get; }
    public decimal Amount { set; get; }
    public decimal Fee { set; get; }
    public string Result { set; get; }
    public string Message { set; get; }
    public int Status { set; get; }
    public string Provider { set; get; }
}