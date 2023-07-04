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
    }

    void OnDrawGizmos()
    {
        if (quadTree == null)
        {
            return;
        }
        quadTree.draw();
        // use mouse pos
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Bounds bounds = new Bounds(mousePos, new Vector3(5, 5, 0));
        foreach (GameObject entity in quadTree.query(bounds)) {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(entity.GetComponent<Collider2D>().bounds.center, 0.05f);
        }
    }
}
