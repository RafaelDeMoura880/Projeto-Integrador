using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasScript : MonoBehaviour
{
    Slider barraVida;
    PlayerScript refJogador;

    private void Start()
    {
        refJogador = GameObject.Find("Player").GetComponent<PlayerScript>();

        barraVida = this.transform.GetChild(0).GetComponent<Slider>();
        barraVida.maxValue = refJogador.Life;
        barraVida.value = barraVida.maxValue;
    }

    private void FixedUpdate()
    {
        this.transform.position = refJogador.playerLocation;
    }

    private void Update()
    {
        barraVida.value = refJogador.Life;
    }
}
