// Code stolen from https://scottlilly.com/create-better-random-numbers-in-c/
// Assumed to be Fair Use

using System;
//using System.Security.Cryptography;

namespace Shuffle
{
    public class RNG
    {
        //private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        //public static int Between(int minimumValue, int maximumValue)
        //{
        //    var randomNumber = new byte[1];

        //    _generator.GetBytes(randomNumber);

        //    var asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

        //    // We are using Math.Max, and substracting 0.00000000001, 
        //    // to ensure "multiplier" will always be between 0.0 and .99999999999
        //    // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
        //    var multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

        //    // We need to add one to the range, to allow for the rounding done with Math.Floor
        //    var range = maximumValue - minimumValue + 1;

        //    var randomValueInRange = Math.Floor(multiplier * range);

        //    return (int)(minimumValue + randomValueInRange);
        //}

        public static Random _random = new Random();

        public static int Between(int minimumValue, int maximumValue)
        {
            return _random.Next(minimumValue, maximumValue);
        }

    }
}