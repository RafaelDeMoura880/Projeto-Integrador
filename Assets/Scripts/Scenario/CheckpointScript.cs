using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //PlayerScript.instance.isOnCheckpoint = true;
            PlayerScript.playerCheckpointLocation = this.transform.position;
            PlayerScript.instance.transform.position = PlayerScript.playerCheckpointLocation;
        }
    }
}
