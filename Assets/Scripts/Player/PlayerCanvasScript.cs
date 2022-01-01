using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasScript : MonoBehaviour
{
    Slider barraVida;
    GameObject refJogador;
    int vidaJogador;

    private void Start()
    {
        barraVida = this.transform.GetChild(0).GetComponent<Slider>();
        vidaJogador = PlayerScript.instance.Life;
        barraVida.maxValue = vidaJogador;
        barraVida.value = barraVida.maxValue;

        refJogador = GameObject.Find("Player").gameObject;
    }

    private void Update()
    {
        vidaJogador = PlayerScript.instance.Life;
        barraVida.value = vidaJogador;
    }
}
