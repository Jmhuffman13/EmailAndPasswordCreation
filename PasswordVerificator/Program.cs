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
            var juansBankMoneyOutList = new List<double>();


            while (programOn == true)
            {
                Console.WriteLine("________________________________________");
                Console.WriteLine("Welcome to TRUECODERS Bank");
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
                                        // Put the Customer Area Here

                                        var customerLogged = true;
                                        while (customerLogged == true)
                                        {
                                            Console.WriteLine("________________________________________");
                                            Console.WriteLine("What would you like to do next");
                                            Console.WriteLine("Here are your options: Writte the letter that correspond to the option you want");
                                            Console.WriteLine("Put Money In - Type P");
                                            Console.WriteLine("Sendign Money  - Type S");
                                            Console.WriteLine("Cashing Some Money Up  - Type C");
                                            Console.WriteLine("Type Out  - to Leave the platform");
                                            Console.WriteLine("________________________________________");

                                            var userOptionInCustomerArea = Console.ReadLine().ToLower();

                                            if (userOptionInCustomerArea == "p")
                                            {
                                                Console.WriteLine("How many are you going to deposit in your Bank Account");
                                                // newUser.UserMoneyIn = double.Parse(Console.ReadLine()); // I can not change the object form here it says de newUser thing does not exist
                                                juansBankMoneyInList[userIndex] = double.Parse(Console.ReadLine());
                                                juansBankBalanceList[userIndex] = juansBankBalanceList[userIndex] + juansBankMoneyInList[userIndex];
                                                Console.WriteLine($"Now your Balance is ${juansBankBalanceList[userIndex]}");
                                            }
                                            else if (userOptionInCustomerArea == "c")
                                            {
                                                Console.WriteLine("How many are you going to cash up");
                                                // newUser.UserMoneyIn = double.Parse(Console.ReadLine()); // I can not change the object form here it says de newUser thing does not exist
                                                var moneyToCashUp = double.Parse(Console.ReadLine());
                                                if (moneyToCashUp <= juansBankBalanceList[userIndex])
                                                {
                                                    juansBankMoneyOutList[userIndex] = moneyToCashUp;
                                                    juansBankBalanceList[userIndex] = juansBankBalanceList[userIndex] - juansBankMoneyOutList[userIndex];
                                                    Console.WriteLine($"Now your Balance is ${juansBankBalanceList[userIndex]}");

                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Sorry your Balance is to Low , your Balance is ${juansBankBalanceList[userIndex]}");

                                                }
                                            } else if (userOptionInCustomerArea == "s")
                                            {
                                                Console.WriteLine("So How much yo want to send ");
                                                var moneyToSendUp = double.Parse(Console.ReadLine());
                                                if (moneyToSendUp <= juansBankBalanceList[userIndex])
                                                {
                                                    Console.WriteLine("Ok now...Who you want to send money to");
                                                    var emailMoneyreceptor = (Console.ReadLine());
                                                    var emailMoneyReceptorMatched = false;

                                                    while (emailMoneyReceptorMatched == false)
                                                    {

                                                        for (var j = juansBankEmailList.Count; j > 0; j--)
                                                        {
                                                            if (emailMoneyreceptor == juansBankEmailList[j - 1])
                                                            {
                                                                var userReceptorIndex = j - 1;
                                                                emailMoneyReceptorMatched = true;
                                                                juansBankMoneyInList[userReceptorIndex] = moneyToSendUp;
                                                                juansBankBalanceList[userReceptorIndex] = juansBankBalanceList[userReceptorIndex] + juansBankMoneyInList[userReceptorIndex];

                                                                juansBankMoneyOutList[userIndex] = moneyToSendUp;
                                                                juansBankBalanceList[userIndex] = juansBankBalanceList[userIndex] - juansBankMoneyOutList[userIndex];
                                                                Console.WriteLine($"Now your Balance is ${juansBankBalanceList[userIndex]}");

                                                                Console.WriteLine($" Your Sending MOney succeed, you just sent {moneyToSendUp} to {juansBankNameList[userReceptorIndex]} and now your  Balance is  ${juansBankBalanceList[userIndex]}");

                                                            }


                                                        }
                                                        Console.WriteLine($" Sorry We can not find a customer with this email {emailMoneyreceptor}"); // THIS IS THE PROBLEM
                                                    }





                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Sorry your Balance is to Low to send ${moneyToSendUp}, your Balance is ${juansBankBalanceList[userIndex]}");

                                                }


                                            } else if(userOptionInCustomerArea == "out")
                                            {
                                                Console.WriteLine($"Sorry you have to leave  {juansBankNameList[userIndex]}, see you soon!");

                                                customerLogged = false;

                                            }
                                        }
                                    }


                                }
                                
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Sorry Your are not registered yet");
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
                    juansBankMoneyOutList.Add(newUser.UserMoneyOut); // this value should <0>

                    juansBankBalanceList.Add(newUser.UserBalance + newUser.UserMoneyIn - newUser.UserMoneyOut);
                    
                    newUser.BalanceAccount();

                    //juansBankBalanceList.Add(newUser.UserBalance);
                }
                else if(userOption == "admin") // Why Can I not use this as a methos appart it says that de list doesn' t exist
                {
                    Console.WriteLine("You Have log in as the Manager of the Bank, please type the password to check all the transactions so far");

                    var managerPassword = Console.ReadLine();
                    if (managerPassword == "admin")
                    {
                        if (juansBankEmailList.Count > 0)
                        {
                            Console.WriteLine("________________________________________");
                            Console.WriteLine("This is the List Of the Customers and their Balances");

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

        //  Customer Area 
        /*public static void CustomerArea()
        {
            var customerLogged = true;
            while (customerLogged == true) 
            {
                Console.WriteLine("________________________________________");
                Console.WriteLine("What would you like to do next");
                Console.WriteLine("Here are your options: Writte the letter that correspond to the option you want");
                Console.WriteLine("Put Money In - Type P");
                Console.WriteLine("Sendign Money  - Type S");
                Console.WriteLine("Cashing Some Money  - Type C");
                Console.WriteLine("Type Out  - to Leave the platform");
                Console.WriteLine("________________________________________");

                var userOption = Console.ReadLine().ToLower();
                if(userOption == "p")
                {
                    Console.WriteLine("How many are you going to deposit in your Bank Account");
                    // newUser.UserMoneyIn = double.Parse(Console.ReadLine()); // I can not change the object form here it says de newUser thing does not exist
                    juansBankMoneyInList[userIndex] = double.Parse(Console.ReadLine());
                }
            }

        }*/


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

                Console.WriteLine("Create a password, and remember you need incluid at least 2 special characters (!@#$%&*)");
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
