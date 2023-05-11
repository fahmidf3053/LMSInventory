using System;

namespace DBCredsManager
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Please Enter Email: ");
                string email = Console.ReadLine();

                Console.Write("Please Enter Contact: ");
                string contact = Console.ReadLine();

                Console.Write("Please Enter Location: ");
                string location = Console.ReadLine();

                Console.Write("Please Enter DB Password: ");
                string password = string.Empty;
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    password += key.KeyChar;
                }

                Console.WriteLine();

                Console.Write("Please Confirm DB Password: ");
                string passwordConfirm = string.Empty;
                while (true)
                {
                    var key = System.Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    passwordConfirm += key.KeyChar;
                }

                Console.WriteLine();

                if (password != passwordConfirm)
                {
                    throw new Exception("Password didn't match.");
                }

                var cipherTextTag = SecurityService.EncryptDBCreds(password, email, contact, location);

                // Showing CipherText and Tag in Output Window Separated by ('||')
                Console.WriteLine("DB Password CipherText: " + string.Join(Constants.VALUE_SEPARATOR, cipherTextTag.Item1, cipherTextTag.Item2));
                Console.Write("Enter a key to exit the program!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // Showing Error in Output Window
                Console.WriteLine("Error: " + ex.Message);
                Console.Write("Enter a key to exit the program!");
                Console.ReadKey();
            }
        }
    }
}
