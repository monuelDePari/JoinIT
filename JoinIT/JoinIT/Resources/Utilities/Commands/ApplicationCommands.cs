namespace JoinIT.Resources.Utilities.Commands
{
    using Instructions;
    using System.Diagnostics.CodeAnalysis;
    using Prism.Commands;

    [ExcludeFromCodeCoverage]
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
