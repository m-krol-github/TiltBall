using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameView
{
    public class InGameView : MonoBehaviour
    {
        [SerializeField]
        private BottomView bottom;
        public BottomView Bottom => bottom;

        [SerializeField]
        private TopView top;
        public TopView Top => top;

        [SerializeField]
        private MainMenu mainMenu;
        public MainMenu MainMenu => mainMenu;

        public void ShowView()
        {
            top.ShowView();
            bottom.ShowView();
            mainMenu.ShowView();
        }

        public void HideView()
        {
            top.HideView();
            bottom.HideView();
            mainMenu.HideView();
        }
    }
}