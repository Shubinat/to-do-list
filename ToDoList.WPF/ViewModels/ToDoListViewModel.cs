using System.Windows.Input;
using ToDoList.WPF.Commands;
using ToDoList.WPF.Stores;

namespace ToDoList.WPF.ViewModels
{
    public class ToDoListViewModel : BaseViewModel
    {
        private bool _isLoading;
        private string _errorMessage;
        public ToDoListViewModel(NotesStore notesStore, SelectedNoteStore selectedNoteStore, ModalNavigationStore modalNavigationStore)
        {
            NotesListingViewModel =  new NotesListingViewModel(notesStore, selectedNoteStore, modalNavigationStore);
            NotesDetailsViewModel = new NotesDetailsViewModel(selectedNoteStore);
            AddCommand = new OpenAddNoteCommand(notesStore, modalNavigationStore);
            LoadNotesCommand = new LoadNotesCommand(this, notesStore);
        }
        public NotesListingViewModel NotesListingViewModel { get; }
        public NotesDetailsViewModel NotesDetailsViewModel { get; }
        public ICommand AddCommand { get; }
        public ICommand LoadNotesCommand { get; }
        public bool IsLoading
        {
            get 
            { 
                return _isLoading;
            }
            set 
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
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
        public static ToDoListViewModel LoadViewModel(NotesStore notesStore, SelectedNoteStore selectedNoteStore, ModalNavigationStore modalNavigationStore)
        {
            ToDoListViewModel toDoListViewModel = new ToDoListViewModel(notesStore, selectedNoteStore, modalNavigationStore);

            toDoListViewModel.LoadNotesCommand.Execute(null);

            return toDoListViewModel;
        }
    }
}
