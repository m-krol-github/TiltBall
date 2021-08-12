using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace PlayerProps
{
    public class PlayerManager : MonoBehaviour
    {

        [Header("Lives")]
        public int lifes;
        public int health;

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
        private AudioClip rollClip;

        [Header("PickEffect"), SerializeField]
        private ParticleSystem pickEffect;

        [SerializeField]
        private ParticleSystem endLevelEffect;

        [SerializeField]
        private ParticleSystem timesUpEffect;

        [SerializeField]
        private Transform holder;

        private ClassManager classManager;
        private GameManager gameManager;
        private Enums enums;
        private PlayerMove playerMove;

        public void InitStart(ClassManager classManager)
        {
            this.classManager = classManager;
            this.gameManager = classManager.GameManager;
            this.enums = classManager.Enums;
            this.playerMove = classManager.PlayerMove;

            playerMove.InitMove(classManager, WallTouchSnd, PickupSnd, ObstacleSnd, LvlEndSound, TimesUpSnd, TimeAddSnd, RollClipPlay);
        }

        // Update is called once per frame
        public void UpdatePlayerProps()
        {
            //player moveUp
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
        }
        public void PickupSnd()
        {
            var sound = Random.Range(0, pickupClips.Count);
            if (!audioS.isPlaying)
                audioS.PlayOneShot(pickupClips[sound]);

        }

        public void LvlEndSound()
        {

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

        public void RollClipPlay()
        {
            if (!rollSound.isPlaying)
                audioS.PlayOneShot(rollClip);
        }
    }
}