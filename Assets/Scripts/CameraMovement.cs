using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float offsetY;
    [SerializeField] private Transform target;

    private void Update()
    {
        if (target.transform.position.y + offsetY > transform.position.y)
        {
            Vector3 position = transform.position;
            position.y = target.transform.position.y + offsetY;
            transform.position = position;
        }
    }
}
