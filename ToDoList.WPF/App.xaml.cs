using Microsoft.EntityFrameworkCore;
using System.Windows;
using ToDoList.Domain.Commands;
using ToDoList.Domain.Queries;
using ToDoList.EntityFramework;
using ToDoList.EntityFramework.Commands;
using ToDoList.EntityFramework.Queries;
using ToDoList.WPF.Stores;
using ToDoList.WPF.ViewModels;

namespace ToDoList.WPF
{
    public partial class App : Application
    {
        private readonly NotesDbContextFactory _notesDbContextFactory;

        private readonly ICreateNoteCommand _createNoteCommand;
        private readonly IDeleteNoteCommand _deleteNoteCommand;
        private readonly IUpdateNoteCommand _updateNoteCommand;
        private readonly IGetAllNotesQuery _getAllNotesQuery;

        private readonly SelectedNoteStore _selectedNoteStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly NotesStore _notesStore;
        public App()
        {
            string connectionString = "Data Source=Notes.db";

            _notesDbContextFactory = new NotesDbContextFactory(
                new DbContextOptionsBuilder().UseSqlite(connectionString).Options);

            _createNoteCommand = new CreateNoteCommand(_notesDbContextFactory);
            _deleteNoteCommand = new DeleteNoteCommand(_notesDbContextFactory);
            _updateNoteCommand = new UpdateNoteCommand(_notesDbContextFactory);
            _getAllNotesQuery = new GetAllNotesQuery(_notesDbContextFactory);

        _notesStore = new NotesStore(_createNoteCommand, _deleteNoteCommand, _updateNoteCommand, _getAllNotesQuery);
            _modalNavigationStore = new ModalNavigationStore();
            _selectedNoteStore = new SelectedNoteStore(_notesStore);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using (NotesDbContext context = _notesDbContextFactory.Create())
            {
                context.Database.Migrate();
            }

            ToDoListViewModel toDoListViewModel = 
                ToDoListViewModel.LoadViewModel(_notesStore, _selectedNoteStore, _modalNavigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, toDoListViewModel)
            };

            MainWindow.Show();
        }
    }
}
