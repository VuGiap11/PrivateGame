using System;

namespace TitleGame
{
    public class PropertyDrawerAttribute : BaseAttribute
    {
        public PropertyDrawerAttribute(Type targetAttributeType) : base(targetAttributeType)
        {
        }
    }
}
