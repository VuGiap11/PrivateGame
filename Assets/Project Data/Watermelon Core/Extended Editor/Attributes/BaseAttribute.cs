using System;

namespace TitleGame
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public abstract class BaseAttribute : Attribute
    {
        private Type targetAttributeType;

        public BaseAttribute(Type targetAttributeType)
        {
            this.targetAttributeType = targetAttributeType;
        }

        public Type TargetAttributeType
        {
            get
            {
                return this.targetAttributeType;
            }
        }
    }
}
