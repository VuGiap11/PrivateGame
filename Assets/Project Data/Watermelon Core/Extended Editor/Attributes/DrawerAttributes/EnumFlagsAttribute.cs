using System;

namespace TitleGame
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class EnumFlagsAttribute : DrawerAttribute
    {
        public EnumFlagsAttribute()
        {

        }
    }
}
