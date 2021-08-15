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
        private GamePanelView gamePanelView;

        [SerializeField]
        private OptionsView optionsView;

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

        [SerializeField]
        private Button resetData;

        [SerializeField]
        private Button privacyPolicy;

        [SerializeField]
        private Button backButton;
        
        private UnityAction onStartGame;
        private UnityAction onOptions;
        private UnityAction onQuitGame;
        private UnityAction onResetData;
        private UnityAction onPPolicy;
        private UnityAction backBtn;

        public void InitGameMenu(UnityAction OnStart, UnityAction OptionsCallback, UnityAction QuitCallback, UnityAction ResetDataCallback, UnityAction PolicyCallback, UnityAction OnBack)
        {
            this.onOptions = OptionsCallback;
            this.onStartGame = OnStart;
            this.onQuitGame = QuitCallback;
            this.onResetData = ResetDataCallback;
            this.onPPolicy = PolicyCallback;
            this.backBtn = OnBack;

            this.startGameBtn.onClick.AddListener(StartGameCallback);
            this.optionsBtn.onClick.AddListener(OnOptionsCallback);
            this.quitGameBtn.onClick.AddListener(OnQuitGameCallback);
            this.resetData.onClick.AddListener(ResetData);
            this.privacyPolicy.onClick.AddListener(PPolicy);
            this.backButton.onClick.AddListener(Back);
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

        private void OnQuitGameCallback()
        {
            onQuitGame.Invoke();
        }

        private void ResetData()
        {
            onResetData.Invoke();
        }

        private void PPolicy()
        {
            onPPolicy.Invoke();
        }

        private void Back()
        {
            backBtn.Invoke();
        }
    }
}