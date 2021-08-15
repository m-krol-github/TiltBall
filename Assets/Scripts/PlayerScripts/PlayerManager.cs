using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using Utils;
using Events;

namespace PlayerProps
{
    public class PlayerManager : MonoBehaviour
    {

        [Header("PlayerBall")]
        public PlayerMove playerMove;
        public Transform playerSpawnPosition;

        [SerializeField]
        private PlayerMove playerBall;        
        
        [Header("Lives")]
        public int lifes;
        public int health;

        #region SOUNDS_EFFECTS
        [Header("Sounds")]
        [SerializeField]
        private AudioSource audioS;

        [SerializeField]
        private AudioSource rollSound;

        [SerializeField]
        private List<AudioClip> wallTouch = new List<AudioClip>();

        [SerializeField]
        private List<AudioClip> obstacleCips = new List<AudioClip>();

        [SerializeField]
        private List<AudioClip> pickupClips = new List<AudioClip>();

        [SerializeField]
        private List<AudioClip> timeAdd = new List<AudioClip>();

        [SerializeField]
        private List<AudioClip> levelEndClips = new List<AudioClip>();

        [SerializeField]
        private List<AudioClip> playerHurtSound = new List<AudioClip>();

        [Header("PickEffect"), SerializeField]
        private ParticleSystem pickEffect;

        [SerializeField]
        private ParticleSystem endLevelEffect;

        [SerializeField]
        private ParticleSystem timesUpEffect;

        [SerializeField]
        private ParticleSystem playerExplodeEffect;
        #endregion

        [SerializeField]
        private Transform holder;


        private ClassManager classManager;
        private CameraLook cameraLook;
        private GameManager gameManager;
        private Enums enums;
        private GameEvents gameEvents;

        public void InitStart(ClassManager classManager)
        {
            this.classManager = classManager;
            this.gameManager = classManager.GameManager;
            this.enums = classManager.Enums;
            this.cameraLook = classManager.CameraLook;
            this.gameEvents = classManager.Events;

            StartCoroutine(SetCameraTarget());
            SpawnPlayer();

        }

        public void SpawnPlayer()
        {
            var player = Instantiate(playerBall, playerSpawnPosition.position,Quaternion.identity);
            playerMove = player;
            Values.GameValues.playerSpawned = true;
            playerMove.InitMove(classManager, WallTouchSnd, PickupSnd, ObstacleSnd, LvlEndSound, TimesUpSnd, TimeAddSnd);
        }

        // Update is called once per frame
        public void UpdatePlayerProps()
        {
            playerMove.UpdateMove();
        }

        public void WallTouchSnd()
        {
            var sound = Random.Range(0, wallTouch.Count);
            if(!audioS.isPlaying)
                audioS.PlayOneShot(wallTouch[sound]);
        }

        public void ObstacleSnd()
        {
            var sound = Random.Range(0, obstacleCips.Count);
            if (!audioS.isPlaying)
                audioS.PlayOneShot(obstacleCips[sound]);
            SpikeTouchByBall();
        }
        public void PickupSnd()
        {
            var sound = Random.Range(0, pickupClips.Count);
            if (!audioS.isPlaying)
                audioS.PlayOneShot(pickupClips[sound]);

        }

        public void LvlEndSound()
        {
            var sound = Random.Range(0, pickupClips.Count);
            if (!audioS.isPlaying)
                audioS.PlayOneShot(pickupClips[sound]);

            gameEvents.OnLevelFinish.Invoke();
        }

        public void TimesUpSnd()
        {

        }

        public void TimeAddSnd()
        {
            var sound = Random.Range(0, timeAdd.Count);
            if (!audioS.isPlaying)
                audioS.PlayOneShot(timeAdd[sound]);

            //time
            gameManager.levelTime += 10f;
            
            var effect = Instantiate(pickEffect);
            effect.gameObject.transform.localPosition = playerMove.gameObject.transform.position;
            effect.transform.parent = holder.parent;
            effect.gameObject.AddComponent<DestroyOver>().InvokeDestroy(2);
            effect.Play();
        }

        public void SpikeTouchByBall()
        {
            playerMove.GetComponent<MoveByAnimation>().StartAnimation();
            playerMove.SetRbKinematic();
            StartCoroutine(DestroyBall());
        }

        private IEnumerator DestroyBall()
        {
            yield return new WaitForSeconds(1f);
            //
            playerMove.GetComponent<ScaleByAnimation>().StartAnimation();
            //
            yield return new WaitForSeconds(1f);
            //
            Instantiate(playerExplodeEffect, playerMove.transform.position, Quaternion.identity);
            //
            var sound = Random.Range(0, playerHurtSound.Count);
            audioS.PlayOneShot(playerHurtSound[sound]);
            //
            yield return new WaitForSeconds(.6f);
            //
            playerMove.gameObject.GetComponent<MeshRenderer>().enabled  =false;
            gameManager.RestartLevel();
        }


        private IEnumerator SetCameraTarget()
        {
            yield return new WaitUntil(() => Values.GameValues.playerSpawned);
            cameraLook.playerTarget = playerMove.transform;
        }
    }
}