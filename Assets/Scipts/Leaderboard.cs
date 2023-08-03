using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LeaderBoard
{
    public string[] Players;
}

public class Leaderboard : MonoBehaviour
{
    public JsonReader Json;

    public TextAsset LeaderBoard;
    public string jsonLeaderBoard;
    public LeaderBoard LeaderBoards;
    private string filePath;

    public bool isDone = false;

    private void Start()
    {
        filePath = filePath = Path.Combine(Application.persistentDataPath, "LeaderBoard.json");
        isPathExists(filePath);
    }

    public void isPathExists(string FilePath)
    {
        if (File.Exists(FilePath)) { GenerateLeaderBoard(); }
        else { GeneratePath(); }
    }

    public void GeneratePath()
    {
        FileStream fileStream = File.Create(filePath);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(LeaderBoard.text);
        }
        GenerateLeaderBoard();
    }

    public void GenerateLeaderBoard()
    {
        jsonLeaderBoard = File.ReadAllText(filePath);
        LeaderBoards = JsonUtility.FromJson<LeaderBoard>(jsonLeaderBoard);
        isDone = true;
    }

    public void Update()
    {
        File.WriteAllText(filePath, JsonUtility.ToJson(jsonLeaderBoard));
    }

}
