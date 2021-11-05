using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace MapQS.Device.Simulator.Core.Mvvm
{
    public abstract class NotifyPropertyChangedObject : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     Set the value to the private Property and raises the PropertyChangedEvent for this Property
        /// </summary>
        /// <typeparam name="TD"></typeparam>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <param name="actionAfterChange"></param>
        protected void SetPropertyValue<TD>(ref TD property, TD value, Action? actionAfterChange = null,
            [CallerMemberName] string propertyName = ""
        )
        {
            property = value;
            OnPropertyChanged(propertyName);
            actionAfterChange?.Invoke();
        }

        #endregion
    }
}