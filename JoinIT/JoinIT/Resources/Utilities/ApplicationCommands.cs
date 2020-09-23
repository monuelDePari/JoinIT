﻿namespace JoinIT.Resources.Utilities
{
    using Prism.Commands;

    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _updateAllCommand;

        public CompositeCommand UpdateAllCommand
        {
            get
            {
                if(_updateAllCommand == null)
                {
                    _updateAllCommand = new CompositeCommand();
                }
                return _updateAllCommand;
            }
        }
    }
}
