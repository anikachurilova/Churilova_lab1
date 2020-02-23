using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Churilova01.Models;
using Churilova01.Properties;
using Churilova01.Tools;
using Churilova01.Tools.Managers;


namespace Churilova01.ViewModels
{
    class BirthViewModel : INotifyPropertyChanged, ILoaderOwner
    {
        #region Fields
        private Birthdate _bDate = new Birthdate();
        #endregion

        #region Commands
        private RelayCommand<object> _ageCommand;
        #endregion

        #region Properties

        public DateTime BDate
        {
            get { return _bDate.BDate; }
            set {_bDate.BDate = value; }
        }

        public string WGoroscope {
            get { return _bDate.WGoroscope; }
          }
        public string CGoroscope { get { return _bDate.CGoroscope; } }

        public int Age
        {
            get { return _bDate.Age; }
        }
        #endregion

        #region Commands

        public RelayCommand<object> AgeCommand
        {
            get
              {
                  return _ageCommand ?? (_ageCommand = new RelayCommand<object>(BirthCalcImplementation, o => CanExecuteCommand()));

              }
        }
        #endregion
     

        private  void Calculate()
            {
                if (Birthdate.CalculateAge(BDate) > 135)
            {
                MessageBox.Show("Error! You are too old!");
            }
              else if (BDate.CompareTo(DateTime.Today) > 0)
                {
                    MessageBox.Show("Error! You don't exist yet!");
                }

                  else if (BDate.Month.CompareTo(DateTime.Today.Month) == 0 && BDate.Day.CompareTo(DateTime.Today.Day) == 0)
                   {
                    MessageBox.Show("Happy Birthday! Enjoy your special day!");
                    _bDate.CalculateAge();
                    _bDate.Westerngoroscope();
                    _bDate.Chinesegoroscope();

                    OnPropertyChanged("Age");
                    OnPropertyChanged("WGoroscope");
                    OnPropertyChanged("CGoroscope");
            }  else {
                    _bDate.CalculateAge();
                    _bDate.Westerngoroscope();
                    _bDate.Chinesegoroscope();

                    OnPropertyChanged("Age");
                    OnPropertyChanged("WGoroscope");
                    OnPropertyChanged("CGoroscope");
                }
            Thread.Sleep(1000);
            }
        public bool CanExecuteCommand()
        {
            return BDate!=null;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        #region Fields
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;
        #endregion

        #region Properties
        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private async void BirthCalcImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => Calculate());
            LoaderManager.Instance.HideLoader();
       
        }


        internal BirthViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }

    }
}
