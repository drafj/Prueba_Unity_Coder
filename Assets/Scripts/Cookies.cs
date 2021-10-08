using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookies : MonoBehaviour
{
    private GridFloor floor;
    private UIController m_uiController;
    void Start()
    {
        floor = FindObjectOfType<GridFloor>();
        m_uiController = FindObjectOfType<UIController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Movement>() != null && !m_uiController.gameOver)
        {
            bool exit = false;
            while (!exit)
            {
                int emergencyCounter = 0;
                emergencyCounter++;
                if (emergencyCounter > 10)
                {
                    Debug.Log("tuve que salir");
                    exit = true;
                }
                int randPosition = Random.Range(0, 380);
                foreach (var item in floor.cookiePositions)
                {
                    if (randPosition != item)
                    {
                        exit = true;
                    }
                    else
                    {
                        exit = false;
                        break;
                    }
                }
                transform.position = new Vector3(floor.floorCubes[randPosition].transform.position.x, 2, floor.floorCubes[randPosition].transform.position.z);
            }
            m_uiController.AddCookie();
            other.gameObject.GetComponent<SaySomething>().Talk();
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up * 35 * Time.deltaTime);
    }
}
