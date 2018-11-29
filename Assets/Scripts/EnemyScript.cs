using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public int enemyLevel = 0;
    public int enemyAttack = 1;
    public int enemyDefense = 1;
    public int enemyLife;    

    public Slider lifeBar;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AtualizarUI();
    }
    public void AtualizarUI()
    {
        lifeBar.value = enemyLife;
    }
}
