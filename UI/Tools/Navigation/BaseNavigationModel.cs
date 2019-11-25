using System;
using System.Collections.Generic;
using System.Windows;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Views;

namespace KMA.MOOP.ATM.UI.Tools.Navigation
{
    internal abstract class BaseNavigationModel: INavigationModel
    {
        private readonly IContentOwner _contentOwner;
        private readonly Dictionary<ViewType, INavigatable> _viewsDictionary;

        protected BaseNavigationModel(IContentOwner contentOwner)
        {
            _contentOwner = contentOwner;
            _viewsDictionary = new Dictionary<ViewType, INavigatable>();
        }

        protected IContentOwner ContentOwner => _contentOwner;
        protected Dictionary<ViewType, INavigatable> ViewsDictionary => _viewsDictionary;

        public void Navigate(ViewType viewType)
        {

            if (!ViewsDictionary.ContainsKey(viewType))
                InitializeView(viewType);
            else
            if (viewType == ViewType.AccountInfo)
            {
                _viewsDictionary.Remove(viewType);
                _viewsDictionary.Add(viewType,new AccountInfoView());
            }

            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];
            StationManager.CurrentViewModel = (BaseViewModel) ViewsDictionary[viewType].GetContext();

        }

        protected abstract void InitializeView(ViewType viewType);
    }
}
