using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static int totalBytes = 0;
        static WebClient myClient = new WebClient();
        static void Main(string[] args)
        {
            EventWaitHandle ewh = GrabPageAsync("http://www.google.com/");
            ewh.WaitOne();
            // WaitHandles to wait on completion of requests.
            EventWaitHandle[] waitHandles = new EventWaitHandle[2];

            DateTime startTime = DateTime.Now;
            // Time how long it takes to get two pages
            waitHandles[0] = GrabPageAsync("http://www.yahoo.com/");
            waitHandles[1] = GrabPageAsync("http://www.cnn.com/");

            // wait for completion
            EventWaitHandle.WaitAll(waitHandles);
            DateTime endTime = DateTime.Now;
            TimeSpan elapsed = endTime - startTime;
            Console.WriteLine("Read {0} bytes in {1} seconds", totalBytes, elapsed);
            Console.Read();
        }

        private static EventWaitHandle GrabPageAsync(string url)
        {
           
            myClient.OpenReadCompleted += new OpenReadCompletedEventHandler(myClient_OpenReadCompleted);
            EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.ManualReset);
            myClient.OpenReadAsync(new Uri(url), ewh);
            return ewh;
        }

        private static void myClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            Stream response = (Stream)e.Result;
            try
            {
                StreamReader sr = new StreamReader(response);
                try
                {
                    // read the response into a string and show the result.
                    string s = sr.ReadToEnd();
                    totalBytes += s.Length;
                    // Signal the wait handle
                    EventWaitHandle ewh = (EventWaitHandle)e.UserState;
                    ewh.Set();
                }
                finally
                {
                    sr.Close();
                }
            }
            finally
            {
                response.Close();
            }
        }
    }
}
