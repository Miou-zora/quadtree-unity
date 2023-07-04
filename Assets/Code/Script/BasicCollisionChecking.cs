using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCollisionChecking : MonoBehaviour
{
    private MouseEvent mouseEvent;

    void Start()
    {
        mouseEvent = GetComponent<MouseEvent>();
    }

    void Update()
    {
        List<GameObject> entities = mouseEvent.GetEntities();
        foreach (GameObject entity in entities)
        {
            entity.GetComponent<SpriteRenderer>().color = Color.white;
        }
        for (int i = 0; i < entities.Count; i++)
        {
            DoesEntityCollide(entities[i], i);
        }
    }

    void DoesEntityCollide(GameObject entity, int index)
    {
        for (int i = 0; i < mouseEvent.GetEntities().Count; i++)
        {
            if (i == index)
                continue;
            if (entity.GetComponent<Collider2D>().bounds.Intersects(mouseEvent.GetEntities()[i].GetComponent<Collider2D>().bounds))
                entity.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
