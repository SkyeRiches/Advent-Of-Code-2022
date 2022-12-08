using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Directory_Search : MonoBehaviour
{
    string path = Application.dataPath + "/directory-setup.txt";
    string[] lines;

    public Transform origin;

    private Transform trackingObj;

    List<Transform> lessThanTarget = new List<Transform>();
    List<Transform> dirs = new List<Transform>();
    List<Transform> deleteCandidate = new List<Transform>();

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
                origin.GetChild(i).GetComponent<NodeValue>().value += HierarchyDive(origin.GetChild(i));
                total += origin.GetChild(i).GetComponent<NodeValue>().value;

                if (origin.GetChild(i).GetComponent<NodeValue>().value <= 100000)
                {
                    lessThanTarget.Add(origin.GetChild(i));
                }

                dirs.Add(origin.GetChild(i));
            }
        }

        if (total <= 100000)
        {
            lessThanTarget.Add(origin);
        }

        int answer = 0;

        for (int i = 0; i < lessThanTarget.Count; i++)
        {
            answer += lessThanTarget[i].GetComponent<NodeValue>().value;
        }

        int freeSpace = 70000000 - total;
        int spaceNeeded = 30000000 - freeSpace;

        Debug.Log("SpaceNeeded = " + spaceNeeded);

        for (int i = 0; i < dirs.Count; i++)
        {
            if (dirs[i].GetComponent<NodeValue>().value >= spaceNeeded)
            {
                deleteCandidate.Add(dirs[i]);
            }
        }

        int[] delValues = new int[deleteCandidate.Count];

        for (int i = 0; i < delValues.Length; i++)
        {
            delValues[i] = deleteCandidate[i].GetComponent<NodeValue>().value;
        }

        Array.Sort(delValues);

        Debug.Log("Smallest file that can free up space: " + delValues[0]);
    }

    int HierarchyDive(Transform child)
    {
        int x = 0;

        for (int i = 0; i < child.childCount; i++)
        {
            if (child.GetChild(i).childCount > 0)
            {
                child.GetChild(i).GetComponent<NodeValue>().value += HierarchyDive(child.GetChild(i));
                x += child.GetChild(i).GetComponent<NodeValue>().value;

                if (child.GetChild(i).GetComponent<NodeValue>().value <= 100000)
                {
                    lessThanTarget.Add(child.GetChild(i));
                }

                dirs.Add(child.GetChild(i));
            }
            else if (child.GetChild(i).childCount == 0)
            {
                x += child.GetChild(i).GetComponent<NodeValue>().value;
            }
        }
        return x;
    }
}
