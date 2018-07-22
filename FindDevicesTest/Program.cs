using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FindDevicesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Program MyProgram = new Program();
            MyProgram.start();
        }

        public void start() {
            System.Diagnostics.Process Process = new System.Diagnostics.Process();
            Process.StartInfo.FileName = "arp";
            Process.StartInfo.Arguments = "-a ";
            Process.StartInfo.UseShellExecute = false;
            Process.StartInfo.RedirectStandardOutput = true;
            Process.StartInfo.CreateNoWindow = true;
            Process.Start();
            string strOutput = Process.StandardOutput.ReadToEnd();

            Console.WriteLine(strOutput);

            Console.WriteLine();

            List<string> test = strOutput.Split(' ').ToList();
            test = test.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            test.RemoveRange(0, 9);
            
            List<string> newlist = new List<string>();
            for(int i=0; i < test.Count(); i+=3) {
                newlist.Add(test[i]);
                newlist.Add(test[i+1]);
                newlist.Add(test[i+2]);
            }
            
            foreach(string str in newlist) {
                Console.WriteLine(str);
            }
            
            Console.WriteLine();
            Console.WriteLine("Press 'any' key to close");
            Console.ReadKey();
        }
    }
}
