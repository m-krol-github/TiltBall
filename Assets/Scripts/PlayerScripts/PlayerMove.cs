using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using UnityEngine.Events;
using Obstacles;
using Pickup;
using MoreMountains.NiceVibrations;

namespace PlayerProps
{
    [RequireComponent(typeof(Rigidbody))]    
    public class PlayerMove : MonoBehaviour
    {
        public float speed;
        public int startingPitch = 1;
        public int volumeSpeeed = 1;

        [SerializeField]
        private AudioSource audioS;

        [SerializeField]
        private AudioClip rollClip;

        [SerializeField]
        private Rigidbody rb;

        private ClassManager classManager;
        private Enums enums;
        private PlayerManager playerManager;

        private UnityAction OnWallTouch;
        private UnityAction OnPickupCollect;
        private UnityAction OnObstacleTouch;
        private UnityAction OnLvlEnd;
        private UnityAction OnTimeUp;
        private UnityAction OnTimeAdd;
        private UnityAction OnRoll;

        public void InitMove(ClassManager classManager, UnityAction WallTchCallback, UnityAction PickupCollectCallback, UnityAction ObstacleTouch, UnityAction LevelEndCallback, 
            UnityAction TimeUpCallback, UnityAction TimeAddCallback, UnityAction RollCallback)
        {
            this.classManager = classManager;
            this.enums = classManager.Enums;
            this.playerManager = classManager.PlayerManager;

            this.OnWallTouch = WallTchCallback;
            this.OnPickupCollect = PickupCollectCallback;
            this.OnObstacleTouch = ObstacleTouch;
            this.OnLvlEnd = LevelEndCallback;
            this.OnTimeUp = TimeUpCallback;
            this.OnTimeAdd = TimeAddCallback;
            this.OnRoll = RollCallback;

            this.audioS.time = volumeSpeeed;
            this.audioS.pitch = startingPitch;
        }

        public void UpdateMove()
        {
            if (enums.playerInput == Enums.PLAYER_INPUT.TILT)
            {
                Vector3 tilt = Input.acceleration;
                tilt = Quaternion.Euler(90, 0, 0) * tilt;

                rb.AddForce(tilt * speed);
            }else if(enums.playerInput == Enums.PLAYER_INPUT.KEYB)
            {
                var h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                var v = Input.GetAxis("Vertical") * speed * Time.deltaTime;                                

                rb.AddForce(new Vector3(h,0,v) * speed,ForceMode.Force);
            }
            else if (enums.playerInput == Enums.PLAYER_INPUT.BOTH)
            {
                Vector3 tilt = Input.acceleration;
                tilt = Quaternion.Euler(90, 0, 0) * tilt;

                var h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                var v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

                rb.AddForce(new Vector3(h, 0, v), ForceMode.Force);
                rb.AddForce(tilt * speed);
            }

            var ballSpeed = rb.velocity.magnitude;
            audioS.volume = ballSpeed / volumeSpeeed;
            //var maxPitch = Mathf.Clamp(startingPitch, 0, 1.5f);
            //audioS.pitch = ballSpeed / maxPitch;

            if (!audioS.isPlaying)
                audioS.PlayOneShot(rollClip);
        }

        private void OnCollisionEnter(Collision other)
        {
            MMVibrationManager.Haptic(HapticTypes.Failure);
            if (other.gameObject.GetComponent<SimpleWall>())
            {
                OnWallTouch?.Invoke();
            }

            if (other.gameObject.GetComponent<SimpleWatch>())
            {                
                OnTimeAdd?.Invoke();
                Destroy(other.gameObject);
            }
        }
    }
}