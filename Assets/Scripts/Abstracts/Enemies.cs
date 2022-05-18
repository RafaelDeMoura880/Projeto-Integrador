using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Enemies : MonoBehaviour
{
    public float enemyMovement;
    public float enemySpeed;

    public virtual void Start()
    {
        enemyMovement = 0f;
        enemySpeed = 0f;
    }

    public void Dano(int _damage)
    {
        PlayerScript.instance.Life -= _damage;
        PlayerScript.instance.playerAnim.SetTrigger("isHit");
        if (PlayerScript.instance.Life <= 0)
        {
            if(PlayerScript.Hearts > 0)
            {
                PlayerScript.Hearts -= 1;

                //if (PlayerScript.instance.isOnCheckpoint == true)
                //    PlayerScript.instance.playerLocation = PlayerScript.playerCheckpointLocation;
                //else
                    SceneManager.LoadScene(1);
            }
            else
            {
                MenuScript.terminouText = "Derrota";
                PlayerScript.instance.playerLocation = PlayerScript.instance.playerStartLocation;
                PlayerScript.instance.isOnCheckpoint = false;
                SceneManager.LoadScene(0);
            }
        }
    }
}
