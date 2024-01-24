using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    private HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin_Worth1")) //Collect Copper Coins
        {
            hud.coins += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Coin_Worth10")) //Collect Silver Coins
        {
            hud.coins += 10;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Coin_Worth1000")) //Collect Gold Coins
        {
            hud.coins += 1000;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Coin")) // This collects the original "coins".
        {
            hud.coins += 1;
            Destroy(other.gameObject);
        }
    }

}
