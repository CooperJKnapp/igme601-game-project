using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SandwichManager : MonoBehaviour
{
    public Transform initialPanel;
    public Transform showcasePanel;
    public PrefabSpawner prefabSpawner;
    public StopPosition stopPosition1;
    public StopPosition stopPosition2;
    public StopPosition stopPosition3;
    public StopPosition stopPosition4;

    public Transform endPanel;
    public TimerSub timerSub;

    int breadRandom;
    int meatRandom;
    int[] veggieRandom;
    int[] sauceRandom;

    int numVegRandom;
    int numSauceRandom;

    private Transform breadParent;
    private Transform meatParent;
    private Transform vegParent;
    private Transform sauceParent;

    private int section = 1;               //selected section
    private int totalCheck;
    private Color32 colorBread;

    // Current objective (-1) on each level 
    private int currBread = 0; 
    private int currMeat = 0;
    private int currVeggie = 0;
    private int currSauce = 0;

    bool foundObjectives = false;                                           //Ensuring unique objectives in Veggie and Sauce

    Dictionary<string, int> stringInt = new Dictionary<string, int>();      //convert objective string to number
    Dictionary<int, bool> intBoolVeggie = new Dictionary<int, bool>();            //convert selected veggie ints to bool
    Dictionary<int, bool> intBoolSauce = new Dictionary<int, bool>();            //convert selected sauce ints to bool

    void Start()
    {
        //Dictionary build with strings to int conversion

        stringInt.Add("", -1);

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


        //Dictionary build with int to selecetd bool conversion
        intBoolVeggie.Add(1, false);
        intBoolVeggie.Add(2, false);
        intBoolVeggie.Add(3, false);
        intBoolVeggie.Add(4, false);
        intBoolVeggie.Add(5, false);
        intBoolVeggie.Add(6, false);
        intBoolVeggie.Add(7, false);

        intBoolSauce.Add(1, false);
        intBoolSauce.Add(2, false);
        intBoolSauce.Add(3, false);
        intBoolSauce.Add(4, false);

        breadParent = initialPanel.GetChild(0);
        meatParent = initialPanel.GetChild(1);
        vegParent = initialPanel.GetChild(2);
        sauceParent = initialPanel.GetChild(3);

        numVegRandom = (int)Random.Range(1, 4);             //No. of veg objectives
        numSauceRandom = (int)Random.Range(1, 3);           //No. of sauce objectives

        breadRandom = (int)Random.Range(1, 4);
        meatRandom = (int)Random.Range(1, 4);

        veggieRandom = new int[numVegRandom];
        sauceRandom = new int[numSauceRandom];

        for (int i = 0; i < numVegRandom; i++)
        {
            foundObjectives = false;

            while (!foundObjectives)
            {
                veggieRandom[i] = (int)Random.Range(1, 7);

                if (intBoolVeggie[veggieRandom[i]] == false)
                {
                    foundObjectives = true;
                    intBoolVeggie[veggieRandom[i]] = true;
                }
            }

            //Debug.Log(numVegRandom + " " + veggieRandom[i]);
        }


        for (int i = 0; i < numSauceRandom; i++)
        {
            foundObjectives = false;

            while (!foundObjectives)
            {
                sauceRandom[i] = (int)Random.Range(1, 4);

                if (intBoolSauce[sauceRandom[i]] == false)
                {
                    foundObjectives = true;
                    intBoolSauce[sauceRandom[i]] = true;
                }
            }

            //Debug.Log(numSauceRandom + " " + sauceRandom[i]);
        }

        totalCheck = 2 + numSauceRandom + numVegRandom;            //total objectives

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

        for (int j = 0; j < numVegRandom; j++)
        {
            tempAnchor = tempParent.GetChild(j);
            //Debug.Log(veggieRandom[j]);
            tempObject = prefabSpawner.GetItems(2, veggieRandom[j]);
            tempObject.transform.SetParent(tempAnchor);
            tempObject.transform.localPosition = new Vector3(0, 0, 0);

        }

        /////////////////sauce

        tempParent = initialPanel.GetChild(3);

        for (int j = 0; j < numSauceRandom; j++)
        {
            tempAnchor = tempParent.GetChild(j);

            tempObject = prefabSpawner.GetItems(3, sauceRandom[j]);
            tempObject.transform.SetParent(tempAnchor);
            tempObject.transform.localPosition = new Vector3(0, 0, 0);

        }
    }

    public void IsStopped()
    {
        if (section == 1 && currBread != -1)
        {
            if (stringInt[stopPosition1.stopString] == breadRandom)
            {
                currBread = -1;
                initialPanel.GetChild(0).GetChild(0).gameObject.SetActive(false);                       //Remove from objective

                //Showcase Panel

                if (breadRandom == 1)                                           //bread color change when selected
                    colorBread = Color.white;
                else if (breadRandom == 2)
                    colorBread = new Color32(255, 247, 213, 255);
                else if (breadRandom == 3)
                    colorBread = new Color32(255, 234, 213, 255);
                else if (breadRandom == 4)
                    colorBread = new Color32(241, 225, 199, 255);

                showcasePanel.GetChild(0).gameObject.GetComponent<Image>().color = colorBread;

                totalCheck--;
                if (totalCheck == 0)
                    SuccessState();
            }
        }
        if (section == 2 && currMeat != -1)
        {
            if (stringInt[stopPosition2.stopString] == meatRandom)
            {
                currMeat = -1;
                initialPanel.GetChild(1).GetChild(0).gameObject.SetActive(false);

                //Showcase Panel

                Transform tempParent = showcasePanel.GetChild(1);

                for (int i = 0; i < 4; i++)
                {
                    Transform tempAnchor = tempParent.GetChild(i);
                    GameObject tempObject = prefabSpawner.GetItems(1, meatRandom);
                    tempObject.transform.SetParent(tempAnchor);
                    tempObject.transform.localPosition = new Vector3(0, 0, 0);
                }

                totalCheck--;
                if (totalCheck == 0)
                    SuccessState();
            }
        }
        if (section == 3 && currVeggie != -1)
        {
            if (stringInt[stopPosition3.stopString] == veggieRandom[currVeggie])
            {
                initialPanel.GetChild(2).GetChild(currVeggie).gameObject.SetActive(false);
                currVeggie++;

				//Showcase Panel

				Transform tempParent = showcasePanel.GetChild(2).GetChild(veggieRandom[currVeggie-1] - 1);

				for (int i = 0; i < tempParent.childCount; i++)
				{
					Transform tempAnchor = tempParent.GetChild(i);
					GameObject tempObject = prefabSpawner.GetItems(2, veggieRandom[currVeggie - 1]);
					tempObject.transform.SetParent(tempAnchor);
					tempObject.transform.localPosition = new Vector3(0, 0, 0);
				}

				if ((currVeggie + 1) > numVegRandom)
                    currVeggie = -1;

                totalCheck--;
                if (totalCheck == 0)
                    SuccessState();
            }
        }
        if (section == 4 && currSauce != -1)
        {
            if (stringInt[stopPosition4.stopString] == sauceRandom[currSauce])
            {
                initialPanel.GetChild(3).GetChild(currSauce).gameObject.SetActive(false);
                currSauce++;

                //Showcase Panel

                Transform tempParent = showcasePanel.GetChild(3).GetChild(currSauce - 1);

                for (int i = 0; i < 4; i++)
                {
                    Transform tempAnchor = tempParent.GetChild(i);
                    GameObject tempObject = prefabSpawner.GetItems(4, sauceRandom[currSauce - 1]);
                    tempObject.transform.SetParent(tempAnchor);
                    tempObject.transform.localPosition = new Vector3(0, 0, 0);
                }

                if ((currSauce + 1) > numSauceRandom)
                    currSauce = -1;

                totalCheck--;
                if (totalCheck == 0)
                    SuccessState();

            }
        }
    }

    private void SuccessState()
    {
        endPanel.gameObject.SetActive(true);
        timerSub.StopTime();
    }

    public void SetLevel(int i)
    {
        section = i;
    }

    public int GetLevel()
    {
        return section;
    }
}
