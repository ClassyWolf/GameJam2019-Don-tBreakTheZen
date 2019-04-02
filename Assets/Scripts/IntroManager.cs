using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenImages = 5;
    [SerializeField] private GameObject[] images;

    private void Start()
    {
        foreach (GameObject image in images)
        {
            image.SetActive(false);
        }
        StartCoroutine(Intro());
    }

    private IEnumerator Intro()
    {
        int index = 1;
        images[0].SetActive(true);
        yield return new WaitForSeconds(timeBetweenImages);
        while (index < images.Length)
        {
            if (index > 0)
            {
                images[index - 1].GetComponent<Animator>().SetTrigger("Out");
            }
            images[index].SetActive(true);
            images[index].GetComponent<Animator>().SetTrigger("In");
            yield return new WaitForSeconds(0.5f);
            if (index > 0)
            {
                images[index - 1].SetActive(false);
            }
            yield return new WaitForSeconds(timeBetweenImages - 0.5f);
            index++;
        }
        for (int i = 0; i < images.Length - 1; i++)
        {
            images[i].SetActive(false);
        }
        images[images.Length - 1].GetComponent<Animator>().SetTrigger("Slide");
    }
}
