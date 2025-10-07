using System.Reflection;

namespace TitleGame
{
    public abstract class MethodDrawer
    {
        public abstract void DrawMethod(UnityEngine.Object target, MethodInfo methodInfo);
    }
}
