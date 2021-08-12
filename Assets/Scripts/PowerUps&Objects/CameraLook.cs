using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerProps;

namespace Utils
{
    public class CameraLook : MonoBehaviour
    {
        [SerializeField]
        private Transform playerTarget;

        [SerializeField]
        private Camera cam;

        // Update is called once per frame
        void LateUpdate()
        {
            cam.transform.LookAt(playerTarget);
        }
    }
}