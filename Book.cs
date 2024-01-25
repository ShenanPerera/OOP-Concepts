using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopConcepts
{
    public class Book
    {
        private static readonly Random R = new Random();
        private static int nextBookId = 0;
        public int bookId { get; set; }
        public string title { get; set; }
        public string author { get; set; }

        public bool availabilty { get; set; }

        public Book(string title , string author)
        { 
            bookId = GenerateBookId();
            this.title = title;
            this.author = author;
            this.availabilty = true;
            Console.WriteLine("call book constructor in book class");
        }

        public int GenerateBookId()
        {
            return Interlocked.Increment(ref nextBookId);
        }

        public void DisplayBook(string bookName)
        {
            if(title.Equals(bookName , StringComparison.OrdinalIgnoreCase) && availabilty)
            {
                Console.WriteLine($"Book ID: {bookId} , Title: {title} , Author: {author} , Availability: {availabilty}");
            }
            else
            {
                Console.WriteLine($"Book with the title '{bookName}' is not available.");
            }
        }

        public void UpdateAvailability(int id)
        {
            if (bookId == id)
            {
                availabilty = true;
            }
        }
    }

}
