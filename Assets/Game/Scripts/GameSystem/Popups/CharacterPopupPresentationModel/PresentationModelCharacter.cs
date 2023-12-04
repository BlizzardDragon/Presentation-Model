using System;
using UnityEngine;
using Zenject;

namespace PresentationModel
{
    [Serializable]
    public class PresentationModelCharacter
    {
        [field: SerializeField] 
        public PresentationModelUserInfo PM_UserInfo { get; private set; } = new();

        [field: SerializeField] 
        public PresentationModelPlayerLevel PM_PlayerLevel { get; private set; } = new();

        [field: SerializeField] 
        public PresentationModelCharacterInfo PM_CharacterInfo { get; private set; } = new();
        
        
        [Inject]
        public void Init(CharacterInfo characterInfo, PlayerLevel playerLevel, UserInfo userInfo)
        {
            PM_UserInfo.Construct(userInfo);
            PM_PlayerLevel.Construct(playerLevel);
            PM_CharacterInfo.Construct(characterInfo);
        }
    }
}