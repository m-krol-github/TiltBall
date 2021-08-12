using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Managers
{
    public class LevelsManager : MonoBehaviour
    {
        public List<Level> spawnedLevels = new List<Level>();

        public bool isSpawned;
        public LevelData[] levelsList;


        private ClassManager classManager;
        private GameManager gameManager;

        public void InitLevels(ClassManager classManager)
        {
            this.classManager = classManager;
            this.gameManager = classManager.GameManager;


            PlayerPrefs.SetInt("LastLevel", 0);

            var cLevel = PlayerPrefs.GetInt("LastLevel");
            SpawnLevel(cLevel);
        }

        public void SpawnLevel(int level)
        {
            gameManager.levelNumber = levelsList[level].levelNumber;
            gameManager.levelTime = levelsList[level].levelTime;
            levelsList[level].isSpawned = true;
            var lvlv = Instantiate(levelsList[level].levelPrefab);
            RegisterLevel(lvlv);
            Values.GameValues.levelSpawned = true;
        }

        public void RegisterLevel(Level level)
        {
            spawnedLevels.Add(level);
        }

        public void UnRegisterLevel(Level level)
        {
            spawnedLevels.Remove(level);
        }

        public void LevleFinished(Level level)
        {
            Values.GameValues.levelSpawned = false;
            UnRegisterLevel(level);
        }

        public void UpdateLevels()
        {
            
        }
    }
}