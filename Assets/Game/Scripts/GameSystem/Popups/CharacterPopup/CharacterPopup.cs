using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PresentationModel
{
    public class CharacterPopup : Popup
    {
        [SerializeField] private GameObject _popup;
        [SerializeField] private Button _closeButton;

        [Space(15)]
        [SerializeField] private ViewUserInfo _viewUserInfo;
        [SerializeField] private ViewPlayerLevel _viewPlayerLevel;
        [SerializeField] private ViewCharacterInfo _viewCharacterInfo;
        
        [Space(15)]
        [ShowInInspector] private PresentationModelCharacter _pM_Character;


        [Inject]
        public void Construct(PresentationModelCharacter PM_Character)
        {
            _pM_Character = PM_Character;
        }

        protected override void OnShow(object args)
        {
            base.OnShow(args);
            _popup.SetActive(true);

            _viewUserInfo.Show(_pM_Character.PM_UserInfo);
            _viewPlayerLevel.Show(_pM_Character.PM_PlayerLevel);
            _viewCharacterInfo.Show(_pM_Character.PM_CharacterInfo);

            _closeButton.onClick.AddListener(OnButtonCloseClicked);
        }

        protected override void OnHide()
        {
            base.OnHide();
            _popup.SetActive(false);

            _viewUserInfo.Hide();
            _viewPlayerLevel.Hide();
            _viewCharacterInfo.Hide();

            _closeButton.onClick.RemoveListener(OnButtonCloseClicked);
        }

        private void OnButtonCloseClicked() => Hide();
    }
}