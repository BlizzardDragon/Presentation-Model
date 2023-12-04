using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PresentationModel
{
    public class ViewUserInfo : Popup
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _description;

        private IPresentationModelUserInfo _presentationModel;


        protected override void OnShow(object args)
        {
            if (args is not IPresentationModelUserInfo presentationModel)
            {
                throw new Exception("Expected Presentation Model");
            }

            base.OnShow(args);
            _presentationModel = presentationModel;

            _presentationModel.OnNameChanged += SetName;
            _presentationModel.OnIconChanged += SetIcon;
            _presentationModel.OnDescriptionChanged += SetDescription;
            
            _presentationModel.OnStart();
            UpdateStats();
        }

        protected override void OnHide()
        {
            base.OnHide();

            _presentationModel.OnNameChanged -= SetName;
            _presentationModel.OnIconChanged -= SetIcon;
            _presentationModel.OnDescriptionChanged -= SetDescription;

            _presentationModel.OnStop();
        }

        private void UpdateStats()
        {
            SetDescription();
            SetName();
            SetIcon();
        }

        private void SetName() => _name.text = _presentationModel.GetName();
        private void SetIcon() => _icon.sprite = _presentationModel.GetIcon();
        private void SetDescription() => _description.text = _presentationModel.GetDescription();
    }
}