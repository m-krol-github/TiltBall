using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerProps;
using Pickup;
using GameView;
using Storage;
using Utils;

namespace Managers
{
    public class ClassManager : MonoBehaviour
    {
        [SerializeField]
        private Values values;
        public Values Values => values;

        [SerializeField]
        private GameManager gameManager;
        public GameManager GameManager => gameManager;

        [SerializeField]
        private Enums enums;
        public Enums Enums => enums;

        [SerializeField]
        private PlayerMove playerMove;
        public PlayerMove PlayerMove => playerMove;

        [SerializeField]
        private PlayerManager playerManager;
        public PlayerManager PlayerManager => playerManager;

        

        [SerializeField]
        private InGameView gameView;
        public InGameView GameView => gameView;

        [SerializeField]
        private LevelsManager levels;
        public LevelsManager Levels => levels;

        [SerializeField]
        private StorageData storage;
        public StorageData Storage => storage;
    }
}