using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordVerificator
{
    class UserCreation
    {
            public  UserCreation()
            {
           

            }

        public void BalanceAccount()
        {
            Balance = Balance + UserMoneyIn - UserMoneyOut; // Why It dosent work when i holde it in the Balance List

            Console.WriteLine($"The Balance of {UserName}'s account is : $ {Balance}");
            Console.WriteLine($"Now that you are registerd, log in at your account to verify that always is ok ");


        }
        public string UserName { get; set; }
            public string  UserEmail { get; set; }
            public string  UserPassword { get; set; }
            public int UserBalance { get; set; }
            public double Balance { get; set; }
            public double UserMoneyIn { get; set; }
            public double UserMoneyOut { get; set; }


          

           
    }
}
