using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Libraries
{
    public static class OrderNoGenerator
    {


        // @GENERATES UNIQUE ID
        public static string Generate(int length = 5, bool MixSmallLetters = false, bool NumbersOnly = false)
        {
            string con = "";
            if (MixSmallLetters)
            {
                var number = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "N", "M", "O", "P", "Q", "R", "S", "U", "V", "T", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

                if (NumbersOnly)
                    number = new[] { "1", "2", "3", "4", "5", "5", "5", "5", "5", "6", "6", "7", "8", "9", "4", "1", "2", "3", "4", "5", "5", "7", "8", "9", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "1", "2", "3", "4", "5", "6", "7", "8", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                // 'Check if Mixture is 
                string rand_number;
                int i = default(int), rand_value;
                // RANDOM GEN
                var Generator = new Random();
                while (i < length)
                {
                    // Generate Random No
                    rand_value = Generator.Next(0, 61);
                    rand_number = number[rand_value].ToString();
                    // Concatenate'
                    if (string.IsNullOrEmpty(con))
                        con = rand_number;
                    else
                        con += rand_number;
                    i += 1;
                }
            }
            else
            {
                var number = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "N", "M", "O", "P", "Q", "R", "S", "U", "V", "T", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                // 'Check if Mixture is 
                if (NumbersOnly)
                    number = new[] { "1", "2", "3", "4", "5", "5", "5", "5", "5", "6", "6", "7", "8", "9", "4", "1", "2", "3", "4", "5", "5", "7", "8", "9", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "1", "2", "3", "4", "5", "6", "7", "8", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                string rand_number;
                int i = default(int), rand_value;
                // RANDOM GEN
                var Generator = new Random();
                while (i < length)
                {
                    // Generate Random No
                    rand_value = Generator.Next(0, 35);
                    rand_number = number[rand_value].ToString();
                    // Concatenate'
                    if (string.IsNullOrEmpty(con))
                        con = rand_number;
                    else
                        con += rand_number;
                    i += 1;
                }
            }


            return con;
        }

    }
}
