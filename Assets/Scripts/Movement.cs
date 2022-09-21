using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject respawn;
    public CharacterController controller2D;
    public float moveSpeed = 10f;
    float x = 0f;
    public float jumpSpeed = 5f;
    bool jump = false;
    bool crouch = false;
    Animator animator;
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetType() == typeof(EdgeCollider2D))
        {
            Debug.Log("hit");
            Destroy(collision.transform.gameObject);
        }
        else if (collision.collider.GetType() == typeof(BoxCollider2D))
        {
            NewMove cut = gameObject.GetComponent<NewMove>();
            cut.cut();
        }

    }
    // Update is called once per frame
    void Update()
    {

        x = Input.GetAxis("Horizontal") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(x));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            Debug.Log("jump");
            animator.SetBool("Jump", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (transform.position.y <= -6f)
        {
            Debug.Log("u died");
            NewMove cut = gameObject.GetComponent<NewMove>();
            cut.cut();
            transform.position = respawn.transform.position;
            //message or scene after death
        }

    }
    public void isLanded()
    {
        animator.SetBool("Jump", false);
    }
    public void isCrouch()
    {
        animator.SetBool("Crouch", crouch);
    }

    private void FixedUpdate()
    {
        controller2D.Move(x * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
