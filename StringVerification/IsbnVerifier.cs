using System;

namespace StringVerification
{
    public static class IsbnVerifier
    {
        /// <summary>
        /// Verifies if the string representation of number is a valid ISBN-10 identification number of book.
        /// </summary>
        /// <param name="number">The string representation of book's number.</param>
        /// <returns>true if number is a valid ISBN-10 identification number of book, false otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if number is null or empty or whitespace.</exception>
        public static bool IsValid(string number)
        {            
            if (string.IsNullOrWhiteSpace(number) || number.Length == 0)
            {
                throw new ArgumentException($"string {nameof(number)} can't be null or whitespaces");
            }

            int checkSum = 0;
            int count = 0;
            
            for (int i = 0; i < number.Length; i++)
            {
                if (char.IsNumber(number[i]))
                {
                    checkSum += int.Parse(number[i].ToString(), System.Globalization.CultureInfo.CurrentCulture) * (10 - count);
                    count++;                    
                }
                else if (char.IsLetter(number[i]) && number[i] != 'X')
                {
                    return false;
                }
                else if (number[i] == '-' && i != 1 && i != 5 && i != number.Length - 2)
                {
                    return false;       
                }
            }

            if (number[^1] == 'X')
            {
                checkSum += 10;                
            }
            
            if (number.Length <= 13 && number.Length >= 10 && count >= 9 && count <= 10)
            {
                return checkSum % 11 == 0;
            }

            return false;
        }
    }
}
