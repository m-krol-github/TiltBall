 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Managers;

namespace Utils
{
    public class Fader : MonoBehaviour
    {
        public float timmer;
        public bool fadeOut;


        [Range(0,1)]
        public float colorTo;

        [SerializeField]
        private Image fadeImage;

        [SerializeField]
        private Color color;

        private ClassManager classManager;

        private void Awake()
        {
            fadeImage.gameObject.SetActive(true);

            if (fadeOut)
                colorTo = 1;

            StartFade(colorTo);
        }

        public void InitFader(ClassManager classManager)
        {
            this.classManager = classManager;
        }

        public void StartFade(float color)
        {
            //
            fadeImage.color = new Color(0, 0, 0, color);
            //
            if (color == 1)
            {
                StartCoroutine(FadeAlphaToZero(timmer));
            }else if(color == 0)
            {
                StartCoroutine(FadeAlphaToOne(timmer));
            }
        }

        IEnumerator FadeAlphaToZero(float duration)
        {
            var startColor = fadeImage.color = new Color(0, 0, 0, 1);
            var endColor = fadeImage.color = new Color(0, 0, 0, 0);
            float time = 0;
            while (time < duration)
            {
                time += Time.deltaTime;
                fadeImage.color = Color.Lerp(startColor, endColor, time / duration);
                yield return null;
            }
            fadeImage.gameObject.SetActive(false);
            Values.GameValues.showStartText =true;
        }

        IEnumerator FadeAlphaToOne(float duration)
        {
            var startColor = fadeImage.color = new Color(0, 0, 0, 0);
            var endColor = fadeImage.color = new Color(0, 0, 0, 1);
            float time = 0;
            while (time < duration)
            {
                time += Time.deltaTime;
                fadeImage.color = Color.Lerp(startColor, endColor, time / duration);
                
                yield return null;
            }
            fadeImage.gameObject.SetActive(false);
        }
    }
}