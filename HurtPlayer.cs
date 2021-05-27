using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private HealthManager healthMan;
    public float waitToHurt = 1f;
    public bool isTouching;
    [SerializeField] private int damageToGive = 10;

    public Animator anim;
    private float attackTime = .40f;
    private float attackCounter = .40f;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (reloading)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }*/
        if (isTouching)
        {
            Attack();
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthMan.HurtPlayer(damageToGive);
                waitToHurt = 1.5f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);

            //reloading = true;

        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
        }
  
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = false;
            anim.SetBool("isAttacking", false);
            waitToHurt = 1.5f;
        }
    }

    void Attack()
    {
        if (isAttacking)
        {
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                anim.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }
        if (!isAttacking)
        {
            attackCounter = attackTime;
            anim.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }
}
