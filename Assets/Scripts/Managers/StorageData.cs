using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using PlayerProps;

namespace Storage
{
    public class StorageData : MonoBehaviour
    {
        public bool overrideNumber;
        public int playerLifes = 10;

        private ClassManager classManager;
        private GameManager gameManager;
        private LevelsManager levels;
        private PlayerManager player;

        public void InitStorage(ClassManager classManager)
        {
            this.classManager = classManager;
            this.gameManager = classManager.GameManager;
            this.levels = classManager.Levels;
            this.player = classManager.PlayerManager;

            if (overrideNumber)
                OverrideNumber();
        }

        public void OverrideNumber()
        {
            PlayerPrefs.SetInt("LastLevel", 0);
            //overrideNumber = false;
        }

        public void SetFirstRun()
        {
            PlayerPrefs.SetInt("FirstRun", 1);
            PlayerPrefs.SetInt("LastLevel", 0);
        }

        public void LevelNumber(int level)
        {
            PlayerPrefs.SetInt("LastLevel", level);
        }

    }
}