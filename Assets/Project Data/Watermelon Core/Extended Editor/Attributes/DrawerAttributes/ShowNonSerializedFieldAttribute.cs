using System;

namespace TitleGame
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ShowNonSerializedFieldAttribute : DrawerAttribute
    {
    }
}
