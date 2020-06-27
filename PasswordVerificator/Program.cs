using System;

namespace PasswordVerificator
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
            Console.WriteLine("Give your email");
            var userEmail = Console.ReadLine();

            var newUser = new UserCreation(userEmail);
            
            newUser.ValidEmail();

            Console.WriteLine("Now type a strong Password");
            newUser.UserPassword = Console.ReadLine();
            var specialCharacterCounter = 0;

            var userPassword = newUser.UserPassword;
            char[] userPasswordArray = userPassword.ToCharArray();
            foreach(var character in userPasswordArray)
            {
                if(character == '@' || character == '!' || character == '#' || character == '$' || character == '%' || character == '&' || character == '*' )
                {
                    specialCharacterCounter = specialCharacterCounter + 1;
                }
               
               
            }

             
            while (newUser.UserPassword.Length < 8  ||  specialCharacterCounter > 0)
            {
                Console.WriteLine("Sorry Your Password is not strong enougth, Please create a new  Password");
                Console.WriteLine(" And also remember your password must have at least an special character");
                newUser.UserPassword = Console.ReadLine();
            }




        }
    }
}
