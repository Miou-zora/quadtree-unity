using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityScript : MonoBehaviour
{
    private Vector2 direction;
    private float speed;
    void Start()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        speed = Random.Range(5f, 15f);
    }

    void FixedUpdate()
    {
        transform.Translate(direction * Time.deltaTime * speed);
        if (transform.position.x > 10 || transform.position.x < -10)
        {
            direction.x *= -1;
        }
        if (transform.position.y > 10 || transform.position.y < -10)
        {
            direction.y *= -1;
        }
    }
}
