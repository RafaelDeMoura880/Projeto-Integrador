using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerScript.instance.hasKey)
        {
            PlayerScript.instance.hasKey = false;
            CanvasScript.instanceCanvas.gameObject.transform.GetChild(3).gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
