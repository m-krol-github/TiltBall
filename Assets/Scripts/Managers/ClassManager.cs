using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using PlayerProps;
using Pickup;
using GameView;
using Storage;
using Utils;
using Events;
using Audio;

namespace Managers
{
    public class ClassManager : MonoBehaviour
    {
        [SerializeField]
        private Values values;
        public Values Values => values;

        [SerializeField]
        private GameEvents events;
        public GameEvents Events => events;

        [SerializeField]
        private GameManager gameManager;
        public GameManager GameManager => gameManager;

        [SerializeField]
        private Enums enums;
        public Enums Enums => enums;

        [SerializeField]
        private PlayerManager playerManager;
        public PlayerManager PlayerManager => playerManager;

        [SerializeField]
        private CameraLook cameraLook;
        public CameraLook CameraLook => cameraLook;

        [SerializeField]
        private InGameView gameView;
        public InGameView GameView => gameView;

        [SerializeField]
        private LevelsManager levels;
        public LevelsManager Levels => levels;

        [SerializeField]
        private StorageData storage;
        public StorageData Storage => storage;

        [SerializeField]
        private Fader fader;
        public Fader Fader => fader;

        [SerializeField]
        private DeathZone zone;
        public DeathZone Zone => zone;

        [SerializeField]
        private AudioManager audioManager;
        public AudioManager AudioManager => audioManager;
    }
}