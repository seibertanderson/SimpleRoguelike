using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedCombatStateMachine : MonoBehaviour
{
    public bool battle = false;
    [HideInInspector]
    public PlayerScript player;
    [HideInInspector]
    public EnemyScript enemy;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //while (battle == true)
        //{
        //    PlayerChoose();
        //    PlayerAttack();

        //    EnemyChoose();
        //    EnemyAttack();
        //}
        if (battle)
        {
            PlayerChoose();
            PlayerAttack();

            EnemyChoose();
            EnemyAttack();

            EndRound();
        }
    }

    void PlayerChoose()
    {

    }

    void PlayerAttack()
    {
        if (enemy != null)
        {
            enemy.enemyLife--;
        }
    }

    void EnemyChoose()
    {

    }

    void EnemyAttack()
    {
        if (player != null)
        {
            player.playerLife--;
        }
    }

    void EndRound()
    {
        if (enemy != null)
        {
            if (enemy.enemyLife == 0)
            {
                Destroy(enemy.gameObject);
            }
        }
        battle = false;
    }
}
