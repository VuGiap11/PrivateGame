using UnityEngine;

namespace TitleGame
{
    public abstract class PUCustomSettings : PUSettings
    {
        [Group("Variables")]
        [SerializeField] string title;
        public string Title => title;
    }
}
