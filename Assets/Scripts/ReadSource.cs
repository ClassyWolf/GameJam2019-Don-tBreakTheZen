using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ReadSource : MonoBehaviour
{
    [SerializeField] private GameObject sourcePanel;

    private void Start()
    {
#if UNITY_EDITOR
        string source = string.Empty;
        string[] files = Directory.GetFiles(Application.dataPath + "/Scripts/", "*.cs");
        foreach (string file in files)
        {
            source += File.ReadAllText(file, Encoding.UTF8) + Environment.NewLine + Environment.NewLine;
        }
        File.WriteAllText(Application.dataPath + "/source.txt", source);
#endif
    }

    private void Update()
    {
        if (Input.touchCount >= 3)
        {
            sourcePanel.SetActive(true);
        }
    }
}
