using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD hud;
    public int coins;
    public int weapon;
    public int health;
    public int maxHealth;

    public CollectCoins CollectCoins;
    public HealthManager HealthManager;
    public CollectAxe CollectAxe;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI weaponText;
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
        weapon = 0;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coins;
        healthText.text = "Health: " + health;
        if (weapon == 0)
        {
            weaponText.text = "Weapon: Shovel";
        }
        
        if (weapon == 1)
        {
            weaponText.text = "Weapon: Axe";
        }
    }
}
