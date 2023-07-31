using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class FormulaData
{
    public int steak;
    public string[] formulars;
}


public class JsonReader : MonoBehaviour
{

    public TextAsset JsonFile;
    public string JsonString;
    public FormulaData Formulars;
    private string filePath;

    public bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "formula.json");
        isPathExists();
    }

    public void isPathExists()
    {
        if (File.Exists(filePath)) { GeneratingFormulars(); }
        else { GeneratePath(); }
    }

    public void GeneratingFormulars()
    {

        JsonString = File.ReadAllText(filePath);
        Formulars = JsonUtility.FromJson<FormulaData>(JsonString);
        isDone = true;
    }

    public void GeneratePath()
    {
        FileStream fileStream = File.Create(filePath);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(JsonFile.text);
        }
        GeneratingFormulars();
    }

    public void updateJson()
    {
        File.WriteAllText(filePath, JsonUtility.ToJson(Formulars));
    }

}
