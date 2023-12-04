using System;
using UnityEngine;
using Zenject;

namespace PresentationModel
{
    public class PresentationModelCharacterInfo : IPresentationModelCharacterInfo
    {
        [SerializeField] private CharacterInfo _characterInfo;

        private const int STATS_LIMIT = 6;

        public event Action OnStatChanged;


        [Inject]
        public void Construct(CharacterInfo characterInfo) => _characterInfo = characterInfo;

        public void OnStart()
        {
            _characterInfo.OnStatAdded += OnStatAdded;
            _characterInfo.OnStatRemoved += OnStatRemoved;

            var stats = GetStats();
            if (stats.Length > 0)
            {
                foreach (var stat in stats)
                {
                    OnStatAdded(stat);
                }
            }
        }

        public void OnStop()
        {
            _characterInfo.OnStatAdded -= OnStatAdded;
            _characterInfo.OnStatRemoved -= OnStatRemoved;

            var stats = GetStats();
            if (stats.Length > 0)
            {
                foreach (var stat in stats)
                {
                    OnStatRemoved(stat);
                }
            }
        }

        private CharacterStat[] GetStats() => _characterInfo.GetStats();
        private void InvokeOnStatChanged(int _ = 0) => OnStatChanged?.Invoke();

        private void OnStatAdded(CharacterStat newStat)
        {
            newStat.OnValueChanged += InvokeOnStatChanged;

            if (GetStats().Length > STATS_LIMIT)
            {
                _characterInfo.RemoveStat(newStat);
            }
            else
            {
                InvokeOnStatChanged();
            }
        }

        private void OnStatRemoved(CharacterStat newStat)
        {
            newStat.OnValueChanged -= InvokeOnStatChanged;
            InvokeOnStatChanged();
        }

        public string[] GetTextFromStats()
        {
            CharacterStat[] stats = GetStats();
            string[] texts = new string[stats.Length];

            for (int i = 0; i < stats.Length; i++)
            {
                texts[i] = stats[i].Name + ": " + stats[i].Value;
            }
            return texts;
        }
    }
}