using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LaptopServiceLib
{
    // create a delegate
    public delegate void NotifyDelegate(); // delegate NotifyDelegate will be instantiated in the Main() -> LaptopServiceUI
    public class RepairService
    {
        public void Repair(Laptop laptop)
        {
            Console.Write("Repairing");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);

            }
            Console.WriteLine("");

            // Raising Event / publishing to subscribers
            OnRepairCompletion();
        }

        public event NotifyDelegate Repaired;
        protected virtual void OnRepairCompletion()
        {
            if (Repaired != null)
            {
                // invoking the event which needs to be handled by delegate NotifyDelegate
                Repaired();
            }
        }
    }
}
