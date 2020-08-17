using Unity;

namespace JoinIT.Resourses.Utilities
{
    public class ITUnityContainer
    {
        #region Fields
        private static IUnityContainer _instance;
        #endregion

        #region Constructors
        public static IUnityContainer GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UnityContainer();
                }

                return _instance;
            }
        }
        #endregion
    }
}