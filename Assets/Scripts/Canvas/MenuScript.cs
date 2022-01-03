using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Text gameOverText;
    public static string terminouText = "Projeto Integrador";

    private void Start()
    {
        gameOverText = this.transform.GetChild(0).GetComponent<Text>();
        gameOverText.text = terminouText;
    }

    private void Update()
    {
        gameOverText.text = terminouText;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
