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
    public GameObject attackPrefab;
    public Transform attackSpawnPoint;
    static bool created = false;
    private bool invunarable = false;
    private bool facingRight = true;
    private bool attacking = false;
    public Slider lifeBar;
    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Inventory inventory;
    private CameraScript cameraScript;
    public AudioClip fxAttack;

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
        cameraScript = FindObjectOfType<CameraScript>();
        inventory = GetComponent<Inventory>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayAnimations();
        AtualizarUI();
        MovePlayer();
        InventoryKeyPress();

        if (Input.GetMouseButtonDown(1))
        {
            SoundManager.instance.PlaySound(fxAttack);
            StartCoroutine(Attack());
        }
    }

    public void AtualizarUI()
    {
        lifeBar.value = playerLife;
    }

    public Item woodSword;
    public Item healthPotion;
    ContactPoint2D[] contacts = new ContactPoint2D[2];
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

        if (col.CompareTag("Enemy"))
        {
            DamagePlayer(col.GetComponent<Collider2D>().gameObject);
        }

    }

    public void MovePlayer()
    {
        if (!attacking)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector2 move = new Vector2(hor, ver);
            move = move.normalized * walkSpeed;
            rb2d.velocity = move;
            if ((hor < 0f && facingRight) || (hor > 0f && !facingRight))
            {
                FlipPlayer();
            }
        }
    }

    private void FlipPlayer()
    {
        facingRight = !facingRight;
        spriteRenderer.flipX = !facingRight;
        //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
    }

    public void UseInventoryItem(int index)
    {
        //foreach (var item in inventory.items)
        //{
        //    if (item != null)
        //    {
        //        if (item.name.Equals("HealthPotion") && item.quantidade >= 1)
        //        {
        //            playerLife = 10;
        //            item.quantidade--;
        //            if (item.quantidade == 0)
        //            {
        //                inventory.RemoveItem(item);
        //            }
        //        }
        //    }
        //}
        if (inventory.items[index] != null)
        {
            if (inventory.items[index].name.Equals("HealthPotion") && inventory.items[index].quantidade >= 1)
            {
                playerLife += 2;
                inventory.items[index].quantidade--;
                //if (inventory.items[index].quantidade == 0)
                //{
                //    inventory.RemoveItem(inventory.items[index]);
                //}
                inventory.RemoveItem2(index);
            }
        }
    }

    public void InventoryKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("1 press");
            print(inventory.items[0].name);
            UseInventoryItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("2 press");
            print(inventory.items[1].name);
            UseInventoryItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("3 press");
            print(inventory.items[2].name);
            UseInventoryItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            print("4 press");
            print(inventory.items[3].name);
            UseInventoryItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            print("5 press");
            print(inventory.items[4].name);
            UseInventoryItem(4);
        }
    }

    public IEnumerator Attack()
    {
        attacking = true;
        rb2d.velocity = Vector2.zero;
        GameObject cloneAttack = Instantiate(attackPrefab, attackSpawnPoint.position, attackSpawnPoint.rotation);
        if (!facingRight)
        {
            cloneAttack.transform.eulerAngles = new Vector3(180, 0, 180);
        }

        animator.SetTrigger("punch");
        yield return new WaitForSeconds(.5f);
        attacking = false;

    }

    IEnumerator DamageEffect()
    {
        cameraScript.ShakeCamera(0.5f, 0.04f);
        float actualSpeed = walkSpeed;
        walkSpeed *= -1.5f;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        walkSpeed = actualSpeed;
        spriteRenderer.color = Color.white;
        for (float i = 0f; i < 1f; i += 0.1f)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        invunarable = false;
    }

    public void DamagePlayer(GameObject enemy)
    {
        if (!invunarable)
        {
            //Vector3 forceVec = -enemy.GetComponent<Rigidbody2D>().velocity.normalized * 2000f;
            //rb2d.AddForce(forceVec, ForceMode2D.Force);
            invunarable = true;
            playerLife--;
            StartCoroutine(DamageEffect());
            //SoundManager.instance.PlaySound(fxHurt);
            //Hud.instance.RefreshLife(health);
            if (playerLife < 1)
            {
                //KingDeath();
                //Invoke("ReloadLevel", 3f);
                //gameObject.SetActive(false);
            }
        }
    }

    void PlayAnimations()
    {
        animator.SetBool("walk", rb2d.velocity.x != 0 || rb2d.velocity.y != 0);
    }
}
