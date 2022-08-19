using ToDoList.WPF.Stores;

namespace ToDoList.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        public MainViewModel(ModalNavigationStore modalNavigationStore, ToDoListViewModel toDoListViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            ToDoListViewModel = toDoListViewModel;
            _modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;
        }
        public ToDoListViewModel ToDoListViewModel { get; }
        public bool IsModalOpen => _modalNavigationStore.IsOpen;
        public BaseViewModel CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;

        private void ModalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(IsModalOpen));
            OnPropertyChanged(nameof(CurrentModalViewModel));
        }
        public override void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= ModalNavigationStore_CurrentViewModelChanged;

            base.Dispose();
        }
    }
}
