using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using PlayerProps;


namespace Pickup
{
    public class BasePickup : MonoBehaviour
    {
        public float addTime;
        public int addLifes;
        public int pickupType;
        public string pickupName;

        protected AudioSource audioSource;
        protected AudioClip pickSound;

        private ClassManager classManager;
        private PlayerManager playerManager;
        private Enums enums;

        public virtual void InitPickup(ClassManager classManager)
        {
            this.classManager = classManager;
            this.playerManager = classManager.PlayerManager;
            this.enums = classManager.Enums;
        }

        protected virtual void Update()
        {
            switch (pickupType)
            {
                case 0:


                    Debug.Log("more time added!!");

                    break;

                case 1:


                    Debug.Log("more life added!!");

                    break;

                default:
                    break;
            }
        }
    }
}