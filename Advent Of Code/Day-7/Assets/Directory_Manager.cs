using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directory_Manager : MonoBehaviour
{
    string path = Application.dataPath + "/directory-setup.txt";
    string[] lines;

    public GameObject origin;

    private GameObject trackingObj;

    // Start is called before the first frame update
    void Start()
    {
        trackingObj = origin;

        lines = System.IO.File.ReadAllLines(path);
        
        for (int i = 0; i < lines.Length; i++)
        {
            string[] splitStr = lines[i].Split(' ');

            // Check if its a command
            if (splitStr[0] == "$")
            {
                // what to do if its change of directory
                if (splitStr[1] == "cd")
                {
                    string dirName = splitStr[2];

                    if (dirName == "/")
                    {
                        ChangeToOrigin();
                    }
                    else
                    {
                        ChangeDir(dirName);
                    }
                }
                else if (splitStr[1] == "ls")
                {
                    List<string> reqContent = new List<string>();
                    bool endOfContent = false;
                    int counter = 1;

                    while (!endOfContent)
                    {
                        if (i + counter >= lines.Length)
                        {
                            break;
                        }
                        string[] split = lines[i + counter].Split(' ');

                        if (split[0] != "$")
                        {
                            reqContent.Add(lines[i + counter]);
                        }
                        else
                        {
                            endOfContent = true;
                        }
                        counter++;
                    }

                    ListDir(i, reqContent);
                }
            }
        }

        Debug.Log("Directory Complete");
    }

    void ChangeToOrigin()
    {
        trackingObj = origin;
    }

    void ChangeDir(string dirName)
    {
        // change what object is being tracked

        if (dirName == "..")
        {
            GameObject pGO = trackingObj.transform.parent.gameObject;
            trackingObj = pGO;
        }
        else if (trackingObj.transform.Find(dirName) != null)
        {
            trackingObj = trackingObj.transform.Find(dirName).gameObject;
        }
        else
        {
            GameObject go = new GameObject(dirName);
            go.transform.parent = trackingObj.transform;
            trackingObj = go;

            Debug.Log("Creating Missing Folder: " + dirName);
        }

    }

    void ListDir(int i, List<string> reqContent)
    {
        // output the contents of the current directory
        // I can use this as a chance to fill the directory when setting it all up
        foreach(string content in reqContent)
        {

            string[] split = content.Split(' ');
            
            if (trackingObj.transform.Find(split[1]) != null)
            {
                Transform go = trackingObj.transform.Find(split[1]);

                if (split[0] == "dir")
                {
                    Debug.Log("Found Dir: " + split[1]);
                }
                else
                {
                    int scale = int.Parse(split[0]);
                    if (go.localScale.x != scale)
                    {
                        go.localScale = new Vector3(scale, scale, scale);
                    }

                    Debug.Log("Found File: " + split[1]);
                }
            }
            else
            {
                Debug.Log("Not Found: " + content);
                GameObject go = new GameObject(content);
                go.transform.parent = trackingObj.transform;
            }
        }
    }
}
