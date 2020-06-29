using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace PasswordVerificator
{
    class Program
    {
        static void Main(string[] args)
        {
            var programOn = true;

            var juansBankTransactionList = new List<UserCreation>();  // I wanted to use this List of Object 
            var juansBankEmailList = new List<string>();
            var juansBankPasswordList = new List<string>();
            var juansBankNameList = new List<string>();
            var juansBankBalanceList = new List<double>(); //Is Not updating the balance in tha manager account 
            var juansBankMoneyInList = new List<double>();


            while (programOn == true)
            {
                Console.WriteLine("________________________________________");
                Console.WriteLine("Welcome to Juan's Bank");
                Console.WriteLine("Here are your options: Writte the letter that correspond to the option you want");
                Console.WriteLine("Login - Type L");
                Console.WriteLine("Sign up - Type S");
                Console.WriteLine("Type Out  - to Leave the platform");
                Console.WriteLine("________________________________________");


                var userOption = Console.ReadLine().ToLower();

                if (userOption == "l")
                {

                    if (juansBankEmailList.Count > 0)
                    {
                        var userIndex = 0;
                        var emailMatched = false;

                        while (emailMatched == false)
                        {
                            Console.WriteLine("Tell me the email you registered with");
                            var emailInput = (Console.ReadLine());

                            for (var i = juansBankEmailList.Count; i > 0;  i--)  
                            {
                                if (emailInput == juansBankEmailList[i -1])
                                {
                                    userIndex = i - 1;
                                    emailMatched = true;

                                    var passwordVerified = false;

                                    while(passwordVerified == false)
                                    {
                                        Console.WriteLine("Introduce your password");
                                        var passwordInput = (Console.ReadLine());

                                        if(passwordInput == juansBankPasswordList[userIndex])
                                        {
                                            Console.WriteLine($"Your account has been verified and your Balance is ${juansBankBalanceList[userIndex]}");
                                            passwordVerified = true; 
                                        }


                                    }


                                }
                                
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Sorry Your ar not registered yet");
                    }
                   
                   
                }
                else if(userOption == "s")
                {
                    var newUser = new UserCreation();

                    NameCreator(newUser);
                    EmailChecker(newUser);
                    PasswordChecker(newUser);

                    Console.WriteLine("How many are you going to deposit in your Bank Account");
                    newUser.UserMoneyIn = double.Parse(Console.ReadLine());

                    juansBankTransactionList.Add(newUser);// Wanted to use with the object List

                    juansBankEmailList.Add(newUser.UserEmail);
                    juansBankPasswordList.Add(newUser.UserPassword);
                    juansBankNameList.Add(newUser.UserName);
                    juansBankMoneyInList.Add(newUser.UserMoneyIn);
                    juansBankBalanceList.Add(newUser.UserBalance + newUser.UserMoneyIn - newUser.UserMoneyOut);
                    
                    newUser.BalanceAccount();

                    //juansBankBalanceList.Add(newUser.UserBalance);
                }
                else if(userOption == "admin") // Why Can I not use this as a methos appart it says that de list doesn' t exist
                {
                    Console.WriteLine("You Have log in as the Manger of the Bank, please type the password to check all the transactions so far");

                    var managerPassword = Console.ReadLine();
                    if (managerPassword == "admin")
                    {
                        if (juansBankEmailList.Count > 0)
                        {
                            Console.WriteLine("________________________________________");
                            Console.WriteLine("This is the List Of the transactions");

                            for(var i = 0; i < juansBankEmailList.Count; i++)
                            {
                                Console.WriteLine($"Name:{juansBankNameList[i]} || E-mail : {juansBankEmailList[i]} || Balance : {juansBankBalanceList[i]} ");
                            }
                        }
                        else
                        {
                        
                        Console.WriteLine(" You Dont Have Any Customer Yet");
                        }


                    }
                    else
                    {
                        Console.WriteLine(" Im sorry The Password For the Manager Account is Wrong, Your Access has been Denied");
                    }

                }
                else if(userOption == "out")
                {
                    Console.WriteLine("Sorry you have to leave, see you later");
                    programOn = false;      
                }

            }

            



           

           
        }

        // Manager Access
        public static void ManagerAccess()
        {
          


        }


        // Name Creation Methot
        public static void NameCreator(UserCreation newUser)
        {
            Console.WriteLine("what is your name?");
            newUser.UserName = Console.ReadLine();
            
        }

        //Email Creation and Validation Method

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

        // PassWord Creation and VAlidation Method
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
