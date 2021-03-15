using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using UnityEngine;
using PVEAlwaysOn;

namespace PVEAlwaysOn
{
    class Settings
    {
        public static bool isNewVersionAvailable()
        {
            WebClient client = new WebClient();
            client.Headers.Add("User-Agent: PVPAlwaysOn Server");
            string reply;
            try
            {
                reply = client.DownloadString(PVELOAD.ApiRepository);
                PVELOAD.newestVersion = reply.Split(new[] { "," }, StringSplitOptions.None)[0].Trim().Replace("\"", "").Replace("[{name:", "");
            }
            catch
            {
                Debug.Log("The newest version could not be determined.");
                PVELOAD.newestVersion = "Unknown";
            }

            if (PVELOAD.newestVersion != PVELOAD.version)
            {
                return true;
            }

            return false;
        }
    }
}
