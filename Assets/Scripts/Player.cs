using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Stat health;


    private float initHealth = 100;

    Vector2 direction;
    [SerializeField]
    float movementSpeed = 0.25f;

    public Rigidbody2D playerrb;
    public Animator animator;

    void Start()
    {
        health.Initialize(initHealth, initHealth);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();
        Move();
    }

    public void Move()
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime);
        if (direction.x != 0 || direction.y !=0)
        {
            AnimateMovement(direction);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    private void GetInput()
    {
        direction = Vector2.zero;

        //Для Дебагинга

        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue += 10;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            health.MyCurrentValue -= 10;
        }

        //



        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }

    public void AnimateMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }

}
