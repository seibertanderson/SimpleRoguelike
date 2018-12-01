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
    public bool playerTurn = true;
    public Slider lifeBar;
    public float moveQuantity = .5f;
    private Rigidbody2D rb2d;

    private Inventory inventory;

    static bool created = false;
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
    }

    // Update is called once per frame
    void Update()
    {
        AtualizarUI();
        MoverJogadorTransform();

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

    private void FixedUpdate()
    {

    }


    public void MoverJogadorTransform()
    {
        //if (playerTurn)
        //{
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position = new Vector2(transform.position.x - moveQuantity, transform.position.y);
                playerTurn = false;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position = new Vector2(transform.position.x + moveQuantity, transform.position.y);
                playerTurn = false;
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + moveQuantity);
                playerTurn = false;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - moveQuantity);
                playerTurn = false;
            }
        //}
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

        if (col.name.Equals("#Spider"))
        {
            TurnBasedCombatStateMachine combat = FindObjectOfType<TurnBasedCombatStateMachine>();
            combat.battle = true;
            combat.player = this;
            combat.enemy = col.gameObject.GetComponent<EnemyScript>();
        }
    }
}
