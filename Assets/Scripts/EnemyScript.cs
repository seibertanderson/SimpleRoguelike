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
    public Transform playerTarget;
    public PlayerScript playerScript;
    public Slider lifeBar;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //MoveEnemy();
        AtualizarUI();
    }
    public void AtualizarUI()
    {
        lifeBar.value = enemyLife;
    }

    //MoveEnemy is called by the GameManger each turn to tell each Enemy to try to move towards the player.
    //public void MoveEnemy()
    //{
    //    if (!FindObjectOfType<PlayerScript>().playerTurn)
    //    {
    //        float xDir = 0;
    //        float yDir = 0;

    //        var calcY = playerTarget.position.y - transform.position.y;
    //        var calcX = playerTarget.position.x - transform.position.x;
    //        if (calcY < float.Epsilon)
    //        {
    //            yDir = -0.3f;
    //        }
    //        else// if (calcY > float.Epsilon)
    //        {
    //            yDir = 0.3f;
    //        }
    //        if (calcX < float.Epsilon)
    //        {
    //            xDir = -0.3f;
    //        }
    //        else// if (calcX > float.Epsilon)
    //        {
    //            xDir = 0.3f;
    //        }

    //        this.gameObject.transform.position = new Vector2(transform.position.x + xDir, transform.position.y + yDir);
    //        FindObjectOfType<PlayerScript>().playerTurn = true;
    //    }
    //}
}
