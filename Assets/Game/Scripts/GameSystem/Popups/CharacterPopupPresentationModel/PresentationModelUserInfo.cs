using System;
using UnityEngine;
using Zenject;

namespace PresentationModel
{
    public class PresentationModelUserInfo : IPresentationModelUserInfo
    {
        [SerializeField] private UserInfo _userInfo;

        public event Action OnNameChanged;
        public event Action OnIconChanged;
        public event Action OnDescriptionChanged;


        [Inject]
        public void Construct(UserInfo userInfo) => _userInfo = userInfo;

        public void OnStart()
        {
            _userInfo.OnNameChanged += CallEvent_ChangeName;
            _userInfo.OnIconChanged += CallEvent_ChangeIcon;
            _userInfo.OnDescriptionChanged += CallEvent_ChangeDescription;
        }

        public void OnStop()
        {
            _userInfo.OnNameChanged -= CallEvent_ChangeName;
            _userInfo.OnIconChanged -= CallEvent_ChangeIcon;
            _userInfo.OnDescriptionChanged -= CallEvent_ChangeDescription;
        }

        private void CallEvent_ChangeName(string text) => OnNameChanged?.Invoke();
        private void CallEvent_ChangeIcon(Sprite sprite) => OnIconChanged?.Invoke();
        private void CallEvent_ChangeDescription(string text) => OnDescriptionChanged?.Invoke();

        public string GetName() => _userInfo.Name;
        public Sprite GetIcon() => _userInfo.Icon;
        public string GetDescription() => _userInfo.Description;
    }
}