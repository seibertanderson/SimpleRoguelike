using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int playerExperience = 0;
    public int playerLevel = 0;
    public int playerAttack = 1;
    public int playerDefense = 1;
    public int playerLife;
    public float walkSpeed = 3;
    static bool created = false;
    public Slider lifeBar;
    private bool facingRight = true;
    private Rigidbody2D rb2d;
    private Inventory inventory;
    private Animator animator;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        inventory = GetComponent<Inventory>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void AtualizarUI()
    {
        lifeBar.value = playerLife;
    }

    public Item woodSword;
    public Item healthPotion;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Equals("woodSword"))
        {
            GetComponent<Inventory>().AddItem(woodSword);
            Destroy(col.gameObject);
        }

        if (col.name.Equals("healthPotion"))
        {
            healthPotion.quantidade++;
            GetComponent<Inventory>().AddItem(healthPotion);
            Destroy(col.gameObject);
        }

        if (col.name.Equals("Level1Stairs"))
        {
            SceneManager.LoadScene("Dungeon1");
        }

        if (col.name.Equals("StairsupSurface"))
        {
            SceneManager.LoadScene("main");
        }

    }


    public void MovePlayer()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (hor > 0 || ver > 0 || hor < 0 || ver < 0)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
        Vector2 move = new Vector2(hor, ver);
        move = move.normalized * walkSpeed;
        rb2d.velocity = move;
        if ((hor < 0f && facingRight) || (hor > 0f && !facingRight))
        {
            FlipPlayer();
        }
    }


    void FlipPlayer()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
    }

    public void UseHealthPotion()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (var item in inventory.items)
            {
                if (item != null)
                {
                    if (item.name.Equals("HealthPotion") && item.quantidade >= 1)
                    {
                        playerLife = 10;
                        item.quantidade--;
                        if (item.quantidade == 0)
                        {
                            inventory.RemoveItem(item);
                        }
                    }
                }
            }
        }
    }
}
