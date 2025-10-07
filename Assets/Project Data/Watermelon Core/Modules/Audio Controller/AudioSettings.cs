using UnityEngine;

namespace TitleGame
{
    [CreateAssetMenu(fileName = "Audio Settings", menuName = "Settings/Audio Settings")]
    public class AudioSettings : ScriptableObject
    {
        [SerializeField] Music music;
        public Music Music => music;

        [SerializeField] Sounds sounds;
        public Sounds Sounds => sounds;
    }
}

// -----------------
// Audio Controller v 0.4
// -----------------