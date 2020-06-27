using System;

namespace PasswordVerificator
{
    class Program
    {
        static void Main(string[] args)
        {

            var newUser = new UserCreation();

             //Email Validation
            

             var addCharacterCounter = 0;
             var dotCharacterCounter = 0;

             while (addCharacterCounter != 1 || dotCharacterCounter < 1) {

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



            // PASSWORD VALIDATION


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

            //newUser.ValidEmail();

            /*while (addCharacterCounter != 1 || dotCharacterCounter < 1)
            {
                Console.WriteLine("OOps looks like your email must be wrong , maybe is a miss spelling");
                Console.WriteLine("So Lets Try again  your email");
                newUser.UserEmail = Console.ReadLine();
            }



         




            // PassWord VAlidation

            Console.WriteLine("Now type a strong Password");
            newUser.UserPassword = Console.ReadLine();
            var specialCharacterCounter = 0;

            var userPassword = newUser.UserPassword;

            char[] userPasswordArray = userPassword.ToCharArray();
            foreach (var character in userPasswordArray)
            {
                if (character == '@' || character == '!' || character == '#' || character == '$' || character == '%' || character == '&' || character == '*')
                {
                    specialCharacterCounter++;
                }
            }

            if (newUser.UserPassword.Length < 8) { Console.WriteLine($"Try Again your password dosen't have at least 8 characteres"); }
            if (specialCharacterCounter == 0) { Console.WriteLine($"Try Again your password dosen't have any special character"); }
            else { Console.WriteLine("Wonderfull your password have been created"); }

            while (newUser.UserPassword.Length < 8  ||  specialCharacterCounter == 0)
            {

                Console.WriteLine("Sorry Your Password is not strong enougth, Please create a new  Password");
                Console.WriteLine(" And also remember your password must have at least an special character");


            }*/




        }
    }
}
