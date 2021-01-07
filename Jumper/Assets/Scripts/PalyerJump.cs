using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerJump : MonoBehaviour
{
    public Rigidbody2D myBody;
    public float jumpForce = 5f;

    private float maxJump_Y = 4.45f;
    private const string KNIFE_TAG = "Knife";

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameManager.instance.TimerReset();
    }

    void Update()
    {
        Jump();
        CheckBounds();
    }

    void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
        }
    }

    void CheckBounds()
    {
        Vector3 temp = transform.position;

        if(temp.y >= maxJump_Y)
        {
            temp.y = maxJump_Y;
        }

        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == KNIFE_TAG)
        {
            Time.timeScale = 0f;
            GameManager.instance.RestartGame();
        }  
    }
}
