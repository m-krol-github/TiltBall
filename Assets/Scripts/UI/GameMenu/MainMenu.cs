using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

namespace GameView
{
    public class MainMenu : BaseView
    {
        [SerializeField]
        private RectTransform mainPanel;

        [SerializeField]
        private TextMeshProUGUI gameTitle;

        [SerializeField]
        private RectTransform optPanel;

        [SerializeField]
        private TextMeshProUGUI newGameTitle;

        [SerializeField]
        private TextMeshProUGUI optionsTitle;

        [SerializeField]
        private TextMeshProUGUI quitTitle;
        
        [SerializeField]
        private Button startGameBtn;

        [SerializeField]
        private Button optionsBtn;

        [SerializeField]
        private Button quitGameBtn;


        private UnityAction onStartGame;
        private UnityAction onOptions;
        private UnityAction onQuitGame;

        public void InitGameMenu(UnityAction OnStart, UnityAction OptionsCallback)
        {
            this.onOptions = OptionsCallback;
            this.onStartGame = OnStart;

            this.startGameBtn.onClick.AddListener(StartGameCallback);
            this.optionsBtn.onClick.AddListener(OnOptionsCallback);
        }

        public override void ShowView()
        {
            base.ShowView();
        }

        public override void HideView()
        {
            base.HideView();
        }

        private void StartGameCallback()
        {
            onStartGame.Invoke();
        }

        private void OnOptionsCallback()
        {
            onOptions.Invoke();
        }
    }
}