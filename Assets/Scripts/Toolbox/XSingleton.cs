namespace Toolbox
{
    public class XSingleton<T> where T : new()
    {
        //
        // Static Properties
        //
        public static T Singleton
        {
            get
            {
                return XSingleton<T>.SingleNested._instance;
            }
        }

        //
        // Nested Types
        //
        private class SingleNested
        {
            public static readonly T _instance;
            static SingleNested()
            {
                XSingleton<T>.SingleNested._instance = ((default(T) == null) ? System.Activator.CreateInstance<T>() : default(T));
            }
        }
    }
}
