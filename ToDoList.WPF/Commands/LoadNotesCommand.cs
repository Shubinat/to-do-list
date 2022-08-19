using System;
using System.Threading.Tasks;
using ToDoList.WPF.Stores;
using ToDoList.WPF.ViewModels;

namespace ToDoList.WPF.Commands
{
    public class LoadNotesCommand : AsyncCommand
    {
        private readonly NotesStore _notesStore;
        private readonly ToDoListViewModel _toDoListViewModel;

        public LoadNotesCommand(ToDoListViewModel toDoListViewModel, NotesStore notesStore)
        {
            _toDoListViewModel = toDoListViewModel;
            _notesStore = notesStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _toDoListViewModel.IsLoading = true;
            try
            {
                await _notesStore.Load();
            }
            catch
            {
                _toDoListViewModel.ErrorMessage = "Failed to loading To Do List. Please restart the application.";
            }
            finally
            {
                _toDoListViewModel.IsLoading = false;
            }
        }
    }
}
