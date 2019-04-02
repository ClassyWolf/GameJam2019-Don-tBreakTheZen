using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private float delay = 2;
    [SerializeField] private SceneReload sceneReload;
    [SerializeField] private SoundLibrary soundLibrary;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Starts the game over if the player hits the deathzone
        if (collision.transform.CompareTag("Player"))
        {
            sceneReload.EndGame();
            soundLibrary.PlayfailiureSound();
            Debug.Log("whoops you lost");
        }
    }
}
