using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameView;
using Managers;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace GameStart
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField]
        private InGameView gameView;
        public InGameView GameView => gameView;

        [SerializeField]
        private AudioSource audio;


        // Start is called before the first frame update
        private void Start()
        {
            gameView.Top.HideView();
            gameView.Bottom.HideView();
            gameView.MainMenu.ShowView();

            gameView.MainMenu.InitGameMenu(InitGameLevel, InitOptions);
        }

        // Update is called once per frame
        private void Update()
        {

        }

        public void InitGameLevel()
        {
            SceneManager.LoadScene("levels");
        }

        public void InitOptions()
        {

        }

        public void QuitGame()
        {
            QuitGameConifmed();
        }

        public void QuitGameConifmed()
        {
            Application.Quit();
        }
    }
}