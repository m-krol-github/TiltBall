using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using Managers;

namespace GameView
{
    public class TopView : BaseView
    {
        [SerializeField]
        private RectTransform mainPanel;

        [SerializeField]
        private TextMeshProUGUI time;

        [SerializeField]
        private TextMeshProUGUI health;

        [SerializeField]
        private TextMeshProUGUI levelNumber;

        [SerializeField]
        private Button pause;

        private ClassManager classManager;
        private GameManager gameManager;
        private UnityAction OnPauseClick;

        public void InitTopView(ClassManager classManager, UnityAction PauseCallback) 
        {
            this.classManager = classManager;
            this.OnPauseClick = PauseCallback;
            this.gameManager = classManager.GameManager;

            //this.pause.onClick.AddListener(PauseButton);
        }

        public void UpdateView()
        {
            time.text = gameManager.levelTime.ToString("F0");

            levelNumber.text = gameManager.levelNumber.ToString("D3");
        }

        public override void ShowView()
        {
            base.ShowView();
        }

        public override void HideView()
        {
            base.HideView();
        }

        private void PauseButton()
        {
            OnPauseClick?.Invoke();
        }
    }
}