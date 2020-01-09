using System;
using LaptopServiceLib;

namespace LaptopServiceUI
{


    class Program
    {
        static double CircleArea(double radius)
        {
            return radius * radius;
        }
        static void Main(string[] args)
        {
            // instantiate the delegate
                                                            // Target Method tied to the delegate
            NotifyDelegate notifyDelegate = new NotifyDelegate(EmailService.SendEmail);

            // Invoke the delegate 
            // notifyDelegate.Invoke() does the same thing
            Console.WriteLine("Single cast delegate: ");
            notifyDelegate();

            /* Types of Delegates:
                  Single cast delegate - a delegate which is tied to a method
                  Multicast delegate - a delegate tied to more than one method
            */
            notifyDelegate += TextService.SendText; // subscribing the methods to make multicast delegate
            // delegates maintain an invocation list that contains reference to all subscribed methods
            Console.WriteLine("\nMulticast delegate: ");
            notifyDelegate();

            // predefined delegate
            Console.WriteLine("\nPredefined Delegate: ");
            Action notifyDelegateAlt = new Action(EmailService.SendEmail);
            notifyDelegateAlt();

            // function delegate
            Console.WriteLine("\nUsing Func Delegate: ");
            Func<double, double> area = new Func<double, double>(CircleArea);
            Console.WriteLine(area(4));

            // Predicate - a delegate of type bool
            // Predicate pDel = new Predicate(target function);

            //
            Console.WriteLine("\nPublisher / Subscribers: ");
            Laptop laptop = new Laptop() { ServiceTag = "123" };
            RepairService repairService = new RepairService(); // publisher

            repairService.Repaired += EmailService.SendEmail; // subscriber1
            repairService.Repaired += TextService.SendText; // subscriber2
            repairService.Repaired += PushNotificationService.SendPushNotification; // subscriber3

            repairService.Repair(laptop);


        }
    }
}
