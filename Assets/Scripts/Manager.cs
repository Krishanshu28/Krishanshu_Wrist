using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject choppedLocation;
    public GameObject nextItemLocation;
    public GameObject[] items;
    int i = 0;
    int j = 0;
    public void OnPressedChop()
    {
        if(i < items.Length)
        {
            items[i].transform.position = new Vector3(choppedLocation.transform.position.x, choppedLocation.transform.position.y, choppedLocation.transform.position.z);
            i++;
        }
        
    }
    public void OnPressedNext()
    {
        if(j < items.Length)
        {
            print(j);
            items[j].transform.position = new Vector3(nextItemLocation.transform.position.x, nextItemLocation.transform.position.y, nextItemLocation.transform.position.z);
            j++;
        }
    }
}
