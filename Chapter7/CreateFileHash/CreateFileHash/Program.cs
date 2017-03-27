using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CreateFileHash
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Count() != 1)
            {
                Console.WriteLine("USAGE: CreateFileHash 'Filename.mp3'");
            }
            else
            {
                if (File.Exists(args[0].ToString()))
                {
                    RIPEMD160 myRIPEMD160 = RIPEMD160Managed.Create();
                    byte[] hashVal;
                    using (FileStream stream = File.Open(args[0].ToString(), FileMode.Open))
                    {
                        stream.Position = 0;
                        hashVal = myRIPEMD160.ComputeHash(stream);
                        string hashValueString = CreateStringFromByteArray(hashVal);
                        Console.WriteLine("The hash for this file is: {0}", hashValueString);
                        Console.WriteLine("The hash length is {0}", hashValueString.Length);
                    }
                }
                else
                {
                    Console.WriteLine("File not found!");
                }

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
        }

        public static string CreateStringFromByteArray(byte[] array)
        {
            StringBuilder builder = new StringBuilder();
            for (var i = 0; i < array.Length; i++)
            {
                builder.AppendFormat("{0:X2}", array[i]);
            }
            return builder.ToString();
        }
    }
}
