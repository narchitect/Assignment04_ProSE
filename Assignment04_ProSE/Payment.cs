using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_ProSE
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentName { get; set; }
        public int Amount { get; set; }
        public string ShareType { get; set; }
        public string PaymentDate { get; set; }
        public

        private Expense() { } // making default constructor 'private' so that an object without data doesn't get created by mistake
        public Expense(string nameExpense, int amount, string shareType, string dateExpense)
        {
            this.NameExpense = nameExpense;
            this.Amount = amount;
            this.ShareType = shareType;
            this.DataExpense = dateExpense;
        }

        //make Expenses List
        public ICollection<Expense> expenseList = new List<Expense>();
    }
}