using System;
using UnityEngine;
using Zenject;

namespace PresentationModel
{
    public class PresentationModelPlayerLevel : IPresentationModelPlayerLevel
    {
        [SerializeField] private PlayerLevel _playerLevel;

        public event Action OnLevelUp;
        public event Action OnExperienceChanged;
        public event Action OnAllowLevelUp;
        public event Action OnForbidLevelUp;

        private string _localizationHP = "HP";
        private string _localizationLevel = "Level";


        [Inject]
        public void Construct(PlayerLevel playerLevel) => _playerLevel = playerLevel;

        public void OnStart()
        {
            _playerLevel.OnLevelUp += CallEvent_OnLevelUp;
            _playerLevel.OnExperienceChanged += CallEvent_ChangedExperience;
        }

        public void OnStop()
        {
            _playerLevel.OnLevelUp -= CallEvent_OnLevelUp;
            _playerLevel.OnExperienceChanged -= CallEvent_ChangedExperience;
        }

        private void CallEvent_OnLevelUp() => OnLevelUp?.Invoke();
        private void CallEvent_ChangedExperience(int currentExp) => OnExperienceChanged?.Invoke();

        public void CheckCanLevelUp()
        {
            if (_playerLevel.CanLevelUp())
            {
                OnAllowLevelUp?.Invoke();
            }
            else
            {
                OnForbidLevelUp?.Invoke();
            }
        }

        public float GetFillAmount()
        {
            float currentExperience = _playerLevel.CurrentExperience;
            float requiredExperience = _playerLevel.RequiredExperience;

            float fillAmount = currentExperience / requiredExperience;
            return fillAmount;
        }

        public string GetExperienceSliderText()
        {
            float currentExperience = _playerLevel.CurrentExperience;
            float requiredExperience = _playerLevel.RequiredExperience;

            string text = $"{_localizationHP}: {currentExperience} / {requiredExperience}";;
            return text;
        }

        public string GetLevel()
        {
            int level = _playerLevel.CurrentLevel;
            string text = $"{_localizationLevel}: {level}";
            return text;
        }

        public void OnLevelUpClicked() => _playerLevel.LevelUp();

        public void SetLocalizationHP(string text) => _localizationHP = text;
        public void SetLocalizationLevel(string text) => _localizationLevel = text;
    }
}