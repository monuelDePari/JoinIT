namespace JoinIT.Resources.Utilities.Commands.Instructions
{
    using Prism.Commands;

    public interface IApplicationCommands
    {
        CompositeCommand UpdateAllCommand { get; }
    }
}
