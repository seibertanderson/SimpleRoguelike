using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public int playerLife;
    public Slider lifeBar;

    private Rigidbody2D rb2d;
    public float moveQuantity = .5f;


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
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AtualizarUI();
        MoverJogadorTransform();
    }

    private void FixedUpdate()
    {

    }



    public void MoverJogadorTransform()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - moveQuantity, transform.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + moveQuantity, transform.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveQuantity);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveQuantity);
        }
    }
    public void AtualizarUI()
    {
        lifeBar.value = playerLife;
    }

    public Item woodSword;
    public Item healthBar;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Equals("woodSword"))
        {
            GetComponent<Inventory>().AddItem(woodSword);
            Destroy(col.gameObject);
        }

        if (col.name.Equals("healthPotion"))
        {
            GetComponent<Inventory>().AddItem(healthBar);
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
}
