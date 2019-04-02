using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Pickup : MonoBehaviour
{
    [SerializeField] private UnityEvent onPick;

    private void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            onPick.Invoke();
            Destroy(gameObject);
            Debug.Log("Pickup taken");
        }
    }
}
