using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    GameObject[] hearts;

    Text bossLine;
    GameObject panelSubtitle;
    public Text coinCountText;
    public static CanvasScript instanceCanvas;

    public int bossAnnouncement = 0;

    private void Start()
    {
        hearts = new GameObject[this.transform.GetChild(2).transform.childCount];

        for (int i = 0; i < hearts.Length; i++)
            hearts[i] = this.transform.GetChild(2).transform.GetChild(i).gameObject;

        for (int i = 0; i < PlayerScript.Hearts; i++)
            hearts[i].SetActive(true);
        
        coinCountText = this.transform.GetChild(1).GetComponent<Text>();
        coinCountText.text = "0";

        panelSubtitle = this.gameObject.transform.GetChild(5).gameObject;
        bossLine = this.gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).
            gameObject.GetComponent<Text>();

        instanceCanvas = this;
    }

    private void Update()
    {
        coinCountText.text = PlayerScript.instance.Money.ToString();

        if(bossAnnouncement == 1)
        {
            bossLine.text = "Este é o meu castelo. NÃO ENTRE!";
            StartCoroutine(SubtittleONOFF());
        }
        if(bossAnnouncement == 3)
        {
            bossLine.text = "Prepare-se para morrer!";
            StartCoroutine(SubtittleONOFF());
        }
        if(bossAnnouncement == 5)
        {
            bossLine.text = "HAHAHAHAHAHAHAHAHA!!!";
            StartCoroutine(SubtittleONOFF());
        }
    }

    IEnumerator SubtittleONOFF()
    {
        panelSubtitle.SetActive(true);
        yield return new WaitForSeconds(4f);
        panelSubtitle.SetActive(false);
        bossAnnouncement += 1;
        StopAllCoroutines();
    }
}
