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
        // transform.Translate(direction * Time.deltaTime * speed);
        transform.position += (Vector3)direction * Time.deltaTime * speed;
        Vector3 pos = transform.position;
        pos.x = ((pos.x + 10f) % 20f + 20f) % 20f - 10f;
        pos.y = ((pos.y + 10f) % 20f + 20f) % 20f - 10f;
        transform.position = pos;
    }
}
