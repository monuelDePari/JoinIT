namespace JoinIT.Resources.Utilities.Services
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using Instructions;

    [ExcludeFromCodeCoverage]
    public class CustomMessageService : ICustomMessageService
    {
        public MessageBoxResult Show(string message)
        {
            return MessageBox.Show(message);
        }
    }
}
