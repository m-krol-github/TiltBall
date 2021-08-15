using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameView
{
    public class InGameView : MonoBehaviour
    {
        public bool passStart;

        [SerializeField]
        private BottomView bottom;
        public BottomView Bottom => bottom;

        [SerializeField]
        private TopView top;
        public TopView Top => top;

        [SerializeField]
        private MainMenu mainMenu;
        public MainMenu MainMenu => mainMenu;

        [SerializeField]
        private PausePanel pausePanel;
        public PausePanel PausePanel => pausePanel;

        public void ShowView()
        {
            top.ShowView();
            bottom.ShowView();
            mainMenu.ShowView();
            pausePanel.ShowView();
        }

        public void HideView()
        {
            top.HideView();
            bottom.HideView();
            mainMenu.HideView();
            pausePanel.HideView();
        }
    }
}