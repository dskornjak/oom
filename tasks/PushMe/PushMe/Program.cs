using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;

namespace PushMe
{
    public class mepush
    {
        public void mynetwork(int time, string mytask)
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) return;

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            while (true)
            {
                foreach (NetworkInterface ni in interfaces)
                {
                    if (ni.Name == "WLAN")
                    {
                        Console.WriteLine("{0} Rx Bytes: {1}", mytask, ni.GetIPStatistics().BytesReceived);
                    }
                }
                System.Threading.Thread.Sleep(time);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           /*How to connect the network interface with the IObserver/Producer-Consumer*/

            var x = new mepush();
            var y = new mepush();
            
            Task t = Task.Run(() =>
            {
                x.mynetwork(500, "Task1");
            });

            Task t2 = Task.Run(() =>
            {
                y.mynetwork(1000, "Task2");
            });

            t.Wait();
            t2.Wait();
        }

        
    }
}
