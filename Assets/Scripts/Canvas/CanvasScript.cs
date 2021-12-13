using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Text coinCountText;

    private void Start()
    {
        coinCountText = this.transform.GetChild(1).GetComponent<Text>();
        coinCountText.text = "0";
    }

    private void Update()
    {
        coinCountText.text = PlayerScript.instance.Money.ToString();
    }
}
