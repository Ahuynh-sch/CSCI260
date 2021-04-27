using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3;
    public Rigidbody2D playerRb;
    public Animator anim;
    private float screenEdge = 9;

    private static bool playerExist;

    //private Inventory inventory;
    //[SerializeField] private UI_Inventory uiInventory;

    private float attackTime = .40f;
    private float attackCounter = .40f;
    private bool isAttacking;

    Vector2 movement;

    private void Start()
    {
        if (!playerExist)
        {
            playerExist = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
        //inventory = new Inventory();
        //uiInventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    { 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("moveX", movement.x);
        anim.SetFloat("moveY", movement.y);
        //anim.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            anim.SetFloat("lastMoveX", movement.x);
            anim.SetFloat("lastMoveY", movement.y);
        }

        PlayerAttack();
    }

    void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement.normalized * speed * Time.fixedDeltaTime);
        // limits players movement to scene
        /*if (transform.position.x > screenEdge)
        {
            transform.position = new Vector2(screenEdge, transform.position.y);
        }*/
        if (transform.position.x < -screenEdge)
        {
            transform.position = new Vector2(-screenEdge, transform.position.y);
        }
    }

    void PlayerAttack()
    {
        if (isAttacking)
        {
            speed = 0;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                anim.SetBool("isAttacking", false);
                isAttacking = false;
                speed = 3;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            attackCounter = attackTime;
            anim.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

}
