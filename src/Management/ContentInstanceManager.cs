using System.Reflection;

namespace BoidSimulation.Management
{
    public static class ContentInstanceManager
    {
        public static List<IContentInstance> ContentInstances { get; private set; }
      
        internal static void LoadInstances()
        {
            ContentInstances = new List<IContentInstance>();

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (typeof(IContentInstance).IsAssignableFrom(type) && !type.IsAbstract && type.IsClass)
                    {
                        IContentInstance instance = (IContentInstance)Activator.CreateInstance(type);
                        instance.LoadContent();
                        
                        ContentInstances.Add(instance);
                    }
                }
            }
        }

        internal static void UnloadInstances()
        {
            foreach (IContentInstance instance in ContentInstances)
            {
                instance.UnloadContent();
            }

            ContentInstances?.Clear();
            ContentInstances = null;
        }

        public static T GetInstance<T>() where T : IContentInstance
        {
            return (T)ContentInstances.Find(x => x.GetType() == typeof(T));
        }
    }
}