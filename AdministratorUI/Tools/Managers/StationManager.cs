using System;
using System.Windows;
using KMA.MOOP.ATM.Client.AdminClient;

namespace KMA.MOOP.ATM.AdministratorUI.Tools.Managers
{
    internal static class StationManager
    {
        internal static DBModels.Client CurrentClient { get; set; }

        internal static AdminClient AdminClient { get; private set; }

        internal static void InitializeAdminClient(AdminClient admin)
        {
            AdminClient = admin;
        }

        internal static void InitializeCurrentClient(DBModels.Client client)
        {
            CurrentClient = client;
        }

        internal static void CloseApp()
        {

            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
