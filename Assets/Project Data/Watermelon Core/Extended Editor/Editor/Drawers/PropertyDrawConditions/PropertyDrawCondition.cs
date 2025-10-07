using UnityEditor;

namespace TitleGame
{
    public abstract class PropertyDrawCondition
    {
        public abstract bool CanDrawProperty(SerializedProperty property);
    }
}
