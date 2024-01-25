using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace oopConcepts
{
    public abstract class User
    {
        private static readonly Random R = new Random();
        public static int nextUserId = 0;
        public int userId { get; set; }
        public string name { get; set; }

        public abstract int GenerateID();
        public abstract void DisplayUserInfo();
       
    }

    public class Staff : User
    { 
        public string role { get; set; }

        public override int GenerateID()
        {
            return Interlocked.Increment(ref nextUserId);
        }

        public Staff(string name , string role) 
        { 
            userId = GenerateID();
            this.name = name;
            this.role = role;
            Console.WriteLine("call staff constructor in Staff class");
        }

        public override void DisplayUserInfo()
        {
            Console.WriteLine($"Staff Information - ID: {userId}, Name: {name}, Role: {role}");
    }

    }

    public class Reader : User
    {
        private int libraryCardNo { get; set; }

        public override int GenerateID()
        {
            return Interlocked.Increment(ref nextUserId);
        }
        public Reader(string name, int libraryCardNo)
        {
            userId = GenerateID();
            this.name = name;
            this.libraryCardNo = libraryCardNo;
            Console.WriteLine("call Reader constructor in Reader class");
        }

        //overloading
        public Reader(string name, int libraryCardNo, String additionalInfo)
        {
            userId = GenerateID();
            this.name = name;
            this.libraryCardNo = libraryCardNo;
            Console.WriteLine($"Additional Information : {additionalInfo}");
            Console.WriteLine("call Reader constructor in Reader class");
        }

        public override void DisplayUserInfo()
        {
            Console.WriteLine($"Reader Information - ID: {userId}, Name: {name}, LibraryCardNo: {libraryCardNo}");
        }
    }
}
