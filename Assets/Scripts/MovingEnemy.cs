using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    // Start
    public GameObject[] checkPoints;
    public float waitTime = 1f;
    int index = 0;
    Rigidbody2D rb;
    public float speed;

    float moveTime = 0f;
    bool moving = true;
    float _vx = 0f;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= moveTime)
        {
            EnemyMove();
        }

    }
    private void EnemyMove()
    {
        if (checkPoints.Length != 0 && moving)
        {
            flip(_vx);
            _vx = checkPoints[index].transform.position.x - transform.position.x;
            if (Mathf.Abs(_vx) <= 0.05)
            {
                rb.velocity = new Vector2(0, 0);
                index++;
                if (index >= checkPoints.Length)
                {
                    index = 0;
                }
            }
            else
            {
                rb.velocity = new Vector2(transform.localScale.x * speed, rb.velocity.y);
            }

        }
    }
    private void flip(float vx)
    {
        Vector3 localScale = transform.localScale;

        if ((_vx > 0f) && (localScale.x < 0f))
            localScale.x *= -1;
        else if ((_vx < 0f) && (localScale.x > 0f))
            localScale.x *= -1;

        // update the scale
        transform.localScale = localScale;
    }
}
