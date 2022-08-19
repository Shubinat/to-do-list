using ToDoList.Domain.Models;
using ToDoList.WPF.Stores;

namespace ToDoList.WPF.ViewModels
{
    public class NotesDetailsViewModel : BaseViewModel
    {
        private readonly SelectedNoteStore _selectedNoteStore;
        public NotesDetailsViewModel(SelectedNoteStore selectedNoteStore)
        {
            _selectedNoteStore = selectedNoteStore;
            _selectedNoteStore.SelectedNoteChanged += SelectedNoteStore_SelectedNoteChanged;
        }
        private Note Note => _selectedNoteStore.SelectedNote;

        public string Title => Note?.Title;
        public string Description => Note?.Description ?? "Click on the note to see detailed information.";
        public string Date => Note?.Date.ToString("dd.MM.yyyy");

        private void SelectedNoteStore_SelectedNoteChanged()
        {
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Date));
        }
    }
}
