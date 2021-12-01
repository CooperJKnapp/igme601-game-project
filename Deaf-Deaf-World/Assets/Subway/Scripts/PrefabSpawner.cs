using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject[] breadArray;
    public GameObject[] meatArray;
    public GameObject[] vegArray;
    public GameObject[] sauceArray;
    public GameObject[] sauceLineArray;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public GameObject GetItems(int m, int n)
    {
        if (m == 0)
        {
            GameObject obj = GameObject.Instantiate(breadArray[n - 1]);
            obj.transform.localScale = new Vector3(1, 1, 1);
            return obj;
        }
        else if (m == 1)
        {
            GameObject obj = GameObject.Instantiate(meatArray[n - 1]);
            obj.transform.localScale = new Vector3(1, 1, 1);
            return obj;
        }
        else if (m == 2)
        {
            GameObject obj = GameObject.Instantiate(vegArray[n - 1]);
            //obj.transform.localScale = new Vector3(1, 1, 1);
            return obj;
        }
        else if (m == 3)
        {
            GameObject obj = GameObject.Instantiate(sauceArray[n - 1]);
            obj.transform.localScale = new Vector3(1, 1, 1);
            return obj;
        }
        else
        {
            GameObject obj = GameObject.Instantiate(sauceLineArray[n - 1]);
            obj.transform.localScale = new Vector3(1, 1, 1);
            return obj;
        }
    }
}
