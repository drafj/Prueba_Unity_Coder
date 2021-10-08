using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform toFollow;
    private void Follow()
    {
        Vector3 newPos = new Vector3(toFollow.position.x, transform.position.y, toFollow.position.z);
        transform.position = newPos;
    }
    void Update()
    {
        Follow();
    }
}
