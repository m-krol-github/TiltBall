using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class Enums : MonoBehaviour
    {
        public enum PLAYER_INPUT
        {
            TILT,
            KEYB,
            JOYSTICK,
            BOTH
        };

        public PLAYER_INPUT playerInput;

        public enum DEBUG_MODE
        {
            YES,
            NO
        };

        public DEBUG_MODE debugMode;

        public enum SCREEN_OFF
        {
            NO,
            STANDARD
        };

        public SCREEN_OFF screenSaving;
    }
}