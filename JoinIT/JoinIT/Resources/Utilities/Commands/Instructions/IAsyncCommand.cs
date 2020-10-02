namespace JoinIT.Resources.Utilities.Commands.Instructions
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}
