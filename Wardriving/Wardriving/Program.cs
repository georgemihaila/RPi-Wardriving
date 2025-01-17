﻿using NativeWifi;

using System;
using System.Text;

namespace Wardriving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WlanClient client = new();
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                // Lists all available networks
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    Console.WriteLine("Found network with SSID {0}.", GetStringForSSID(network.dot11Ssid));
                }
            }

            static string GetStringForSSID(Wlan.Dot11Ssid ssid)
            {
                return Encoding.ASCII.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
            }
        }
    }
}
