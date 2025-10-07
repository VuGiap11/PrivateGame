using UnityEngine;
using TitleGame;
using UnityEditor;

namespace TitleGame
{
    public static class SaveActionsMenu
    {
        [MenuItem("Actions/Remove Save", priority = 1)]
        private static void RemoveSave()
        {
            PlayerPrefs.DeleteAll();
            SaveController.DeleteSaveFile();
        }

        [MenuItem("Actions/Remove Save", true)]
        private static bool RemoveSaveValidation()
        {
            return !Application.isPlaying;
        }
    }
}