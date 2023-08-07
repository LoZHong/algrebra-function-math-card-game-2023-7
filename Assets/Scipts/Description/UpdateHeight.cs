using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHeight : MonoBehaviour
{

    public GameObject[] slides;
    public float width;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        slides = GameObject.FindGameObjectsWithTag("Slides");
        width = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        width = Screen.width;

        height = width / 4 * 2.5f;
        foreach (GameObject slide in slides)
        { 
            slide.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (width, height);
        }
    }
}
