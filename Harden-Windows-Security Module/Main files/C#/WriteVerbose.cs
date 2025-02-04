using System;
using System.Management.Automation.Host;

#nullable enable

namespace HardenWindowsSecurity
{
    public static class VerboseLogger
    {
        /// <summary>
        /// Write a verbose message to the console
        /// The verbose messages are not redirectable in PowerShell
        /// https://learn.microsoft.com/en-us/dotnet/api/system.management.automation.host.pshostuserinterface
        /// </summary>
        /// <param name="message"></param>
        public static void Write(string message)
        {
            try
            {
                if (string.Equals(HardenWindowsSecurity.GlobalVars.VerbosePreference, "Continue", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(HardenWindowsSecurity.GlobalVars.VerbosePreference, "Inquire", StringComparison.OrdinalIgnoreCase))
                {
                    HardenWindowsSecurity.GlobalVars.Host!.UI!.WriteVerboseLine(message);
                }
            }
            // Do not do anything if errors occur
            // Since many methods write to the console asynchronously this can throw errors
            // implement better ways such as using log file or in the near future a GUI for writing verbose messages when -Verbose is used
            catch { }
        }
    }
}
