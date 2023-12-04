using FrameworkUnity.OOP.Interfaces.Listeners;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PresentationModel
{
    public class PopupManager : MonoBehaviour, IStartGameListener
    {
        [SerializeField] private CharacterPopup _viewPopup;

        [Header("Data")]
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _description;
        [SerializeField] private StatsConfig _config;

        [Header("Test")]
        [ShowInInspector] private PresentationModelCharacter _presentationModel;

        private UserInfo _userInfo;
        private CharacterInfo _characterInfo;


        [Inject]
        public void Construct(
            UserInfo userInfo,
            CharacterInfo characterInfo,
            PresentationModelCharacter presentationModel)
        {
            _userInfo = userInfo;
            _characterInfo = characterInfo;
            _presentationModel = presentationModel;
        }

        [Button]
        public void ShowPopup() => _viewPopup.Show();

        public void OnStartGame()
        {
            InstallUserInfo();
            InstallCharacterInfo();
        }

        private void InstallUserInfo()
        {
            _userInfo.ChangeName(_name);
            _userInfo.ChangeIcon(_icon);
            _userInfo.ChangeDescription(_description);
        }

        public void InstallCharacterInfo()
        {
            foreach (var stat in _config.CharacterStats)
            {
                _characterInfo.AddStat(stat);

                int randomValue = Random.Range(1, 31);
                stat.ChangeValue(randomValue);
            }
        }
    }
}
