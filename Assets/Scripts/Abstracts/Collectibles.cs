using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectibles : MonoBehaviour
{
    public PlayerScript refJogador;
    public CanvasScript refCanvas;
    public AudioSource collectiblesSounds;

    public virtual void Start()
    {
        refJogador = GameObject.Find("Player").GetComponent<PlayerScript>();
        collectiblesSounds = this.gameObject.GetComponent<AudioSource>();
    }

    public void AddScore(int scoreToAdd)
    {
        refJogador.Money += scoreToAdd;
        Destroy(this.gameObject);
    }
}
