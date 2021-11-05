namespace MapQS.Device.Simulator.Core.Mvvm
{
    public abstract class ViewModelBase : NotifyPropertyChangedObject
    {
        #region Public Deklaration

        internal object? Parent { get; private set; }

        #endregion

        internal void SetParent(object? obj)
        {
            if (Parent != null) return;
            Parent = obj;
        }

        internal virtual void OnOpened()
        {
            
        }
    }
}