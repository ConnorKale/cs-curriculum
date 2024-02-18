using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCanvasManager : MonoBehaviour
{
    private HUD hud;
    
    public TextMeshProUGUI coinTextStart;
    public TextMeshProUGUI healthTextStart;
    public TextMeshProUGUI weaponTextStart;

// Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
    }

    // Update is called once per frame
    void Update()
    {
        coinTextStart.text = "Coins: " + hud.coins;
        healthTextStart.text = "Health: " + hud.health;
        if (hud.weapon == 0)
        {
            weaponTextStart.text = "Weapon: Shovel";
        }
        
        if (hud.weapon == 1)
        {
            weaponTextStart.text = "Weapon: Axe";
        }
//    Debug.Log(coinTextStart.text);
//    Debug.Log(healthTextStart.text);
//    Debug.Log(healthTextStart.text);

    }
}
