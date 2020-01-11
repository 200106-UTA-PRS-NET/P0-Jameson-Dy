using System;

namespace StringManipulationLib
{
    public class StringChange
    {
        public string ChangeToUpper(string s)
        {
            return s.ToUpper();
        }

        public string Reverse(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);

            return new string(arr);
        }
    }
}
