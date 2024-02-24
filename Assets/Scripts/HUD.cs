using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD hud;
    public int coins;
    public int maxCoins;
    public int lastSavedCoins;
    public int weapon;
    public int lastSavedWeapon;
    public int health;
    public int maxHealth;
    public int lastSavedHealth;

    public bool door;
    public bool lastSavedDoor;
    public bool cp1;
    public bool lastSavedcp1;
    public bool aftercp1;
    public bool lastSavedAftercp1;
    public bool cp2;
    public bool lastSavedcp2;
    
    public CollectCoins CollectCoins;
    public HealthManager HealthManager;
    public CollectAxe CollectAxe;
    //Awake is called before anything else.
    public string name = System.Guid.NewGuid().ToString();

    void Awake()
    {
        Debug.Log($"HUD [{name}] awake");
        if (hud != null && hud != this) // If there's a hud and it's not me
        {
            Debug.Log($"HUD [{name}] destroying self due to other HUD [{hud.name}]");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"HUD [{name}] we are the HUD");
            hud = this;
            name = $"[{name}], the original HUD";
            DontDestroyOnLoad(gameObject);
            hud.Start();
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        maxCoins = 1024;
        maxHealth = 16;
        weapon = 0;
        health = maxHealth;
        
        door = false;
        cp1 = false;
        aftercp1 = false;
        cp2 = false;
    }

    // Update is called once per frame
    void Update()
    {

//        Debug.Log("weapon = "+weapon);
//        Debug.Log("Text should say " +weaponText.text);
    }

    public void Save()
    {
        lastSavedCoins = coins;
        lastSavedHealth = health;
        lastSavedWeapon = weapon;

        lastSavedDoor = door;
        lastSavedcp1 = cp1;
        lastSavedAftercp1 = aftercp1;
        lastSavedcp2 = cp2;
    }

    public void Restore()
    {
        coins = lastSavedCoins;
        health = lastSavedHealth;
        weapon = lastSavedWeapon;

        door = lastSavedDoor;
        cp1 = lastSavedcp1;
        aftercp1 = lastSavedAftercp1;
        cp2 = lastSavedcp2;

    }
}
