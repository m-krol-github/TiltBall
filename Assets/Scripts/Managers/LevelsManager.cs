using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Events;
using PlayerProps;

namespace Managers
{
    public class LevelsManager : MonoBehaviour
    {
        public List<Level> spawnedLevels = new List<Level>();

        public bool isSpawned;
        public LevelData[] levelsList;
        public Transform levelSpawnHolder;

        public int debugLevelNumber;
        public int currentLevelIndex;

        private ClassManager classManager;
        private GameManager gameManager;
        private GameEvents gameEvents;
        private PlayerManager player;

        public void InitLevels(ClassManager classManager)
        {
            this.classManager = classManager;
            this.gameManager = classManager.GameManager;
            this.gameEvents = classManager.Events;
            this.player = classManager.PlayerManager;

            player.playerMove.SetRbKinematic();

            AssignEvents();
        }
        public void AssignEvents()
        {
            gameEvents.OnLevelFinish += LevelEnd;
        }

        public void StartGame()
        {
            if (classManager.Enums.debugMode == Enums.DEBUG_MODE.NO)
            {
                player.playerMove.SetRbKinematic();
                var cLevel = PlayerPrefs.GetInt("LastLevel");
                SpawnLevel(cLevel);
            }
            else
            {
                player.playerMove.SetRbKinematic();
                PlayerPrefs.SetInt("LastLevel", debugLevelNumber);
                var cLevel = PlayerPrefs.GetInt("LastLevel");
                SpawnLevel(cLevel);
            }
        }

        public void SpawnLevel(int level)
        {
            Values.GameValues.showStartText = false;
            gameManager.levelNumber = levelsList[level].levelNumber;
            gameManager.levelTime = levelsList[level].levelTime;

            currentLevelIndex = levelsList[level].levelNumber - 1;

            levelsList[level].isSpawned = true;
            var lvlv = Instantiate(levelsList[level].levelPrefab);
            lvlv.gameObject.transform.parent = levelSpawnHolder.transform;
            RegisterLevel(lvlv);
            Values.GameValues.levelSpawned = true;
            Values.GameValues.levelStart = true;
        }

        public void UpdateLevels()
        {

        }

        public void RegisterLevel(Level level)
        {
            spawnedLevels.Add(level);
        }

        public void UnRegisterLevel(Level level)
        {
            spawnedLevels.Remove(level);
        }

        public void LevelFinished(Level level)
        {
            Values.GameValues.levelStart = false;
            Values.GameValues.levelSpawned = false;
            UnRegisterLevel(level);

        }

        public void UnAssignEvents()
        {
            gameEvents.OnLevelFinish -= LevelEnd;
        }

        public void LevelEnd()
        {
            //
            classManager.GameView.Top.ShowFinish();
            //
            //var curent = spawnedLevels[0].GetComponent<Level>();
            LevelFinished(spawnedLevels[0].GetComponent<Level>());
            StartCoroutine(EndLevelRoutine());
        }


        private IEnumerator EndLevelRoutine()
        {

            var animate = player.playerMove.GetComponent<Animator>();
            animate.enabled = true;
            animate.SetBool("MoveY", false);
            animate.SetBool("MoveX", false);


            //move up
            var anim = player.playerMove.gameObject.GetComponent<MoveByAnimation>();
            anim.targetOffset = new Vector3(0, 5, 0);
            anim.StartAnimation();
            
            //animate up
            animate.SetBool("MoveY", true);
            
            //disable gravity            
            player.playerMove.SetRbKinematic();
            yield return new WaitForSeconds(1);

            //move left
            anim.targetOffset = new Vector3(10, 0, 0);
            animate.SetBool("MoveX", true);
            anim.StartAnimation();
            yield return new WaitForSeconds(1);

            //reset value
            Values.GameValues.playerSpawned = false;
            yield return new WaitUntil(() => !Values.GameValues.playerSpawned);

            //move to start 
            player.playerMove.gameObject.transform.localPosition = player.playerSpawnPosition.position;

            //destroy old level
            Destroy(levelSpawnHolder.GetComponentInChildren<Level>().gameObject);            
        }

        private void OnDestroy()
        {
            UnAssignEvents();
        }
    }
}