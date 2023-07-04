 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MouseEvent))]
public class GenerateQuadTree : MonoBehaviour
{
    QuadTree quadTree = null;

    void Start()
    {
        quadTree = new QuadTree(new Rect(-10, -10, 20, 20), 5);
        foreach (GameObject entity in GetComponent<MouseEvent>().GetEntities())
        {
            Vector2 position = entity.transform.position;
            quadTree.insert(position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        quadTree.clear();
        foreach (GameObject entity in GetComponent<MouseEvent>().GetEntities())
        {
            Vector2 position = entity.transform.position;
            quadTree.insert(position);
        }
    }

    void OnDrawGizmos()
    {
        if (quadTree == null)
        {
            return;
        }
        quadTree.draw();
        // create a rect linked to mouse position with 3 3 size and mouse position as center
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float size = 3;
        Rect rect = new Rect(mousePosition.x - size / 2, mousePosition.y - size / 2, size, size);
        foreach (Vector2 point in quadTree.query(rect)) {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(point, 0.05f);
        }
    }
}
