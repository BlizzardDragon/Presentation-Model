using System;
using UnityEngine;

namespace PresentationModel
{
    public class ViewCharacterInfo : Popup
    {
        [SerializeField] private PopUpStat[] _popUpStats;

        private IPresentationModelCharacterInfo _presentationModel;


        protected override void OnShow(object args)
        {
            if (args is not IPresentationModelCharacterInfo presentationModel)
            {
                throw new Exception("Expected Presentation Model");
            }

            base.OnShow(args);
            _presentationModel = presentationModel;
            _presentationModel.OnStatChanged += UpdatePopUpStats;
            _presentationModel.OnStart();
        }

        protected override void OnHide()
        {
            base.OnHide();
            _presentationModel.OnStatChanged -= UpdatePopUpStats;
            _presentationModel.OnStop();
        }

        private void UpdatePopUpStats()
        {
            string[] texts = _presentationModel.GetTextFromStats();

            for (int i = 0; i < _popUpStats.Length; i++)
            {
                if (i < texts.Length)
                {
                    _popUpStats[i].SetText(texts[i]);
                    _popUpStats[i].SetActive(true);
                }
                else
                {
                    _popUpStats[i].SetActive(false);
                }
            }
        }
    }
}