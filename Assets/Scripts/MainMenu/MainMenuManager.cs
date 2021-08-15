using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameView;
using Managers;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Utils;
using Storage;

namespace GameStart
{
    public class MainMenuManager : MonoBehaviour
    {
        public string levelName;
        public int setPlayerLiefesInGame = 3;

        [SerializeField]
        private InGameView gameView;
        public InGameView GameView => gameView;

        [SerializeField]
        private OptionsView optionsView;

        [SerializeField]
        private GamePanelView gamePanel;

        [SerializeField]
        private AudioSource audioS;
        [SerializeField]
        private AudioClip uiClip;


        [SerializeField]
        private StorageData storage;

        private void Start()
        {
            //temp
            PlayerPrefs.SetInt("Lifes", setPlayerLiefesInGame);
            //
            Handheld.Vibrate();
            //
            gameView.Top.HideView();
            gameView.Bottom.HideView();
            gameView.MainMenu.ShowView();

            gameView.MainMenu.InitGameMenu(InitGameLevel, InitOptions, QuitGame,ResetData,PrivacyPolicyOpen,BackView);
        }

        public void InitGameLevel()
        {
            SceneManager.UnloadSceneAsync("MainMenu");
            SceneManager.LoadScene("GameScene");
        }

        public void PlayUiSound()
        {
            audioS.PlayOneShot(uiClip);
        }

        public void InitOptions()
        {
            gamePanel.HideView();
            optionsView.ShowView();
        }

        public void ToggleSonudOn()
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        public void ToggleSonudOff()
        {
            PlayerPrefs.SetInt("Sound", 0);
        }

        public void ToggleMOn()
        {
            PlayerPrefs.SetInt("Music", 1);
        }

        public void ToggleMOff()
        {
            PlayerPrefs.SetInt("Music", 0);
        }

        public void QuitGame()
        {
            QuitGameConifmed();
        }

        public void QuitGameConifmed()
        {
            Application.Quit();
        }

        public void ResetData()
        {
            PlayerPrefs.SetInt("LastLevel", 0);
        }

        public void PrivacyPolicyOpen()
        {
            Application.OpenURL("");
        }

        public void BackView()
        {
            gamePanel.ShowView();
            optionsView.HideView();
        }
    }
}