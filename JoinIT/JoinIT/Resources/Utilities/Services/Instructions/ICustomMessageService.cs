namespace JoinIT.Resources.Utilities.Services.Instructions
{
    using System.Windows;

    public interface ICustomMessageService
    {
        MessageBoxResult Show(string message);
    }
}
