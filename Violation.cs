using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopConcepts
{
    public interface Violation
    {
        decimal CalculateFine();

    }

    public class LostBookViolation : Violation
    {
        private decimal replacementCost;

        public LostBookViolation(decimal replacementCost)
        {
            this.replacementCost = replacementCost;
        }   

        public decimal CalculateFine() 
        {
            return this.replacementCost * (decimal)0.5;
        }
    }

    //try again
    public class MisplacedBookViolation : Violation
    {
        private int daysOverDue;
        private decimal dailyFine;
        private int transactionId;
        private Library library;

        public MisplacedBookViolation(int transactionID , decimal fine , Library library)
        {
            this.transactionId = transactionID;
            this.library = library;

            DateTime returnDate = library?.ReturnTransactionRetunDate(transactionID) ?? DateTime.Now;
            daysOverDue = (int)Math.Abs((DateTime.Now - returnDate).TotalDays);
            this.dailyFine = fine;  
        }

        public decimal CalculateFine() 
        {
            return daysOverDue * dailyFine;
        }
    }

    public class OtherViolation : Violation 
    { 
        private decimal fine;

        public OtherViolation(decimal fine)
        {
            this.fine = fine;
        }

        public decimal CalculateFine() 
        {
            return fine;
        }
    }

}
