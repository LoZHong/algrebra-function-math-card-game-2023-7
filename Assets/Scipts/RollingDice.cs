using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class RollingDice : MonoBehaviour
{
    public TMP_Text txt;

    public GameObject Dice;

    public GameObject[] InDice;

    public bool isStationary1 = false;
    public bool isStationary2 = false;

    public int DiceRe1;
    public int DiceRe2;
    public int DiceRe;

    // Start is called before the first frame update
    void Start()
    {
        instantiateDice();
    }

    // Update is called once per frame
    void Update()
    {
        //txt.text = "Dice1=" + DiceRe1.ToString() + "Dice2=" + DiceRe2.ToString();
        DetectStationary();
        // if (Input.GetButtonDown("Jump"))
        // {
        //
        //     instantiateDice();
        //
        // }
    }

    public void instantiateDice()
    {
        DiceRe1 = 0;
        DiceRe2 = 0;
        isStationary1 = false;
        isStationary2 = false;

        foreach (GameObject dice in InDice)
        {
            Destroy(dice);
        }

        InDice = Array.Empty<GameObject>();

        //Code for instantiate dice
        for (var i = 0; i <= 1; i++)
        {
            Instantiate(Dice, new Vector3(i * 5.0f, 30, 0), new Quaternion(UnityEngine.Random.Range(-360, 360), UnityEngine.Random.Range(-360, 360), UnityEngine.Random.Range(-360, 360), UnityEngine.Random.Range(-360, 360)));
        }
        print("adasdasda" + InDice.Length);
        //Assign all the instantiate dice to a array

        InDice = GameObject.FindGameObjectsWithTag("Dice").ToArray();

        int x = InDice.Length;

        //Give the dice some velocity for further used in detecting whether is stationory
        for (var i = 0; i < x; i++)
        {
            InDice[i].GetComponent<Rigidbody>().velocity = new Vector3(0.1f, 0.1f, 0.1f);
            print(i);
        }
    }

    //code to detect whether the dice is stationary or not
    public void DetectStationary()
    {
        InDice = Array.FindAll(InDice, i => i != null);
        int x = InDice.Length;
        for (var i = 0; i < x; i++)
        {
            if (i == 0 && isStationary1 == false)
            {
                if (InDice[i].GetComponent<Rigidbody>().velocity == Vector3.zero)
                {
                    print("Stationary!!" + i);
                    NumDetection(InDice[i]);
                    isStationary1 = true;
                    DiceRe1 = DiceRe;
                    print(isStationary1.ToString() + isStationary2.ToString());
                }
            }
            else if (i == 1 && isStationary2 == false)
            {
                if (InDice[i].GetComponent<Rigidbody>().velocity == Vector3.zero)
                {
                    print("Stationary!!" + i);
                    NumDetection(InDice[i]);
                    isStationary2 = true;
                    DiceRe2 = DiceRe;
                    print(isStationary1.ToString() + isStationary2.ToString());
                }
            }
            //else if (isStationary1 == true && isStationary2 == true) { yield return null; }
        }
    }
    

    public void NumDetection(GameObject Dice)
    {
        DiceRe = 0;

        bool num1 = Dice.transform.GetChild(0).gameObject.GetComponent<DetectingNum>().isTriggered;
        bool num2 = Dice.transform.GetChild(1).gameObject.GetComponent<DetectingNum>().isTriggered;
        bool num3 = Dice.transform.GetChild(2).gameObject.GetComponent<DetectingNum>().isTriggered;
        bool num4 = Dice.transform.GetChild(3).gameObject.GetComponent<DetectingNum>().isTriggered;
        bool num5 = Dice.transform.GetChild(4).gameObject.GetComponent<DetectingNum>().isTriggered;
        bool num6 = Dice.transform.GetChild(5).gameObject.GetComponent<DetectingNum>().isTriggered;

        if (num1 == true) { DiceRe = 6; }
        else if (num2 == true) { DiceRe = 5; }
        else if (num3 == true) { DiceRe = 4; }
        else if (num4 == true) { DiceRe = 3; }
        else if (num5 == true) { DiceRe = 2; }
        else if (num6 == true) { DiceRe = 1; }
    }
}
