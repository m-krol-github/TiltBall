using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GameEvents : MonoBehaviour
    {
        public UnityAction OnLevelFinish;
        public void LevelFinishCallback()
        {
            OnLevelFinish.Invoke();
        }

        public UnityAction OnTimeUp;
        public void TimeUpCallback()
        {
            OnTimeUp.Invoke();
        }

        public UnityAction OnSpikesTouch;
        public void SpikeTOuchCallback()
        {
            OnSpikesTouch.Invoke();
        }
    }
}