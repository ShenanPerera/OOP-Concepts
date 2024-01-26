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

        public MisplacedBookViolation(Transaction transaction , decimal fine)
        {
            daysOverDue = (int)(DateTime.Now - transaction.returnDate).TotalDays;
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
