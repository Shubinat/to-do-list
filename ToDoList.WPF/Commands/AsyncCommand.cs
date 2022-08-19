using System;
using System.Threading.Tasks;

namespace ToDoList.WPF.Commands
{
    public abstract class AsyncCommand : BaseCommand
    {
        private bool _isExecuting = false;
        public bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }
        public override async void Execute(object parameter)
        {
            IsExecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception)
            {

            }
            finally
            {
                IsExecuting = false;
            } 
        }
        public override bool CanExecute(object parameter)
        {
            return !_isExecuting && base.CanExecute(parameter);
        }
        public abstract Task ExecuteAsync(object parameter);

    }
}
