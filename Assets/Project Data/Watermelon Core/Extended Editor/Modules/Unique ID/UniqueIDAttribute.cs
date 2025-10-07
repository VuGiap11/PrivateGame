using System;
using UnityEngine;

namespace TitleGame
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class UniqueIDAttribute : PropertyAttribute
    {
    }
}
