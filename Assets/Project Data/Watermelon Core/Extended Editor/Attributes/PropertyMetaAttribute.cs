using System;

namespace TitleGame
{
    public class PropertyMetaAttribute : BaseAttribute
    {
        public PropertyMetaAttribute(Type targetAttributeType) : base(targetAttributeType)
        {
        }
    }
}
