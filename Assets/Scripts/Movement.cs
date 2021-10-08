using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rgbd;
    [SerializeField] private UIController m_controller;
    public float turnSpeed;

    private void SimpleMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 rot = new Vector3(vertical, 0, -horizontal);

        rgbd.maxAngularVelocity = 3;
        rgbd.AddTorque(rot * turnSpeed * Time.deltaTime, ForceMode.Force);
    }

    void Update()
    {
        if (!m_controller.gameOver)
        {
            SimpleMove();
        }
    }
}

public enum TurnAxis { X, Y }