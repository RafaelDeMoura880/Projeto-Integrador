using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : Collectibles
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && PlayerScript.instance.Money == 1)
        {
            PlayerScript.instance.hasKey = true;
            CanvasScript.instanceCanvas.transform.GetChild(3).gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
