using System.Collections;
using UnityEngine;

namespace TitleGame
{
    public abstract class LevelSpawnAnimation : ScriptableObject
    {
        protected Coroutine animationCoroutine;

        public void Play(LevelRepresentation levelRepresentation, SimpleCallback onAnimationCompleted)
        {
            Clear();

            animationCoroutine = Tween.InvokeCoroutine(SpawnLevelCoroutine(levelRepresentation, onAnimationCompleted));
        }

        public virtual void Clear()
        {
            if (animationCoroutine != null)
                Tween.StopCustomCoroutine(animationCoroutine);
        }

        protected abstract IEnumerator SpawnLevelCoroutine(LevelRepresentation levelRepresentation, SimpleCallback onAnimationCompleted);
    }
}