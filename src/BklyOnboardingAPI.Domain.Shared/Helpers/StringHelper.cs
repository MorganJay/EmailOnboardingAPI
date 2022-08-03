using System;
using System.Text;

namespace BklyOnboardingAPI.Domain.Shared.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// Generate a random string with a given size and case. If second parameter is true, the return string is lowercase
        /// </summary>
        /// <param name="size"></param>
        /// <param name="lowerCase"></param>
        /// <returns></returns>
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
   
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public static string RandomNumber(int min, int max)
        {
            Random random = new Random();
            int num = random.Next(min, max);
            return num.ToString();
        }

        public static string RandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        /// <summary>
        /// Create a string of characters, numbers, special characters that allowed in the password. Default size of random password is 15
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CreateRandomPassword(int length = 15)
        { 
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

    }
}
