using System;
using System.Collections.Generic;
using System.Text;

namespace PassByReference
{
    public sealed class CEOSingleton
    {
        private CEOSingleton() { }

        private static CEOSingleton instance = null;
        private string name = "";
        private static readonly object padlock = new object();
        public static CEOSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CEOSingleton();
                    }
                    return instance;
                }
            }
        }

        public void setName(string n) { name = n; }
        public string getName() { return name; }
    }
}
