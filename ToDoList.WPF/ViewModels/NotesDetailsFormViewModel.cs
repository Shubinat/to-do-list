using System;
using System.Windows.Input;

namespace ToDoList.WPF.ViewModels
{
    public class NotesDetailsFormViewModel : BaseViewModel
    {
        private string _title;
        private string _description;
        private DateTime? _date;
        private bool _isAccepting;
        private string _errorMessage;
        public NotesDetailsFormViewModel(ICommand acceptCommand, ICommand cancelCommand)
        {
            AcceptCommand = acceptCommand;
            CancelCommand = cancelCommand;
        }
        public string Title
        {
            get
            { 
                return _title;
            }
            set 
            { 
                _title = value;
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(CanAccept));
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
                OnPropertyChanged(nameof(CanAccept));
            }
        }
        public DateTime? Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
                OnPropertyChanged(nameof(CanAccept));
            }
        }
        public ICommand AcceptCommand { get; }
        public ICommand CancelCommand { get; }
        public bool CanAccept => !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Description) && Date.HasValue;
        public bool IsAccepting
        {
            get
            {
                return _isAccepting;
            }
            set
            {
                _isAccepting = value;
                OnPropertyChanged(nameof(IsAccepting));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }
        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
    }
}
