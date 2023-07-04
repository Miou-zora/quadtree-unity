using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MouseEvent))]
public class QuadTreeCollisionChecking : MonoBehaviour
{
    QuadTree quadTree = null;
    void Start()
    {
        quadTree = new QuadTree(new Bounds(new Vector3(0, 0, 0), new Vector3(20, 20, 0)), 4);
        foreach (GameObject entity in GetComponent<MouseEvent>().GetEntities())
        {
            quadTree.insert(entity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        quadTree.clear();
        foreach (GameObject entity in GetComponent<MouseEvent>().GetEntities())
        {
            quadTree.insert(entity);
        }
        List<GameObject> entities = GetComponent<MouseEvent>().GetEntities();
        for (int i = 0; i < entities.Count; i++)
        {
            if (DoesEntityCollide(entities[i])) {
                entities[i].GetComponent<SpriteRenderer>().color = Color.red;
            } else {
                entities[i].GetComponent<SpriteRenderer>().color = Color.white;
            };
        }
    }

    bool DoesEntityCollide(GameObject entity)
    {
        BoxCollider2D collider = entity.GetComponent<BoxCollider2D>();
        Bounds bounds = collider.bounds;
        bounds.size *= 2;
        List<GameObject> entities = quadTree.query(bounds);
        foreach (GameObject iEntity in entities)
        {
            if (iEntity == entity)
                continue;
            if (collider.bounds.Intersects(iEntity.GetComponent<BoxCollider2D>().bounds))
                return true;
        }
        return false;
    }

    void OnDrawGizmos()
    {
        if (quadTree == null)
        {
            return;
        }
        quadTree.draw();
    }
}
