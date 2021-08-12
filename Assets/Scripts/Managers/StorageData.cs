using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using PlayerProps;

namespace Storage
{
    public class StorageData : MonoBehaviour
    {
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
        }
    }
}