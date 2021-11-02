using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectibles : MonoBehaviour
{
    public PlayerScript refJogador;

    public void Start()
    {
        refJogador = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    public void AddScore(int scoreToAdd)
    {
        refJogador.Money += scoreToAdd;
        Destroy(this.gameObject);
    }
}
