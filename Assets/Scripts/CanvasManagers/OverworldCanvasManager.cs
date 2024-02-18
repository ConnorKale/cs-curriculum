using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverworldCanvasManager : MonoBehaviour
{
    private HUD hud;
    
    public TextMeshProUGUI coinTextOverworld;
    public TextMeshProUGUI healthTextOverworld;
    public TextMeshProUGUI weaponTextOverworld;

// Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();

        Object[] allHuds = GameObject.FindObjectsOfType<HUD>();
        Debug.Log($"Overworld using HUD {hud.name} out of {allHuds.Length} huds");
    }

    // Update is called once per frame
    void Update()
    {
        coinTextOverworld.text = $"Coins: {hud.coins}";
        healthTextOverworld.text = $"Health: {hud.health}";
        if (hud.weapon == 0)
        {
            weaponTextOverworld.text = "Weapon: Shovel";
        }
        
        if (hud.weapon == 1)
        {
            weaponTextOverworld.text = "Weapon: Axe";
        }
    }
}
