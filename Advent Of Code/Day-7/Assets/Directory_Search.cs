using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directory_Search : MonoBehaviour
{
    string path = Application.dataPath + "/directory-setup.txt";
    string[] lines;

    public Transform origin;

    private Transform trackingObj;

    List<float> lessThanTarget = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        int total = 0;

        for (int i = 0; i < origin.childCount; i++)
        {
            if (origin.GetChild(i).childCount == 0)
            {
                total += origin.GetChild(i).GetComponent<NodeValue>().value;
            }
            else
            {
                total += HierarchyDive(origin.GetChild(i));
            }
        }

        Debug.Log("Calculated file sizes through recursion: " + total);
    }

    int HierarchyDive(Transform child)
    {
        int x = 0;

        for (int i = 0; i < child.childCount; i++)
        {
            if (child.GetChild(i).childCount > 0)
            {
                x += HierarchyDive(child.GetChild(i));
            }
            else if (child.GetChild(i).childCount == 0)
            {
                x += child.GetComponent<NodeValue>().value;
            }
        }

        if (x <= 100000)
        {
            Debug.Log(x);
            lessThanTarget.Add(x);
        }
        return x;
    }
}
