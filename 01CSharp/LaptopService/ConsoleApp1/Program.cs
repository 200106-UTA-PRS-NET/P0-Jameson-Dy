using System;
using LaptopServiceLib;

namespace LaptopServiceUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate the delegate
                                                            // Target Method tied to the delegate
            NotifyDelegate notifyDelegate = new NotifyDelegate(EmailService.SendEmail);

            // Invoke the delegate 
            // notifyDelegate.Invoke() does the same thing
            notifyDelegate();

            /* Types of Delegates:
                  Single cast delegate - a delegate which is tied to a method
                  Multicast delegate - a delegate tied to more than one method
            */
            notifyDelegate += TextService.SendText; // subscribing the methods to make multicast delegate
            // delegates maintain an invocation list that contains reference to all subscribed methods

            notifyDelegate();
        }
    }
}
