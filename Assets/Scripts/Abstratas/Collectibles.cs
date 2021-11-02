using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectibles : MonoBehaviour
{
    public int scoreToAdd;

    public virtual void Start()
    {
        scoreToAdd = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerScript>().Money += scoreToAdd;
            Destroy(this.gameObject);
        }
    }

    public void AddScore()
    {

    }
}
