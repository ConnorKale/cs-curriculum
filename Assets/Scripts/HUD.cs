using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD hud;
    public int coins;
    public int weapon;
    public int health;
    public int maxHealth;

    public bool cp1;
    
    public CollectCoins CollectCoins;
    public HealthManager HealthManager;
    public CollectAxe CollectAxe;
    //Awake is called before anything else.
    void Awake()
    {
        if (hud != null && hud != this) // If there's a hud and it's not me
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
        maxHealth = 50;
        weapon = 0;
        health = maxHealth;
        
        cp1 = false;
    }

    // Update is called once per frame
    void Update()
    {
       
//        Debug.Log("weapon = "+weapon);
//        Debug.Log("Text should say " +weaponText.text);
    }
}
