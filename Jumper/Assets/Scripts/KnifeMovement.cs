using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    public bool moveRight;
    public float knifeSpeed = 3f;

    void Start()
    {
        Invoke("DestroyAfterTime", 4.5f);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;

        if (moveRight)
        {
            temp.x += knifeSpeed * Time.deltaTime;
        } 
        else {
            temp.x -= knifeSpeed * Time.deltaTime;
        }

        transform.position = temp;
    }

    void DestroyAfterTime()
    {
        Destroy(gameObject);
    }
}
