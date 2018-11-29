using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelScript : MonoBehaviour
{

    public GameObject panelInventory;
    public GameObject panelPlayerStats;

    public Text playerLife;
    public Text playerExperience;
    public Text playerLevel;
    public Text playerDefense;
    public Text playerAttack;

    private PlayerScript player;


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            panelInventory.SetActive(!panelInventory.activeInHierarchy);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            panelPlayerStats.SetActive(!panelPlayerStats.activeInHierarchy);
        }

        playerLife.text = "Life " + player.playerLife;
        playerExperience.text = "Exp " + player.playerExperience;
        playerLevel.text = "Lvl " + player.playerLevel;
        playerDefense.text = "Def " + player.playerDefense;
        playerAttack.text = "Atk " + player.playerAttack;

    }

    public void CloseInventory()
    {
        panelInventory.SetActive(!panelInventory.activeInHierarchy);
    }

    public void ClosePlayerStats()
    {
        panelPlayerStats.SetActive(!panelPlayerStats.activeInHierarchy);
    }
}
