using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Transform playerPosition;

    public void LateUpdate()
    {
        Vector3 mapPosition = playerPosition.position;
        mapPosition.y = transform.position.y;
        transform.position = mapPosition;
    }
}
