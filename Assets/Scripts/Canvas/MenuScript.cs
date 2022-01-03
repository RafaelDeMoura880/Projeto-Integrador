using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static Text gameOverText;
    public static bool hasStarted = false;
    public PlayerScript refJogador;

    private void Start()
    {
        gameOverText = this.transform.GetChild(0).GetComponent<Text>();
    }

    private void Update()
    {
        //if (PlayerScript.hasWon == false && hasStarted == true)
        //    gameOverText.text = "Derrota";
        //if (PlayerScript.hasWon == false && hasStarted == false)
        //    gameOverText.text = "Projeto Integrador";
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        hasStarted = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
