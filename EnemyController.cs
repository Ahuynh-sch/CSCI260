using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //private SpriteRenderer mySpriteRenderer;
    public bool facingRight = true;

    private Animator anim;
    private Transform target;
    public Transform homePos;
    [SerializeField] private float speed;
    [SerializeField] private float minRange;
    private float maxRange = 5;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
        //mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if(Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }
        
    }

    public void FollowPlayer()
    {
     
        if ((transform.position.x - target.localPosition.x) < 0 && !facingRight)
        {
            Flip();
        }
        else if ((transform.position.x - target.localPosition.x) > 0 && facingRight)
        {
            Flip();
        }
        anim.SetBool("isMoving", true);
        anim.SetFloat("moveX", (target.position.x - transform.position.x));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        //mySpriteRenderer.flipX = true;
    }

    public void GoHome()
    {
        if ((transform.position.x - homePos.localPosition.x) < 0 && !facingRight)
        {
            Flip();
        }
        else if ((transform.position.x - homePos.localPosition.x) > 0 && facingRight)
        {
            Flip();
        }
        anim.SetFloat("moveX", (target.position.x - transform.position.x));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
        

        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            anim.SetBool("isMoving", false);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "MyWeapon")
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }
}
