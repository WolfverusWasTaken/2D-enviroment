using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAI : MonoBehaviour
{
    //public Rigidbody2D rb;
    public Vector3 movement;
    public Transform Mob;
    public Animator animator;
    private Rigidbody2D rb;

    private bool ActivateWander;

    [Range(1, 10)]
    public float moveSpeed;

    private bool trig;

    // Start is called before the first frame update
    void Start()
    {
        
        
        rb = this.GetComponent<Rigidbody2D>();
        moveSpeed = 0.5f;
        ActivateWander = false;
        StartCoroutine(Wander());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        

        if (movement.x <= 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (movement.x >= 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        rb.MovePosition(new Vector2(transform.position.x + movement.x * moveSpeed * Time.fixedDeltaTime, transform.position.y + movement.y * moveSpeed * Time.fixedDeltaTime));
        //transform.position = Mob.position + movement * moveSpeed * Time.fixedDeltaTime;
    }

    IEnumerator Wander()
    {
        while (true)
        {
            movement.x = Random.Range(-2, 2);
            movement.y = Random.Range(-2, 2);
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Trigger!");
        
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
