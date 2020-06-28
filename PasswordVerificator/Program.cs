using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace PasswordVerificator
{
    class Program
    {
        static void Main(string[] args)
        {

            var newUser = new UserCreation();

           
            EmailChecker(newUser);

            PasswordChecker(newUser);


        }


        //Email Validation Method

        public static void EmailChecker(UserCreation newUser)
        {
            var addCharacterCounter = 0;
            var dotCharacterCounter = 0;

            while (addCharacterCounter != 1 || dotCharacterCounter < 1)
            {

                addCharacterCounter = 0;
                dotCharacterCounter = 0;


                Console.WriteLine("Give me  your email");
                newUser.UserEmail = Console.ReadLine();

                var userEmail = newUser.UserEmail;

                char[] userEmailArray = userEmail.ToCharArray();

                // @ verificator got to have just one 
                foreach (char character in userEmailArray)
                {
                    if (character == '@') { addCharacterCounter = addCharacterCounter + 1; }
                }

                // "'" dot verificator at least one
                foreach (char character in userEmailArray)
                {
                    if (character == '.') { dotCharacterCounter = dotCharacterCounter + 1; }
                }

                if (addCharacterCounter == 1 && dotCharacterCounter != 0) { Console.WriteLine("Ok you Got Your Email ok, Now..."); }
                else { Console.WriteLine("Your email must be wrong shoud be a miss spelling, So lets try Again!"); }

            }

        }

        // PassWord VAlidation Method
        public static void PasswordChecker(UserCreation newUser)
        {
            var specialCharacterCounter = 0;

            while (specialCharacterCounter < 2)
            {

                specialCharacterCounter = 0;

                Console.WriteLine("Create a password");
                newUser.UserPassword = Console.ReadLine();

                var userPassword = newUser.UserPassword;
                char[] userPasswordArray = userPassword.ToCharArray();


                // AT least two especial characters verificator

                foreach (char character in userPasswordArray)
                {
                    if (character == '@' || character == '!' || character == '#' || character == '$' || character == '%' || character == '&' || character == '*')
                    { specialCharacterCounter = specialCharacterCounter + 1; }
                }

                if (specialCharacterCounter > 1) { Console.WriteLine("Ok you Got Your Password ok, Now you are registered!!"); }
                else { Console.WriteLine("Your password must be incomplete , Remenber you need at least two of this (!@#$%^&*)"); }
            }

        }
    }
}
