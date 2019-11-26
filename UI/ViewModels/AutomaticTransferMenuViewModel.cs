using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KMA.MOOP.ATM.UI.Tools;
using KMA.MOOP.ATM.UI.Tools.Managers;
using KMA.MOOP.ATM.UI.Tools.Navigation;

namespace KMA.MOOP.ATM.UI.ViewModels
{
    internal class AutomaticTransferMenuViewModel:BaseViewModel
    {
        private short _numTextBox;
        private string _cardNumber;
        private string _transferSum;
        private string _selectedDate;
        private bool _freq0 = true;
        private bool _freq1;
        private bool _freq2;
        private bool _freq3;


        public bool Freq0
        {
            get => _freq0;
            set
            {
                _freq0 = value;
                OnPropertyChanged();
            }
        }

        public bool Freq1
        {
            get => _freq1;
            set
            {
                _freq1 = value;
                OnPropertyChanged();
            }
        }

        public bool Freq2
        {
            get => _freq2;
            set
            {
                _freq2 = value;
                OnPropertyChanged();
            }
        }

        public bool Freq3
        {
            get => _freq3;
            set
            {
                _freq3 = value;
                OnPropertyChanged();
            }
        }

        public string Frequency { get; set; }

        private ICommand _frequencyCommand;

        public ICommand FrequencyCommand => _frequencyCommand ??
                                         (_frequencyCommand =
                                             new RelayCommand<object>(FrequencyImplementation));

        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
                OnPropertyChanged();
            }
        }

        public string TransferSum
        {
            get => _transferSum;
            set
            {
                _transferSum = value;
                if (_transferSum.StartsWith("0"))
                    _transferSum = _transferSum.Substring(1);
                OnPropertyChanged();
            }
        }

        public string SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (value.Length <= 10)
                {
                    _selectedDate = value;
                    if (_selectedDate.Length == 3)
                        if (_selectedDate.Last() == '.')
                            _selectedDate.Remove(2);
                        else
                            _selectedDate = _selectedDate.Insert(2, ".");

                    if (_selectedDate.Length == 6)
                        if (_selectedDate.Last() == '.')
                            _selectedDate.Remove(5);
                        else
                            _selectedDate = _selectedDate.Insert(5, ".");

                    OnPropertyChanged();
                }
            }
        }

        public void FrequencyImplementation(object obj)
        {
            Frequency = (string) obj;
        }

        private async void AcceptImplementation(object obj)
        {
            if (_transferSum.Equals("0"))
                return;
            LoaderManager.Instance.ShowLoader();
            string res = "";
            var result = await Task.Run(() =>
            {
                try
                {
                    double ? daysPeriod = null;
                    switch (Frequency)
                    {
                        case "Weekly":
                            daysPeriod = 7;
                            break;
                        case "Monthly":
                            daysPeriod = 30;
                            break;
                        case "Every Year":
                            daysPeriod = 365;
                            break;
                    }

                    DateTime startDate;
                    if(string.IsNullOrEmpty(_selectedDate))
                        startDate = DateTime.Now;
                    else
                        try
                        {
                            startDate = Convert.ToDateTime(_selectedDate);
                        }
                        catch (Exception)
                        {
                            res = "Incorrect start date";
                            return false;
                        }

                    res = StationManager.ATMClient.AddTransaction(StationManager.CurrentAccount, 
                        StationManager.CurrentAccount.Pin, _cardNumber, Convert.ToUInt32(_transferSum),
                        startDate, daysPeriod);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }

                return true;
            });
            MessageBox.Show(res);
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                NavigationManager.Instance.Navigate(ViewType.Menu);
                CardNumber = "";
                TransferSum = "00";
            }
        }

        public override void ClearImplementation(object obj)
        {
            _numTextBox = 0;
            CardNumber = "";
            TransferSum = "00";
            SelectedDate = "";
        }

        public override void CancelImplementation(object obj)
        {
            ClearImplementation(obj);
            NavigationManager.Instance.Navigate(ViewType.Menu);
        }

        public override void EnterImplementation(object obj)
        {
            AcceptImplementation(obj);
        }


        public override void Press0Implementation(object obj) { AddDigit("0"); }
        public override void Press1Implementation(object obj) { AddDigit("1"); }
        public override void Press2Implementation(object obj) { AddDigit("2"); }
        public override void Press3Implementation(object obj) { AddDigit("3"); }
        public override void Press4Implementation(object obj) { AddDigit("4"); }
        public override void Press5Implementation(object obj) { AddDigit("5"); }
        public override void Press6Implementation(object obj) { AddDigit("6"); }
        public override void Press7Implementation(object obj) { AddDigit("7"); }
        public override void Press8Implementation(object obj) { AddDigit("8"); }
        public override void Press9Implementation(object obj) { AddDigit("9");}

        private void AddDigit(string digit)
        {
            switch (_numTextBox)
            {
                case 0:
                    CardNumber += digit;
                    break;
                case 1:
                    SelectedDate += digit;
                    break;
                case 2:
                    TransferSum += digit;
                    break;
            }
        }

        public override void Button21Implementation(object obj)
        {
            Freq0 = true;
            Freq1 = false;
            Freq2 = false;
            Freq3 = false;
        }

        public override void Button22Implementation(object obj)
        {
            Freq0 = false;
            Freq1 = true;
            Freq2 = false;
            Freq3 = false;
        }

        public override void Button23Implementation(object obj)
        {
            Freq0 = false;
            Freq1 = false;
            Freq2 = true;
            Freq3 = false;
        }

        public override void Button24Implementation(object obj)
        {
            Freq0 = false;
            Freq1 = false;
            Freq2 = false;
            Freq3 = true;
        }

        public override void Button11Implementation(object obj)
        {
            _numTextBox = 0;
        }

        public override void Button12Implementation(object obj)
        {
            _numTextBox = 1;
        }

        public override void Button14Implementation(object obj)
        {
            _numTextBox = 2;
        }
    }
}
