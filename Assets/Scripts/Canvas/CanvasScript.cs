using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    GameObject[] hearts;    
    public Text coinCountText;
    public static CanvasScript instanceCanvas;

    private void Start()
    {
        hearts = new GameObject[this.transform.GetChild(2).transform.childCount];

        for (int i = 0; i < hearts.Length; i++)
            hearts[i] = this.transform.GetChild(2).transform.GetChild(i).gameObject;

        for (int i = 0; i < PlayerScript.Hearts; i++)
            hearts[i].SetActive(true);
        
        coinCountText = this.transform.GetChild(1).GetComponent<Text>();
        coinCountText.text = "0";

        instanceCanvas = this;
    }

    private void Update()
    {
        coinCountText.text = PlayerScript.instance.Money.ToString();
    }
}
