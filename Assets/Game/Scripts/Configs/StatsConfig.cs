using UnityEngine;

namespace PresentationModel
{
    [CreateAssetMenu(
        fileName = "StatsConfig",
        menuName = "ScriptableObject/StatsConfig",
        order = 0)]
    public class StatsConfig : ScriptableObject
    {
        public CharacterStat[] CharacterStats;
    }
}