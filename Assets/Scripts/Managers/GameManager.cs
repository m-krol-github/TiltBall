using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerProps;
using Pickup;
using GameView;
using UnityEngine.SceneManagement;
using Storage;
using Utils;
using Events;
using Audio;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Level Props")]
        public float levelTime;
        public int levelNumber;
        public int playerLifes;

        public bool isPaused;
        public bool isStarted;

        [SerializeField]
        private ClassManager classManager;
        public ClassManager ClassManager => classManager;

        private Enums enums;
        private PlayerManager playerManager;
        private InGameView gameView;
        private LevelsManager levels;
        private StorageData storage;
        private GameEvents gameEvents;
        private Fader fader;
        private DeathZone zone;
        private AudioManager audioMan;

        private void Awake()
        {
            Handheld.Vibrate();
            Values.GameValues.levelSpawned = false;
        }

        private void Start()
        {
            playerLifes = PlayerPrefs.GetInt("Lifes");
            this.enums = classManager.Enums;
            this.playerManager = classManager.PlayerManager;
            this.gameView = classManager.GameView;
            this.levels = classManager.Levels;
            this.storage = classManager.Storage;
            this.gameEvents = classManager.Events;
            this.fader = classManager.Fader;
            this.zone = classManager.Zone;
            this.audioMan = classManager.AudioManager;
            fader.StartFade(1);

            //ui
            gameView.PausePanel.HideView();
            gameView.Top.InitTopView(classManager, PauseUnpause);
            gameView.Top.ShowView();
            //

            playerManager.InitStart(classManager);
            levels.InitLevels(classManager);
            storage.InitStorage(classManager);
            fader.InitFader(classManager);
            zone.InitZone(classManager);
            audioMan.StartSounds();

            //
            AssignEvents();
        }

        private void AssignEvents()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            gameView.Top.UpdateView();

            if (playerLifes <= 0)
            {
                PlayerPrefs.SetInt("LastLevel", 0);

                StartCoroutine(GameOver());
            }

            //level time:
            if (Values.GameValues.levelStart)
                levelTime -= Time.deltaTime;

           
            //enums track
            if (enums.debugMode == Enums.DEBUG_MODE.YES)
            {
                Debug.Log("Debug " + " Mode");
                Values.GameValues.isDebug = true;
                if (Input.GetButtonDown("Cancel"))
                {
                    RestartLevel();
                }
            }
            else
            {
                if (Input.GetButtonDown("Cancel"))
                {
                    PauseUnpause();
                }
            }

            if (enums.screenSaving == Enums.SCREEN_OFF.NO)
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }
            else
            {
                Screen.sleepTimeout = SleepTimeout.SystemSetting;
            }


            //levels update
            if (Values.GameValues.levelSpawned)
                levels.UpdateLevels();

            
            if (!Values.GameValues.levelSpawned)
            {
                levels.StartGame();
            }
            
            if(levelTime <= 0)
            {
                RestartLevel();
            }
        }

        public void PauseUnpause()
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                audioMan.StopAllSounds();
                Time.timeScale = 0;
                gameView.PausePanel.ShowView();
            }
            else if (!isPaused)
            {
                Time.timeScale = 1;
                gameView.PausePanel.HideView();
            }
        }

        public void RestartLevel()
        {
            fader.StartFade(0);
            //
            playerLifes = PlayerPrefs.GetInt("Lifes");
            playerLifes--;
            PlayerPrefs.SetInt("Lifes", playerLifes);
            //
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private IEnumerator GameOver()
        {
            fader.StartFade(0);
            //TODO stufff over game
            yield return new WaitForSeconds(2);
            PlayerPrefs.SetInt("Lifes", storage.playerLifes);
            SceneManager.LoadScene("MainMenu");
        }

        public void QuitGame()
        {
            SceneManager.LoadScene("MainMenu");
        }



        public void UnAssignEvents()
        {

        }

        public void LevelEnd()
        {
            Debug.Log("Level " + " End");
        }


        private void OnDestroy()
        {
            UnAssignEvents();
        }
    }
}