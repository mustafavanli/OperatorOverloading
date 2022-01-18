using System;

namespace OperatorOverloading
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DecimalClass();
            //UserClass();


            Console.ReadKey();
        }

        private static void UserClass()
        {
            User UserDb = new User() { Id = 1, FullName = "" };
            User UserApi = new User() { Id = 1, FullName = "Mustafa Vanlı" };
            //Console.WriteLine(UserDb != UserApi);
            if (UserDb)
            {
                Console.WriteLine("UserDb not empty");
            }
            else
            {
                Console.WriteLine("UserDb empty");
            }
        }

        private static void DecimalClass()
        {
            DecimalNumber number1 = new DecimalNumber(-5);
            DecimalNumber number2 = new DecimalNumber(10);
            //var total = number1 + 25;
            //Console.WriteLine(number1!=number2);
            if (number1)
            {
                Console.WriteLine("Greater than zero");
            }
            else
            {
                Console.WriteLine("Not greater than zero");
            }
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public static bool operator ==(User user1,User user2)
        {
            return user1.Id == user2.Id;
        }
        public static bool operator !=(User user1, User user2)
        {
            return user1.Id != user2.Id;
        }

        public static bool operator true(User user1) => user1.Id > 0 && !string.IsNullOrEmpty(user1.FullName);
        public static bool operator false(User user1) => user1.Id < 0 || string.IsNullOrEmpty(user1.FullName);
    }


    public class DecimalNumber
    {
        public decimal Value { get; set; }
        public int Precision { get; set; }
        public DecimalNumber(decimal value)
        {
            this.Value = value;
        }

        public static DecimalNumber operator +(DecimalNumber number1, DecimalNumber number2)
        {
            return new DecimalNumber(number1.Value + number2.Value);
        }
        public static DecimalNumber operator +(DecimalNumber number1, int number2)
        {
            return new DecimalNumber(number1.Value + number2);
        }
        public static bool operator ==(DecimalNumber number1, DecimalNumber number2)
        {
            return number1.Value == number2.Value;
        }
        public static bool operator ==(DecimalNumber number1, int number2)
        {
            return number1.Value == number2;
        }
        public static bool operator !=(DecimalNumber number1, int number2)
        {
            return number1.Value != number2;
        }
        public static bool operator !=(DecimalNumber number1, DecimalNumber number2)
        {
            return number1.Value != number2.Value;
        }

        public static bool operator true(DecimalNumber number) => number.Value > 0;
        public static bool operator false(DecimalNumber number) => number.Value < 0;
    } 
}
