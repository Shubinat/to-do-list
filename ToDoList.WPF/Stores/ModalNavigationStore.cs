using System;
using ToDoList.WPF.ViewModels;

namespace ToDoList.WPF.Stores
{
    public class ModalNavigationStore
    {
        public event Action CurrentViewModelChanged;

        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get 
            {
                return _currentViewModel;
            }
            set 
            { 
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }
        public bool IsOpen => CurrentViewModel != null;

        public void Close()
        {
            CurrentViewModel = null;
        }
    }
}
