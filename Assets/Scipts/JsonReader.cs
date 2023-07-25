using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class FormulaData
{
    public string[] formulars;
}


public class JsonReader : MonoBehaviour
{

    public TextAsset JsonFile;
    public FormulaData Formulars;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void GeneratingFormulars()
    {
        print(JsonFile.text);
        Formulars = JsonUtility.FromJson<FormulaData>(JsonFile.text);
        UnityEngine.Debug.Log("hereasdasd" + Formulars.formulars.Length) ;
    }

}
