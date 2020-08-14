using Unity;

namespace JoinIT.Resourses.Utilities
{
    public class ITUnityContainer
    {
        private static IUnityContainer _instance;

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
    }
}