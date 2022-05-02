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

    public void ShowTutorialPanel()
    {
        this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void BackButton()
    {
        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
