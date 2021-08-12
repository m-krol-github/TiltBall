using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerProps;
using Pickup;
using GameView;
using UnityEngine.SceneManagement;
using Storage;
using MoreMountains.NiceVibrations;
using Utils;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Level Props")]
        public float levelTime;
        public int levelNumber;

        public bool isPaused;

        [SerializeField]
        private ClassManager classManager;
        public ClassManager ClassManager => classManager;

        private Enums enums;
        private PlayerMove playerMove;
        private PlayerManager playerManager;
        private InGameView gameView;
        private LevelsManager levels;
        private StorageData storage;
        

        private void Awake()
        {
            //SceneManager.LoadScene(1, LoadSceneMode.Additive);
            Handheld.Vibrate();
        }

        private void Start()
        {
            this.enums = classManager.Enums;
            this.playerMove = classManager.PlayerMove;
            this.playerManager = classManager.PlayerManager;
            this.gameView = classManager.GameView;
            this.levels = classManager.Levels;
            this.storage = classManager.Storage;
            //ui
            gameView.Top.InitTopView(classManager, PauseUnpause);
            gameView.Top.ShowView();
            //
            playerManager.InitStart(classManager);
            levels.InitLevels(classManager);
            storage.InitStorage(classManager);
            //

        }

        // Update is called once per frame
        private void Update()
        {
            //level time:
            if (Values.GameValues.levelSpawned)
                levelTime -= Time.deltaTime;

            //uppdata ui
            gameView.Top.UpdateView();

            //player props classupdate
            playerManager.UpdatePlayerProps();

            //enums track
            if (enums.debugMode == Enums.DEBUG_MODE.YES)
            {
                Debug.Log("Debug " + " Mode");

                if (Input.GetButtonDown("Cancel"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

        }

        public void PauseUnpause()
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0;
            }
            else if (!isPaused)
            {
                Time.timeScale = 1;
            }
        }
    }
}