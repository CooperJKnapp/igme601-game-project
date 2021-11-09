using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichManager : MonoBehaviour
{
    public Transform initialPanel;
    public PrefabSpawner prefabSpawner;
    public StopPosition stopPosition1;
    public StopPosition stopPosition2;
    public StopPosition stopPosition3;
    public StopPosition stopPosition4;

    public Transform endPanel;

    int breadRandom;
    int meatRandom;
    
    int numVegRandom;
    int numSauceRandom;

    private Transform breadParent;
    private Transform meatParent;
    private Transform vegParent;
    private Transform sauceParent;

    private int level = 1;
    private int totalCheck;

    private int currBre = 0;
    private int currMea = 0;
    private int currVeg = 0;
    private int currSau = 0;

    int[] veggieRandom;
    int[] sauceRandom;

    Dictionary<string, int> stringInt = new Dictionary<string, int>();

    void Start()
    {
        breadParent = initialPanel.GetChild(0);
        meatParent = initialPanel.GetChild(1);
        vegParent = initialPanel.GetChild(2);
        sauceParent = initialPanel.GetChild(3);

        numVegRandom = (int)Random.Range(1, 1);
        numSauceRandom = (int)Random.Range(1, 1);

        breadRandom = (int)Random.Range(1, 4);
        meatRandom = (int)Random.Range(1, 4);

        veggieRandom = new int[numVegRandom];
        sauceRandom = new int[numSauceRandom];

        for (int i = 0; i < numVegRandom; i++)
        {
            veggieRandom[i] = (int)Random.Range(1, 7);
        }
        for (int i = 0; i < numSauceRandom; i++)
        {
            sauceRandom[i] = (int)Random.Range(1, 4);
        }

        stringInt.Add("HItalian", 1);
        stringInt.Add("Parmesan", 2);
        stringInt.Add("Italian", 3);
        stringInt.Add("MultiG", 4);

        stringInt.Add("Bacon", 1);
        stringInt.Add("Beef", 2);
        stringInt.Add("Pastrami", 3);
        stringInt.Add("Salami", 4);

        stringInt.Add("ContainerTom", 1);
        stringInt.Add("ContainerLet", 2);
        stringInt.Add("ContainerOni", 3);
        stringInt.Add("ContainerOli", 4);
        stringInt.Add("ContainerCuc", 5);
        stringInt.Add("ContainerJal", 6);
        stringInt.Add("ContainerCap", 7);

        stringInt.Add("Mayo", 1);
        stringInt.Add("Ketchup", 2);
        stringInt.Add("Mustard", 3);
        stringInt.Add("MintMayo", 4);

        totalCheck = 2 + numSauceRandom + numVegRandom;

        //////////////////bread

        Transform tempParent = initialPanel.GetChild(0);
        Transform tempAnchor = tempParent.GetChild(0);
        GameObject tempObject = prefabSpawner.GetItems(0, breadRandom);
        tempObject.transform.SetParent(tempAnchor);
        tempObject.transform.localPosition = new Vector3(0, 0, 0);

        /////////////////meat

        tempParent = initialPanel.GetChild(1);
        tempAnchor = tempParent.GetChild(0);
        tempObject = prefabSpawner.GetItems(1, meatRandom);
        tempObject.transform.SetParent(tempAnchor);
        tempObject.transform.localPosition = new Vector3(0, 0, 0);

        ////////////////veggie

        tempParent = initialPanel.GetChild(2);

        for (int j = 0; j < veggieRandom.Length; j++)
        {
            tempAnchor = tempParent.GetChild(j);
            //Debug.Log(veggieRandom[j]);
            tempObject = prefabSpawner.GetItems(2, veggieRandom[j]);
            tempObject.transform.SetParent(tempAnchor);
            tempObject.transform.localPosition = new Vector3(0, 0, 0);

        }

        /////////////////sauce

        tempParent = initialPanel.GetChild(3);

        for (int j = 0; j < sauceRandom.Length; j++)
        {
            tempAnchor = tempParent.GetChild(j);

            tempObject = prefabSpawner.GetItems(3, sauceRandom[j]);
            tempObject.transform.SetParent(tempAnchor);
            tempObject.transform.localPosition = new Vector3(0, 0, 0);

        }

        //      for (int i = 0; i < 4; i++)
        //{
        //          tempParent = initialPanel.GetChild(i);

        //	for (int j = 0; j < finalRandom[i].Length; j++)
        //	{
        //              Transform tempAnchor = tempParent.GetChild(j);

        //              prefabSpawner.GetItems(i, finalRandom[i][j]).transform.SetParent(tempAnchor);
        //	}
        //}
    }

    void Update()
    {
        
    }

    public void IsStopped()
    {
        if (level == 1 && currBre != -1)
        {
            if (stringInt[stopPosition1.stopString] == breadRandom)
            {
                currBre = -1;
                GameObject.Destroy(initialPanel.GetChild(0).GetChild(0).gameObject);
                totalCheck--;
                if (totalCheck == 0)
                    endPanel.gameObject.SetActive(true);
            }
        }
        if (level == 2 && currMea != -1)
        {
            if (stringInt[stopPosition2.stopString] == meatRandom)
            {
                currMea = -1;
                GameObject.Destroy(initialPanel.GetChild(1).GetChild(0).gameObject);
                totalCheck--;
                if (totalCheck == 0)
                    endPanel.gameObject.SetActive(true);
            }
        }
        if (level == 3 && currVeg != -1)
        {
            if (stringInt[stopPosition3.stopString] == veggieRandom[currVeg])
            {
                GameObject.Destroy(initialPanel.GetChild(2).GetChild(currVeg).gameObject);
                currVeg++;
                if ((currVeg + 1) > numVegRandom)
                    currVeg = -1;
                totalCheck--;
                if (totalCheck == 0)
                    endPanel.gameObject.SetActive(true);
            }
        }
        if (level == 4 && currSau != -1)
        {
            if (stringInt[stopPosition4.stopString] == sauceRandom[currSau])
            {
                GameObject.Destroy(initialPanel.GetChild(3).GetChild(currSau).gameObject);
                currSau++;
                if ((currSau + 1) > numSauceRandom)
                    currSau = -1;
                totalCheck--;
                if (totalCheck == 0)
                    endPanel.gameObject.SetActive(true);
            }
        }
    }

    public void SetLevel(int i)
    {
        level = i;
    }
}
