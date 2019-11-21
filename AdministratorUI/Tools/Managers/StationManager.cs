using System;
using System.Windows;
using KMA.MOOP.ATM.Client.AdminClient;

namespace KMA.MOOP.ATM.AdministratorUI.Tools.Managers
{
    internal static class StationManager
    {
        //internal static Account CurrentAccount { get; set; }

        internal static AdminClient AdminClient { get; private set; }

        internal static void InitializeAdminClient(AdminClient client)
        {
            AdminClient = client;
        }

        internal static void CloseApp()
        {

            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
