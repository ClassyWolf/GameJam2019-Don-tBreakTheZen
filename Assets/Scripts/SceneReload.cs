using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour
{
    [SerializeField] Transform EndPanel;
    [SerializeField] Transform Player;
    //reloads the scene
    public void EndGame()
    {
        Player.gameObject.SetActive(false);
        EndPanel.gameObject.SetActive(true);
    }
}
