using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerScript.instance.hasKey)
        {
           PlayerScript.instance.keyAmount -= 1;
           StartCoroutine(PlayLockSound());
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (PlayerScript.instance.hasKey)
    //    {
    //        PlayerScript.instance.keyAmount -= 1;
    //        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    //        StartCoroutine(PlayLockSound());
    //    }
    //}

    IEnumerator PlayLockSound()
    {
        PlayerScript.instance.gameSounds.PlayOneShot(PlayerScript.instance.lockSoundTrimmed);
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
