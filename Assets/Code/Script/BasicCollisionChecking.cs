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
            DoesEntityCollide(entities[i], entities, i);
        }
    }

    void DoesEntityCollide(GameObject entity, List<GameObject> list, int index)
    {
        for (int i = index + 1; i < list.Count; i++)
        {
            var isCollision = entity.GetComponent<Collider2D>().bounds.Intersects(list[i].GetComponent<Collider2D>().bounds);
            if (isCollision)
            {
                entity.GetComponent<SpriteRenderer>().color = Color.red;
                list[i].GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
