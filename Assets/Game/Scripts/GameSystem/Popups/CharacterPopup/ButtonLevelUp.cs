using UnityEngine;
using UnityEngine.UI;

namespace PresentationModel
{
    [RequireComponent(typeof(Button))]
    public class ButtonLevelUp : MonoBehaviour
    {
        [SerializeField] private Sprite _activeButton;
        [SerializeField] private Sprite _inactiveButton;
        
        private Button _button;


        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void ActivateButton()
        {
            _button.image.sprite = _activeButton;
            _button.interactable = true;
        }

        public void DeactivateButton()
        {
            _button.image.sprite = _inactiveButton;
            _button.interactable = false;
        }

        public Button GetButton() => _button;
    }
}
