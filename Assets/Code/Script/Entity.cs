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

    void Update()
    {
        Vector2 position = transform.position;
        position += direction * Time.deltaTime * speed;
        position.x = Mathf.Repeat(position.x + 30f, 20f) - 10f;
        position.y = Mathf.Repeat(position.y + 30f, 20f) - 10f;
        transform.position = position;
    }
}
