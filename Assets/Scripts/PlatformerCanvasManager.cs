using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlatformerCanvasManager : MonoBehaviour
{
    private HUD hud;
    
    public TextMeshProUGUI coinTextPlatformer;
    public TextMeshProUGUI healthTextPlatformer;
    public TextMeshProUGUI weaponTextPlatformer;

// Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
    }

    // Update is called once per frame
    void Update()
    {
        coinTextPlatformer.text = "Coins: " + hud.coins;
        healthTextPlatformer.text = "Health: " + hud.health;
        if (hud.weapon == 0)
        {
            weaponTextPlatformer.text = "Weapon: Shovel";
        }
        
        if (hud.weapon == 1)
        {
            weaponTextPlatformer.text = "Weapon: Axe";
        }
    }
}
