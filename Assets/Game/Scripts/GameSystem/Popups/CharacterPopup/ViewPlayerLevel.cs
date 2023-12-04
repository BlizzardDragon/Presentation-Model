using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PresentationModel
{
    public class ViewPlayerLevel : Popup
    {
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _experience;
        [SerializeField] private Image _progressBarScale;
        [SerializeField] private Image _progressBarCompleted;
        [SerializeField] private ButtonLevelUp _buttonLevelUp;
        
        private IPresentationModelPlayerLevel _presentationModel;


        protected override void OnShow(object args)
        {
            if (args is not IPresentationModelPlayerLevel presentationModel)
            {
                throw new Exception("Expected Presentation Model");
            }

            base.OnShow(args);
            _presentationModel = presentationModel;

            _presentationModel.OnLevelUp += SetLevel;
            _presentationModel.OnLevelUp += UpdateExperience;
            _presentationModel.OnLevelUp += UpdateProgressBar;
            _presentationModel.OnLevelUp += CheckCanLevelUp;

            _presentationModel.OnExperienceChanged += UpdateExperience;
            _presentationModel.OnExperienceChanged += UpdateProgressBar;
            _presentationModel.OnExperienceChanged += CheckCanLevelUp;

            _presentationModel.OnAllowLevelUp += AllowLevelUp;
            _presentationModel.OnForbidLevelUp += ForbidLevelUp;
            
            _buttonLevelUp.GetButton().onClick.AddListener(OnButtonLevelUpClicked);
            
            _presentationModel.OnStart();
            UpdateStats();
        }

        protected override void OnHide()
        {
            base.OnHide();

            _presentationModel.OnLevelUp -= SetLevel;
            _presentationModel.OnLevelUp -= UpdateExperience;
            _presentationModel.OnLevelUp -= UpdateProgressBar;
            _presentationModel.OnLevelUp -= CheckCanLevelUp;
            
            _presentationModel.OnExperienceChanged -= UpdateExperience;
            _presentationModel.OnExperienceChanged -= UpdateProgressBar;
            _presentationModel.OnExperienceChanged -= CheckCanLevelUp;

            _presentationModel.OnAllowLevelUp -= AllowLevelUp;
            _presentationModel.OnForbidLevelUp -= ForbidLevelUp;
            
            _buttonLevelUp.GetButton().onClick.RemoveListener(OnButtonLevelUpClicked);

            _presentationModel.OnStop();
        }

        private void UpdateStats()
        {
            SetLevel();
            UpdateExperience();
            UpdateProgressBar();
            CheckCanLevelUp();
        }

        private void SetLevel() => _level.text = _presentationModel.GetLevel();
        private void UpdateExperience() => _experience.text = _presentationModel.GetExperienceSliderText();
        private void UpdateProgressBar() => _progressBarScale.fillAmount = _presentationModel.GetFillAmount();
        private void CheckCanLevelUp() => _presentationModel.CheckCanLevelUp();
        private void OnButtonLevelUpClicked() => _presentationModel.OnLevelUpClicked();

        private void AllowLevelUp()
        {
            _progressBarCompleted.enabled = true;
            _buttonLevelUp.ActivateButton();
        }

        private void ForbidLevelUp()
        {
            _progressBarCompleted.enabled = false;
            _buttonLevelUp.DeactivateButton();
        }
    }
}