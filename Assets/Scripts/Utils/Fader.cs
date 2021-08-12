 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class Fader : MonoBehaviour
    {
        public float timmer;

        [SerializeField]
        private Image fadeImage;

        [SerializeField]
        private Color color;

        private void Awake()
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.color = new Color(0, 0, 0, 1);
            StartCoroutine(FadeAlphaToZero(timmer));
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
        }
    }
}