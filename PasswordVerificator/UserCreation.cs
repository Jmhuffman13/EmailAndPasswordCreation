using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordVerificator
{
    class UserCreation
    {






            public  UserCreation( string userEmail, string userPassword)
            {
            UserEmail = userEmail;

            userPassword = UserPassword;

            }

            public string  UserEmail { get; set; }
            public string  UserPassword { get; set; }
            public bool EmailVerified { get; set; }


          

            public void ValidEmail()
        {
            var addCharacterCounter = 0;
            var dotCharacterCounter = 0;
            var addVerified = false;
            var dotVerified = false;
            var emailVerified = false;
            var userEmail = UserEmail;
            char[] userEmailArray = userEmail.ToCharArray();
           
            // @ verificator got to have just one 
            foreach (char character in userEmailArray)
            {
                if (character == '@') { addCharacterCounter = addCharacterCounter + 1; }
            }
            if (addCharacterCounter == 1) { addVerified = true; }
           

            // "'" dot verificator at least one
            foreach (char character in userEmailArray)
            {
                if (character == '.') { dotCharacterCounter = dotCharacterCounter + 1; }
            }
            if (dotCharacterCounter != 0) { dotVerified = true; } 
            
            if (dotVerified && addVerified) { emailVerified = true; }

            if (emailVerified) { Console.WriteLine("Your email is ok"); }
            else { Console.WriteLine("Your email is wrong, Could be a miss spelling!"); }
            

            
            
        }
    }
}
