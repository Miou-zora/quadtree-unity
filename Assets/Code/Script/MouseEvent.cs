using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    public GameObject prefab = null;

    void Update()
    {
        if (Input.GetMouseButton(0) && prefab != null)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            SpawnEntity(pos);
        }
    }

    void SpawnEntity(Vector3 pos)
    {
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
