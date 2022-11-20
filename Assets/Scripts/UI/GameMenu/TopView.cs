using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using Managers;
using Utils;

namespace GameView
{
    public class TopView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI touchToStart;

        [SerializeField]
        private RectTransform mainPanel;

        [SerializeField]
        private TextMeshProUGUI time;

        [SerializeField]
        private TextMeshProUGUI health;

        [SerializeField]
        private TextMeshProUGUI levelNumber;

        [SerializeField]
        private TextMeshProUGUI levelFinish;

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
            health.text = gameManager.playerLifes.ToString();
            time.text = gameManager.levelTime.ToString("F0");
            levelNumber.text = gameManager.levelNumber.ToString("D3");
            TouchTOStart();
            // ref to sound manager
            if (time.text == 11.ToString())
            {
                classManager.AudioManager.PlayLastTenSeconds();
            }
        }

        public override void ShowView()
        {
            base.ShowView();
        }

        public override void HideView()
        {
            base.HideView();
        }

        public void ShowFinish()
        {
            StartCoroutine(LevelF(1));
        }

        private IEnumerator LevelF(float t)
        {
            levelFinish.gameObject.SetActive(true);
            levelFinish.GetComponent<ScaleByAnimation>().StartAnimation();
            yield return new WaitForSeconds(t);
            levelFinish.gameObject.SetActive(false);
        }

        private void PauseButton()
        {
            OnPauseClick?.Invoke();
        }

        public bool TouchTOStart()
        {
            if (Values.GameValues.showStartText)
            {
                touchToStart.gameObject.SetActive(false);
                return false; 
            }
            else 
            {
                touchToStart.gameObject.SetActive(false);
                return true; 
            }

        }
    }
}