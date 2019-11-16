using System;
using System.Windows;
using KMA.MOOP.ATM.Client.ATMClient;
using KMA.MOOP.ATM.DBModels;

namespace KMA.MOOP.ATM.UI.Tools.Managers
{
    internal static class StationManager
    {
        internal static Account CurrentAccount { get; set; }

        internal static BaseViewModel CurrentViewModel { get; set; }

        internal static ATMClient ATMClient { get; private set; }

        internal static void InitializeATMClient(ATMClient client)
        {
            ATMClient = client;
        }

        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
