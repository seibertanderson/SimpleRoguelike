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
    public float walkSpeed = 2;    
    private Rigidbody2D rb2d;
    private Transform playerTarget;
    private PlayerScript playerScript;
    private bool facingRight = true;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        playerTarget = FindObjectOfType<PlayerScript>().transform;
        playerScript = FindObjectOfType<PlayerScript>();
    }

    private void Update()
    {
        MoveEnemy();
        AtualizarUI();
    }

    public void AtualizarUI()
    {
        lifeBar.value = enemyLife;
    }

    public void MoveEnemy()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, playerTarget.transform.position, Time.deltaTime * walkSpeed);
        rb2d.MovePosition(newPosition);
        if ((rb2d.velocity.x < 0f && facingRight) || (rb2d.velocity.x > 0f && !facingRight))
        {
            FlipEnemy();
        }
    }

    public void FlipEnemy()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
    }

    IEnumerator DamageEffect()
    {
        float actualSpeed = walkSpeed;
        walkSpeed *= -1;
        rb2d.AddForce(new Vector2(transform.position.x * -200f, transform.position.y * -200f));
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        walkSpeed = actualSpeed;
        sprite.color = Color.white;
    }

    void DamageEnemy()
    {
        enemyLife--;
        StartCoroutine(DamageEffect());
        if (enemyLife < 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

        }
        if (col.CompareTag("Attack"))
        {
            DamageEnemy();
        }
    }
}
