using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private float startY;
    [SerializeField] private float gap;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private int initialPlatforms;
    [SerializeField] private int maxPlatforms;
    [SerializeField] [Range(0, 100)] private int pickupChange;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private GameObject backgroundPrefab;
    [SerializeField] private GameObject[] pickupPrefabs;

    private Queue<GameObject> platforms = new Queue<GameObject>();
    private Queue<GameObject> backgrounds = new Queue<GameObject>();
    private float currentY;
    private float lastSpawnY;

    [SerializeField] private StringLibrary stringLibrary;
    [SerializeField] private int distractionLenght = 5;
    [SerializeField] private GameObject BgSpeechPefab;
    [SerializeField] private GameObject BgThoughtPrefab;
    [SerializeField] private float bubbleOffset = 3;
    [SerializeField] private float bubbleDown = 12;

    [SerializeField] private Text curseText1;
    [SerializeField] private Text curseText2;
    [SerializeField] private Text curseText3;
    [SerializeField] private Text curseText4;
    [SerializeField] private Text curseText5;

    [SerializeField] private Text messageText1;
    [SerializeField] private Text messageText2;
    [SerializeField] private Text messageText3;
    [SerializeField] private Text messageText4;
    [SerializeField] private Text messageText5;

    private int curseCount = 0;
    private int messageCount = 0;

    private void Start()
    {
        currentY = startY;
        lastSpawnY = player.transform.position.y;
        for (int i = 0; i < initialPlatforms; i++)
        {
            Spawn();
        }
    }

    private void Update()
    {
        if (player.transform.position.y >= lastSpawnY + gap)
        {
            Spawn();
            lastSpawnY += gap;
        }
    }

    private void Spawn()
    {
        // Spawn platform
        GameObject platform = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], new Vector3(Random.Range(minX, maxX), currentY, 0), Quaternion.identity);
        platforms.Enqueue(platform);
        // Spawn background
        GameObject background = Instantiate(backgroundPrefab, new Vector3(Random.Range(minX, maxX), currentY, 0), Quaternion.identity);
        background.GetComponent<Animator>().SetInteger("Animation", Random.Range(1, 5));
        backgrounds.Enqueue(background);
        // Spawn pickup
        if (Random.Range(0, 100) < pickupChange)
        {
            Instantiate(pickupPrefabs[Random.Range(0, pickupPrefabs.Length)], new Vector3(Random.Range(minX, maxX), currentY + 1, 0), Quaternion.identity);
        }
        // Destory oldest platform
        if (platforms.Count >= maxPlatforms)
        {
            Destroy(backgrounds.Dequeue());
            Destroy(platforms.Dequeue());
        }

        currentY += gap;
    }

    public void BackgroundCurse()
    {
        StartCoroutine(BgCurse());
    }

    public void BackgroundMessage()
    {
        StartCoroutine(BgMessage());
    }

    private IEnumerator BgCurse()
    {
        Debug.Log(stringLibrary.curseText[curseCount]);
        BgThoughtPrefab.SetActive(true);
        BgThoughtPrefab.transform.position = new Vector3(bubbleOffset, currentY - bubbleDown, 0);
        if (curseCount > stringLibrary.curseLenght)
        {
            curseCount = 0;
        }
        curseText1.text = stringLibrary.curseText[curseCount];
        curseCount++;
        if (curseCount > stringLibrary.curseLenght)
        {
            curseCount = 0;
        }
        curseText2.text = stringLibrary.curseText[curseCount];
        curseCount++;
        if (curseCount > stringLibrary.curseLenght)
        {
            curseCount = 0;
        }
        curseText3.text = stringLibrary.curseText[curseCount];
        curseCount++;
        if (curseCount > stringLibrary.curseLenght)
        {
            curseCount = 0;
        }
        curseText4.text = stringLibrary.curseText[curseCount];
        curseCount++;
        if (curseCount > stringLibrary.curseLenght)
        {
            curseCount = 0;
        }
        curseText5.text = stringLibrary.curseText[curseCount];
        curseCount++;
        if (curseCount > stringLibrary.curseLenght)
        {
            curseCount = 0;
        }

        yield return new WaitForSeconds(distractionLenght);
        BgThoughtPrefab.SetActive(false);
    }

    private IEnumerator BgMessage()
    {
        if (messageCount > stringLibrary.messageLength)
        {
            messageCount = 0;
        }
        Debug.Log(stringLibrary.messageText[messageCount]);
        BgSpeechPefab.SetActive(true);
        Vector3 temp = new Vector3(7.0f, 0, 0);
        BgSpeechPefab.transform.position = new Vector3(bubbleOffset, currentY - bubbleDown, 0);
        if (messageCount > stringLibrary.messageLength)
        {
            messageCount = 0;
        }
        messageText1.text = stringLibrary.messageText[messageCount];
        messageCount++;
        if (messageCount > stringLibrary.messageLength)
        {
            messageCount = 0;
        }
        messageText2.text = stringLibrary.messageText[messageCount];
        messageCount++;
        if (messageCount > stringLibrary.messageLength)
        {
            messageCount = 0;
        }
        messageText3.text = stringLibrary.messageText[messageCount];
        messageCount++;
        if (messageCount > stringLibrary.messageLength)
        {
            messageCount = 0;
        }
        messageText4.text = stringLibrary.messageText[messageCount];
        messageCount++;
        if (messageCount > stringLibrary.messageLength)
        {
            messageCount = 0;
        }
        messageText5.text = stringLibrary.messageText[messageCount];
        messageCount++;
        if (messageCount > stringLibrary.messageLength)
        {
            messageCount = 0;
        }

        yield return new WaitForSeconds(distractionLenght);
        BgSpeechPefab.SetActive(false);
    }
}
