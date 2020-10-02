namespace JoinIT.Resources.ViewModels
{
    using Utilities.Services.Instructions;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows;

    public class ITBaseViewModel : INotifyPropertyChanged
    {
        #region Fields
        private bool _isLoading;

        private ICustomMessageService _customMessageService;
        #endregion

        #region Properties
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors

        public ITBaseViewModel(ICustomMessageService customMessageService)
        {
            _customMessageService = customMessageService;
        }
        public ITBaseViewModel() { }
        #endregion

        #region Methods

        public virtual void OnLoaded()
        {
            PropertyChanged += OnCustomPropertyChanged;
        }

        public virtual void OnUnloaded()
        {
            PropertyChanged -= OnCustomPropertyChanged;
        }

        public virtual void OnCustomPropertyChanged(object sender, PropertyChangedEventArgs e) { }


        public async Task<T> RunTaskAsync<T>(Task<T> task)
        {
            T result = default(T);
            try
            {
                IsLoading = true;

                result = await task;
            }
            catch (Exception e)
            {
                _customMessageService.Show(e.Message);
            }
            finally
            {
                IsLoading = false;
            }

            return result;
        }
        public async Task RunTaskAsync(Task task)
        {
            try
            {
                IsLoading = true;

                await task;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string info = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}