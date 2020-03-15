using Lab03CSharp.Models;
using Lab03CSharp.Tools.MVVM;
using Lab03CSharp.Models.Exceptions;
using Lab03CSharp.Tools.Managers;
using Lab03CSharp.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace Lab03CSharp.ViewModel
{
    internal class UserFormViewModel : BaseViewModel
    {
        private Person _person;

        private string _nameField;  
        private string _surnameField;
        private string _emailField;
        private DateTime _birthDateField = System.DateTime.UtcNow;

        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _closeCommand;

        #region Properties

        #region FieldsDataFromView
        public string NameField
        {
            set { _nameField = value; }
            get { return _nameField; }
        }
        public string SurnameField
        {
            set { _surnameField = value; }
            get { return _surnameField; }
        }
        public string EmailField
        {
            set { _emailField = value; }
            get { return _emailField; }
        }
        public DateTime BirthDateField
        {
            set { _birthDateField = value; }
            get { return _birthDateField; }
        }
        #endregion

        #region ModelDataGetters  
        public string Name
        {
            get { return _person?.Name; }
        }
        public string Surname
        {
            get { return _person?.Surname; }
        }
        public string Email
        {
            get { return _person?.Email; }
        }
        public string BirthDate
        {
            get { return _person?.BirthDate.ToString(); }
        }
        public string IsAdult
        {
            get { if (_person == null) { return ""; } return _person.IsAdult ? "adult" : "child"; }
        }
        public string SunSign
        {
            get { return _person?.SunSign; }
        }
        public string ChineseSign
        {
            get { return _person?.ChineseSign; }
        }
        #endregion

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(ProceedInplementation,
                    o => CanExecuteCommand()));
            }
        }
        public bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(NameField) && !string.IsNullOrWhiteSpace(SurnameField) && !string.IsNullOrWhiteSpace(EmailField);
        }
        public RelayCommand<Object> CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }

        async private void ProceedInplementation(object obj)
        {

            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => ProceedData());
            LoaderManager.Instance.HideLoader();
        }

        private void ProceedData()
        {
            try
            {
                _person = new Person(NameField, SurnameField, EmailField, BirthDateField);
                if (_person.IsBirthday) { MessageBox.Show($"Happy birthday, {Name} !"); }
                OnPropertyChanged("Name");
                OnPropertyChanged("Surname");
                OnPropertyChanged("Email");
                OnPropertyChanged("BirthDate");
                OnPropertyChanged("IsAdult");
                OnPropertyChanged("SunSign");
                OnPropertyChanged("ChineseSign");
                OnPropertyChanged("IsBirthday");
            }
            catch (IncorrectBirthDateException ex)
            {
                MessageBox.Show("Ошибка: "+ ex.Message);
            }
            catch (IncorrectEmailException ex)
            {
                MessageBox.Show("Ошибка: "+ ex.Message);
            }
            catch (BornInFutureException ex)
            {
                MessageBox.Show("Ошибка: "+ ex.Message);
            }
           
            #endregion
        }
            

        
    }
}
