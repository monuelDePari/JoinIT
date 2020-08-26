namespace JoinIT.Resources.Utilities
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}
