using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class BaseObstacle : MonoBehaviour
    {
        public int obstacleType;

        [Header("KickOut")]
        public float magnitude;
        public Vector2 kickDir;

        [Header("Damadge")]
        public float damadgePower;
        public bool isDamagable;
    }
}