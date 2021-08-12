using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGameScene : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;

    private void Awake()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
        Handheld.StartActivityIndicator();
        yield return new WaitForSeconds(4);
        SceneManager.UnloadSceneAsync(1);
    }
}
