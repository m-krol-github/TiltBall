using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOver : MonoBehaviour
{
    public float timeTo = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyOverTime(timeTo));
    }

    public void InvokeDestroy(float t)
    {
        StartCoroutine(DestroyOverTime(t));
    }

    private IEnumerator DestroyOverTime(float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(this.gameObject);
    }
}
