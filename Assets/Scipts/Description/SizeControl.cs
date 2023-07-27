using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeControl : MonoBehaviour
{
    public GameObject Content;
    public int Cards;
    public float CardsHeight;

    // Update is called once per frame
    void Update()
    {
        Cards = Content.transform.childCount;

        CardsHeight = Content.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta[1];
        Content.GetComponent<RectTransform>().sizeDelta = new Vector2(Content.GetComponent<RectTransform>().sizeDelta[0] , CardsHeight * Cards);

        //UnityEngine.Debug.Log(CardsHeight);
        //UnityEngine.Debug.Log(CardsHeight * Cards);
        //UnityEngine.Debug.Log(Content.GetComponent<RectTransform>().sizeDelta);
    }
}
