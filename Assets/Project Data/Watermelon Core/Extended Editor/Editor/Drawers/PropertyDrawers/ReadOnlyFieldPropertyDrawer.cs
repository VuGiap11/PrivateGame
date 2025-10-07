using UnityEditor;
using UnityEngine;

namespace TitleGame
{
    [PropertyDrawer(typeof(ReadOnlyFieldAttribute))]
    public class ReadOnlyFieldPropertyDrawer : PropertyDrawer
    {
        public override void DrawProperty(SerializedProperty property)
        {
            using (new EditorGUI.DisabledScope(disabled: true))
            {
                EditorDrawUtility.DrawPropertyField(property);
            }
        }
    }
}
