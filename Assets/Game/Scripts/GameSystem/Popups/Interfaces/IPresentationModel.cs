using System;
using UnityEngine;

namespace PresentationModel
{
    public interface IPresentationModel
    {
        void OnStart();
        void OnStop();
    }

    public interface IPresentationModelCharacterInfo : IPresentationModel
    {
        public event Action OnStatChanged;

        public string[] GetTextFromStats();
    }

    public interface IPresentationModelPlayerLevel : IPresentationModel
    {
        public event Action OnLevelUp;
        public event Action OnExperienceChanged;
        public event Action OnAllowLevelUp;
        public event Action OnForbidLevelUp;

        string GetLevel();
        string GetExperienceSliderText();
        float GetFillAmount();
        void OnLevelUpClicked();
        void CheckCanLevelUp();
    }

    public interface IPresentationModelUserInfo : IPresentationModel
    {
        public event Action OnNameChanged;
        public event Action OnIconChanged;
        public event Action OnDescriptionChanged;

        string GetName();
        Sprite GetIcon();
        string GetDescription();
    }

    // public interface ICharacterPresentationModel : IPresentationModel
    // {
        // public event Action OnNameChanged;
        // public event Action OnIconChanged;
        // public event Action OnDescriptionChanged;

        // public event Action OnLevelUp;
        // public event Action OnExperienceChanged;
        // public event Action OnAllowLevelUp;
        // public event Action OnForbidLevelUp;

        // public event Action<CharacterStat> OnStatAdded;
        // public event Action<CharacterStat> OnStatRemoved;


        // string GetName();
        // Sprite GetIcon();
        // string GetDescription();

        // string GetLevel();
        // string GetExperienceSliderText();
        // void OnLevelUpClicked();
        // float GetFillAmount();
        // void CheckCanLevelUp();
    // }
}
