using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Transaction
    {
        private double sumPrice;
        private DateTime transactionDate;
        private string transactionDescription;

        public double SumPrice
        {
            get
            {
                return this.sumPrice;
            }
            set
            {
                if(this.sumPrice != value)
                {
                    this.sumPrice = value;
                }
            }
        }

        public DateTime TransactionDate
        {
            get
            {
                return this.transactionDate;
            }
            set
            {
                if(this.transactionDate != value)
                {
                    this.transactionDate = value;
                }
            }
        }

        public string TransactionDescription
        {
            get
            {
                return this.transactionDescription;
            }
            set
            {
                if (this.transactionDescription != value)
                {
                    this.transactionDescription = value;
                }
            }
        }
        public Transaction() { }
        public Transaction(double sumPrice, string transactionDescription, DateTime dateTimeTransaction) 
        {
            this.TransactionDate = dateTimeTransaction;
            this.SumPrice = sumPrice;
            this.TransactionDescription = transactionDescription;
        }

        public void Save(string path)
        {
            if (!Directory.Exists(path + $@"\HouseBook\{this.TransactionDate.ToString("MMMM YYYY")}"))
            {
                Directory.CreateDirectory(path + $@"\HouseBook\{this.TransactionDate.ToString("MMMM yyyy")}");
            }
            File.Create(path + $@"\HouseBook\{this.TransactionDate.ToString("MMMM yyyy")}\{this.TransactionDate.ToString("dd MMMM yyyy")}.txt").Close();
            using (StreamWriter sw = new StreamWriter(path + $@"\HouseBook\{this.TransactionDate.ToString("MMMM yyyy")}\{this.TransactionDate.ToString("dd MMMM yyyy")}.txt"))
            {
                sw.WriteLine(this.TransactionDate.ToString("dd MM yyyy"));
                sw.WriteLine(this.TransactionDescription);
                sw.WriteLine(this.SumPrice);
            }
        }
    }
}
