namespace JoinIT.Resources.Utilities
{
    using Prism.Commands;

    public interface IApplicationCommands
    {
        CompositeCommand UpdateAllCommand { get; }
    }
}
