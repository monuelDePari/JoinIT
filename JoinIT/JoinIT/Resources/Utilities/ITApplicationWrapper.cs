namespace JoinIT.Resources.Utilities
{
    using System.Windows;

    public class ITApplicationWrapper : IITApplication
    {
        public double FontSize
        {
            get
            {
                return Application.Current != null
                    ? Application.Current.MainWindow != null ? Application.Current.MainWindow.FontSize : default(double)
                    : default(double);
            }
            set
            {
                if (Application.Current != null && Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.FontSize = value;
                }
            }
        }
    }
}
