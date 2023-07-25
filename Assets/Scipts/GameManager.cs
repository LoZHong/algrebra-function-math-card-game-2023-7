using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Diagnostics;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    [Header("PlayerCard")]
    public TMP_Text PlayerCard;
    public RollingDice RDScript;
    public int PlayerNum;

    [Header("Card Display")]
    public GameObject DisplayList;
    public GameObject CardPre;

    [Header("Formula Generate")]
    public int FormulaNum = 5;
    public JsonReader Json;
    public string[] FormulaArray;
    public string[] FmlGenerated;

    public FormulaDecoder FDecoder;

    public RollingDice RlDice;
    public bool Dice1Stop = false;
    public bool Dice2Stop = false;
    public bool allDiceStop = false;

    [Header("Formula Generate")]
    public TMP_Text EnemyCard;
    public int EnemyNum;

    public PausingGame PsGame;
    public GameObject WinSc;
    public GameObject LosSc;

    private bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        Json.GeneratingFormulars();
        FormulaArray = Json.Formulars.formulars;
        FmlGenerated = new string[3];
        UnityEngine.Debug.Log("here");

    }

    // Update is called once per frame
    void Update()
    {
        Dice1Stop = RlDice.isStationary1;
        Dice2Stop = RlDice.isStationary2;

        if (done != true)
        {
            UpdatePlayerCard();
        }

        if (PlayerNum == EnemyNum && allDiceStop == true)
        {
            WinSc.SetActive(true);
            done = true;
        }
        else if (PlayerNum > EnemyNum && allDiceStop == true)
        {
            LosSc.SetActive(true);
            done = true;
        }

    }

    void UpdatePlayerCard()
    {
        if (Dice1Stop == true && Dice2Stop == true && allDiceStop == false)
        {
            InstantiateCards();
            PlayerNum = RDScript.DiceRe1 + RDScript.DiceRe2;
            allDiceStop = true;
            int randomiz = UnityEngine.Random.Range(0, FmlGenerated.Length);
            EnemyNum = FDecoder.FormularsDecoder(FmlGenerated[randomiz], PlayerNum);
        }
        PlayerCard.text = PlayerNum.ToString();
        EnemyCard.text = EnemyNum.ToString();
    }

    public void CardsOnClick()
    {
        GameObject cardPress = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        string name = cardPress.transform.parent.gameObject.name;
        print(name);
        PlayerNum = FDecoder.FormularsDecoder(name, PlayerNum);
        Destroy(cardPress.gameObject.transform.parent.gameObject);

        LayoutRebuilder.ForceRebuildLayoutImmediate(DisplayList.gameObject.GetComponent<RectTransform>());
    }

    public void InstantiateCards()
    {
        for (var i = 0; i < 3; i++)
        {
            int randomize = UnityEngine.Random.Range(0, FormulaArray.Length);
            string fml = FormulaArray[randomize];
            GameObject Card = Instantiate(CardPre) as GameObject;
            Card.name = fml;
            Card.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(CardsOnClick);
            Card.transform.SetParent(DisplayList.gameObject.transform, false);
            Card.transform.GetChild(0).GetChild(1).gameObject.GetComponent<TMP_Text>().text = fml;
            FmlGenerated[i] = fml;
        }
    }

}