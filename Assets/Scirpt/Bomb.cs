using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Building")
        {
            Score.score += 1;
            Destroy(gameObject);
            playExplosion();
        }
    }

    private void playExplosion()
    {
        GameObject e = Instantiate(explosion) as GameObject;
        e.transform.position = transform.position;
        Destroy(e, 2.0f);
    }
}
