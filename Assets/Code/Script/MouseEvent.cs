using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    public GameObject prefab = null;
    // list of entities
    private List<GameObject> entities = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButton(0) && prefab != null)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            SpawnEntity(pos);
        }
        if (Input.GetMouseButton(1) && entities.Count > 0)
        {
            Destroy(entities[0]);
            entities.RemoveAt(0);
        }
        if (Input.GetMouseButton(2) && prefab != null)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            for (int i = 0; i < 100; i++)
                SpawnEntity(pos);
        }
    }

    void SpawnEntity(Vector3 pos)
    {
        entities.Add(Instantiate(prefab, pos, Quaternion.identity));
    }

    public List<GameObject> GetEntities()
    {
        return entities;
    }
}
