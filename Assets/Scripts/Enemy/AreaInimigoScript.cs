using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaInimigoScript : MonoBehaviour
{
    _Blue inimigo;

    private void Start()
    {
        inimigo = this.transform.parent.GetChild(0).GetComponent<_Blue>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inimigo.enemyBlueAnim.SetBool("isOnTrigger", true);
            inimigo.ativo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inimigo.enemyBlueAnim.SetBool("isOnTrigger", false);
            inimigo.ativo = false;
        }
    }
}
