using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseView : MonoBehaviour
{
    public virtual void ShowView()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideView()
    {
        this.gameObject.SetActive(false);
    }
}
