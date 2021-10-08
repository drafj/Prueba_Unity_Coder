using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI 
        timeText,
        pointsText,
        finalText;
    [SerializeField] private GameObject endGame;
    private float time = 30;
    private int 
        points,
        record;
    public bool gameOver;
    private RecordStruct recordStruct;
    private string path = "/Data/record/";
    private string fileName = "Record";

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Finish()
    {
        gameOver = true;
        LoadData();
        if (points > record)
            record = points;
        SaveData();
        finalText.text = $"juego terminado \npuntaje alcanzado: {points} \npuntaje maximo: {record}";
        endGame.SetActive(true);
    }
    private void SaveData()
    {
        if (points >= record || record == 0)
        {
            string fullPath = Application.persistentDataPath + path;
            bool checkFolderExist = Directory.Exists(fullPath);
            if (!checkFolderExist)
            {
                Directory.CreateDirectory(fullPath);
            }
            recordStruct.record = points;
            string json = JsonUtility.ToJson(recordStruct);
            File.WriteAllText(fullPath + fileName + ".json", json);
            //Debug.Log($"guardado correctamene {fullPath}");
        }
        //else
            //Debug.Log("no se a superado el record maximo");
    }

    private void LoadData()
    {
        string fullPath = Application.persistentDataPath + path + fileName + ".json";
        if (File.Exists(fullPath))
        {
            string textJson = File.ReadAllText(fullPath);
            recordStruct = JsonUtility.FromJson<RecordStruct>(textJson);
            record = recordStruct.record;
            //Debug.Log("record leido exitosamente");
        }
        else
        {
            //Debug.Log("no existe el primer record");
        }
    }

    public void AddCookie()
    {
        points++;
        pointsText.text = $"galletas recogidas: {points}";
    }

    void Update()
    {
        if (time > 0 && !gameOver)
        {
            time -= Time.deltaTime;
            timeText.text = $"tiempo restante: {time.ToString("F0")}";
            if (time <= 0)
            {
                gameOver = true;
                Finish();
            }
        }

    }
}

public struct RecordStruct
{
    public int record;
}