﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CoffeeAppSpring2024inclass.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //private readonly IDataService<Item> _dataService;

        //using dependency injection to inject the data service into the view model
        public BaseViewModel()
        {
        }

        bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                SetProperty(ref _isBusy, value);
            }
        }

       
        protected bool SetProperty<T>(ref T backingStore, T value, 
            [CallerMemberName] string propertyName = "", 
            Action? onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


    }
}
