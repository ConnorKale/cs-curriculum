using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD hud;
    public int coins;
    public int health;
    public int maxHealth;

    public CollectCoins CollectCoins;
    public HealthManager HealthManager;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    
    //Awake is called before anything else.
    void Awake()
    {
        if (hud != null && hud != this)
        {
            Destroy(gameObject);
        }
        else
        {
            hud = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        maxHealth = 10;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coins;
        healthText.text = "Health: " + health;
    }
}
