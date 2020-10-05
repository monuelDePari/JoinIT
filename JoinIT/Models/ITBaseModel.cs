namespace Models
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using ServiceStack.DataAnnotations;

    public class ITBaseModel : INotifyPropertyChanged
    {

        [Unique]
        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
