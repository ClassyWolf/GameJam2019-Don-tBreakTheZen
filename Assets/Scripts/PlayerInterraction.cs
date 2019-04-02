using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterraction : MonoBehaviour
{
    [SerializeField] private int jumpForce = 10;
    [SerializeField] private int speed = 10;
    [SerializeField] private float delay;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private SceneReload sceneReload;
    [SerializeField] private Transform playerBody;

    [SerializeField] private float timerFeather = 1;
    [SerializeField] private float timerDistraction = 10;
    [SerializeField] private float lowGravity = 0.1f;
    [SerializeField] private float highGravity = 10;

    [SerializeField] SoundLibrary soundLibrary;
    [SerializeField] LevelGenerator levelGenerator;

    private Vector2 target;
    private Animator animator;


    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        animator.SetFloat("VelocityY", player.velocity.y);
#if UNITY_EDITOR
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            //starting the game by changing the player body type
            player.bodyType = RigidbodyType2D.Dynamic;

            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.x, transform.position.y), step);
            Time.timeScale = Input.mousePosition.y / Screen.height * 2;
        }

        else if(Input.GetMouseButtonUp(0))
        {
            //The game starts over if the mouse (or finger) is lifted
            sceneReload.EndGame();
            soundLibrary.PlayfailiureSound();
            Debug.Log("whoops you lost");
        }
#endif
#if UNITY_ANDROID
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            target = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                {
                        player.bodyType = RigidbodyType2D.Dynamic;
                        break;
                }

                case TouchPhase.Stationary:
                case TouchPhase.Moved:
                {
                        float step = speed * Time.deltaTime;
                        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.x, transform.position.y), step);
                        Time.timeScale = touch.position.y / Screen.height * 2;
                        break;
                }                 

                case TouchPhase.Ended:
                {
                        sceneReload.EndGame();
                        break;
                }                    
            }
        }
#endif
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //makes the player jump off of platforms
        if (collision.transform.CompareTag("Platform") && collision.enabled)
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
            soundLibrary.PlayjumpSound();
            //Debug.Log("moving upwards");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Feather"))
        {
            StartCoroutine(FeatherCor());
        }

        if (collision.transform.CompareTag("Distraction"))
        {
            StartCoroutine(NoiseCor());
        }


        if (collision.transform.CompareTag("DistractionStory"))
        {
            //StartCoroutine(NoiseCor());
            levelGenerator.BackgroundCurse();
        }


        if (collision.transform.CompareTag("DistractionNoise"))
        {
            //StartCoroutine(NoiseCor());
            levelGenerator.BackgroundMessage();
        }
    }

    private IEnumerator FeatherCor()
    {
        Debug.Log("light as a feather");
        soundLibrary.PlayFeatherSound();
        player.gravityScale = lowGravity;
        yield return new WaitForSeconds(timerFeather);
        player.gravityScale = 1;
        Debug.Log("Corutine End");
    }

    private IEnumerator NoiseCor()
    {
        Debug.Log("NISE SOUNDS!!!!");
        soundLibrary.PlayNoiseSounds();
        yield return new WaitForSeconds(timerDistraction);
    }
}
