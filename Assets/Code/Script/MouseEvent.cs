using System;
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
            Vector3 pos = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), 0);
            SpawnEntity(pos);
        }
        if (Input.GetMouseButton(1) && entities.Count > 0)
        {
            for (int i = 0; i < Math.Clamp(entities.Count, 0, 100); i++)
            {
                Destroy(entities[0]);
                entities.RemoveAt(0);
            }
        }
        if (Input.GetMouseButton(2) && prefab != null)
        {
            Vector3 pos = new Vector3(0, 0, 0);
            for (int i = 0; i < 100; i++) {
                pos = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), 0);
                SpawnEntity(pos);
            }
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
