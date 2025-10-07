using System;

namespace TitleGame
{
    public class PropertyDrawConditionAttribute : BaseAttribute
    {
        public PropertyDrawConditionAttribute(Type targetAttributeType) : base(targetAttributeType)
        {
        }
    }
}
