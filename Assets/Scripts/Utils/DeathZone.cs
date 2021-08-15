using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Utils
{
    public class DeathZone : MonoBehaviour
    {
        private ClassManager classManager;

        public void InitZone(ClassManager classManager)
        {
            this.classManager = classManager;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                classManager.Fader.StartFade(0);
                classManager.GameManager.RestartLevel();
            }
        }
    }
}