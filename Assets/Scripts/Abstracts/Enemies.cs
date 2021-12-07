using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    public float enemyMovement;
    public float enemySpeed;

    public virtual void Start()
    {
        enemyMovement = 0f;
        enemySpeed = 0f;
    }
}
