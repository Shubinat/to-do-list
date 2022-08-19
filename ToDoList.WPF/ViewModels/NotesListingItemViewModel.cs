using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoList.Domain.Models;
using ToDoList.WPF.Commands;
using ToDoList.WPF.Stores;

namespace ToDoList.WPF.ViewModels
{
    public class NotesListingItemViewModel : BaseViewModel
    {
        private bool _isDeleting;
        private string _errorMessage;
        public NotesListingItemViewModel(Note note, NotesStore notesStore, ModalNavigationStore modalNavigationStore)
        {
            Note = note;
            EditCommand = new OpenEditNoteCommand(this, notesStore, modalNavigationStore);
            DeleteCommand = new DeleteNoteCommand(this, notesStore);
        }

        public Note Note { get; private set; }
        public string Title => Note.Title;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public bool IsDeleting
        {
            get
            {
                return _isDeleting;
            }
            set
            {
                _isDeleting = value;
                OnPropertyChanged(nameof(IsDeleting));
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

        public void Update(Note note)
        {
            Note = note;
            OnPropertyChanged(nameof(Title));
        }
    }
}
