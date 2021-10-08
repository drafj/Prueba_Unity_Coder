using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridFloor : MonoBehaviour
{
    public int huecos;
    [SerializeField] private int
        sizeX,
        sizeY;
    [SerializeField] private GameObject 
        floorChunk,
        coockiePref;
    public List<GameObject> floorCubes = new List<GameObject>();
    public List<int> cookiePositions = new List<int>();
    private void Awake()
    {
        sizeX = sizeX == 0 ? 20 : sizeX;
        sizeY = sizeY == 0 ? 20 : sizeY;
    }

    void Start()
    {
        CreateGrid();
        SpawnCookies();
        //Invoke("ReloadScene", 2.5f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    void CreateGrid()
    {
        Vector3 pos = new Vector3(-19f, 0, 19f);

        for (int i = 0; i < sizeY; i++)
        {
            int counter = Random.Range(0, 20);
            if (i == 9)
            {
                while (counter == 9)
                {
                    counter = Random.Range(0, 20);
                }
            }
            for (int j = 0; j < sizeX; j++)
            {
                //int rand = Random.Range(1, 3);
                if (counter == j)
                {
                    huecos++;
                }
                else
                {
                    GameObject go = Instantiate(floorChunk, pos, Quaternion.identity);
                    if (i == 9 && j == 9)
                        go.name = "InitialPlatform";
                    floorCubes.Add(go);
                }
                pos += new Vector3(2f, 0, 0);
            }
            pos += new Vector3(-40f, 0, -2f);
        }
    }

    private void SpawnCookies()
    {
        for (int i = 0; i < 30; i++)
        {
            int randPosition = Random.Range(0, 380);
            if (i > 0)
            {
                bool exit = false;
                int emergencyCounter = 0;
                while (!exit)
                {
                    emergencyCounter++;
                    if (emergencyCounter > 10)
                    {
                        Debug.Log("tuve que salir");
                        exit = true;
                    }
                    foreach (var item in cookiePositions)
                    {
                        if (floorCubes[randPosition].name == "InitialPlatform")
                        {
                            randPosition = Random.Range(0, 380);
                            exit = false;
                            break;
                        }
                        if (randPosition != item)
                        {
                            exit = true;
                        }
                        else if (randPosition == item)
                        {
                            randPosition = Random.Range(0, 380);
                            exit = false;
                            break;
                        }
                    }
                }
            }
            cookiePositions.Add(randPosition);
            Vector3 tempPos = new Vector3(floorCubes[randPosition].transform.position.x, 2, floorCubes[randPosition].transform.position.z);
            GameObject coockieTemp = Instantiate(coockiePref, tempPos, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
