using ConfigBot.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBot
{
    class Program
    {
        [DllImport("shell32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsUserAnAdmin();

        enum ExitCode : int
        {
            Success = 0,
            InsufficientPriviledges = 1,
            ServiceHelperError = 2,
            FileAccessError = 3,
            UnknownError = 99
        }

        static int Main(string[] args)
        {
            var exceptions = new List<Exception>();

            try
            {
                Console.WriteLine("Checking for admin powers...");

                if (!IsUserAnAdmin())
                {
                    Console.WriteLine("This application requires elevated access. Please execute as Administrator.");
                    return (int)ExitCode.InsufficientPriviledges;
                }

                Console.WriteLine("Stopping services...");

                // stop LPA services and the WIS
                foreach(var service in Settings.Default.ServiceNames)
                {
                    ServicesHelper.StopService("localhost", service);
                }

                Console.WriteLine("Searching for config files...");

                foreach (var filepath in Settings.Default.TargetFiles)
                {
                    try
                    {
                        if (File.Exists(filepath))
                        {
                            Console.WriteLine($"Found '{filepath}'. Updating...");
                            var content = File.ReadAllText(filepath);
                            var newContent = Replace(content, Settings.Default.OldString, Settings.Default.NewString, StringComparison.InvariantCultureIgnoreCase);

                            if(String.Equals(content, newContent))
                            {
                                Console.WriteLine($"The string '{Settings.Default.OldString}' was not found in '{filepath}'.");
                            }
                            else
                            {
                                File.WriteAllText(filepath, newContent);
                                Console.WriteLine($"File '{filepath}' updated successfully.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Target file '{filepath}' not found.");
                            exceptions.Add(new FileNotFoundException("Target file was not found.", filepath));
                        }
                    }
                    catch(Exception ex)
                    {
                        exceptions.Add(ex);
                    }
                }

                Console.WriteLine("Starting services...");

                // start LPA services and the WIS
                foreach (var service in Settings.Default.ServiceNames)
                {
                    ServicesHelper.StartService("localhost", service);
                }

                if(exceptions.Any())
                {
                    throw new AggregateException(exceptions);
                }

                Console.WriteLine("Updates complete with no errors.");

                return (int)ExitCode.Success;
            }
            catch(AggregateException ex)
            {
                Console.WriteLine(ex);
                return (int)ExitCode.FileAccessError;
            }
            catch(ServicesHelperException ex)
            {
                Console.WriteLine(ex);
                return (int)ExitCode.ServiceHelperError;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return (int)ExitCode.UnknownError;
            }
        }

        private static string Replace(string str, string oldValue, string newValue, StringComparison comparison)
        {
            StringBuilder sb = new StringBuilder();

            int previousIndex = 0;
            int index = str.IndexOf(oldValue, comparison);
            while (index != -1)
            {
                sb.Append(str.Substring(previousIndex, index - previousIndex));
                sb.Append(newValue);
                index += oldValue.Length;

                previousIndex = index;
                index = str.IndexOf(oldValue, index, comparison);
            }
            sb.Append(str.Substring(previousIndex));

            return sb.ToString();
        }
    }
}
