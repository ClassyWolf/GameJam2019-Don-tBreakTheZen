using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneMovement : MonoBehaviour
{
    [SerializeField] private float upwardsPush = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            transform.position = new Vector2(0f, transform.position.y + upwardsPush);

        }
    }
}