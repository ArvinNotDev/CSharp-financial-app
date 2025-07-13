using financial.Enums;
using financial.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace financial.Models
{
    internal class Product
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public Account account { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public TransactionType transactionType { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
        public DateTime? LastModifiedDate { get; set; }

        public Product(Account account, string name, string description, decimal price, TransactionType transactionType)
        {
            this.account = account;
            this.name = name;
            this.description = description;
            this.price = price;
            this.transactionType = transactionType;

        }
        public override string ToString() => id;
    }
}
