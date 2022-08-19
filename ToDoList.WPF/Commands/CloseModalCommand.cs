﻿using ToDoList.WPF.Stores;

namespace ToDoList.WPF.Commands
{
    public class CloseModalCommand : BaseCommand
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        public CloseModalCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }
        public override void Execute(object parameter)
        {
            _modalNavigationStore.Close();
        }
    }
}
