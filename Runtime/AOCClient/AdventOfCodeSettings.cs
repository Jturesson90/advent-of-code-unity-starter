using UnityEngine;

namespace AdventOfCode.AOCClient
{
    public class AdventOfCodeSettings : ScriptableObject, IAdventOfCodeSettings
    {
        [SerializeField] public string session;
        [SerializeField] public int year;

        private static AdventOfCodeSettings _instance;

        public static IAdventOfCodeSettings Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = CreateInstance<AdventOfCodeSettings>();
                _instance.hideFlags = HideFlags.HideAndDontSave;
                return _instance;
            }
        }

        public string Session => session;
        public int Year => year;
    }
}