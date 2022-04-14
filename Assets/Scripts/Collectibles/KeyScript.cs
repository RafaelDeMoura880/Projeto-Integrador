using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : Collectibles
{
    [SerializeField] int keyValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && PlayerScript.instance.Money == keyValue)
        {
            PlayerScript.instance.hasKey = true;
            PlayerScript.instance.Money -= keyValue;
            CanvasScript.instanceCanvas.transform.GetChild(3).gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
