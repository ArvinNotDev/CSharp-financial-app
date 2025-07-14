using financial.Transactions;
using System;

namespace financial.Models
{
    internal class Product
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public TransactionType transactionType { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
        public DateTime? LastModifiedDate { get; set; }

        public Product(string name, string description, decimal price, TransactionType transactionType)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.transactionType = transactionType;
        }

        public override string ToString() => id;
    }
}
