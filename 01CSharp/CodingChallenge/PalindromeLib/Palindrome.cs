using System;

namespace PalindromeLib
{
    public class Palindrome
    {
        public bool IsPalindrome(string s)
        {
            string orig = s;

            s = s.ToLower().Replace(" ", "").Replace(".", "").Replace(",", ""); // converts to lowercase and removes(spaces,periods,commas)
            string r = s;
            int length = s.Length;


            for (int i = 0; i < length - 1; i++)
            {
                if (r[length - i - 1] != s[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
