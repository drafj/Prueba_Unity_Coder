using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour
{
    [SerializeField] private UIController m_uiController;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Movement>() != null)
        {
            m_uiController.Finish();
        }
    }
}
