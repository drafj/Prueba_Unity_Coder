using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rgbd;
    [SerializeField] private UIController m_controller;
    private bool blockMovement;
    private TurnAxis m_turnAxis;
    [SerializeField] private float direction;
    public float moveSpeed,
    turnSpeed;

    void Start()
    {
    }

    private IEnumerator TorqueReseter(float oldDirection, bool positive)
    {
        if (positive)
        {
            /*while (direction <= oldDirection + 89)
            {
                yield return null;
            }*/
            yield return new WaitForSeconds(1.2f);
            Debug.Log("terminó de esperar");
        }
        else
        {
            /*while (direction >= oldDirection - 89)
            {
                yield return null;
            }*/
            yield return new WaitForSeconds(1.2f);
            Debug.Log("terminó de esperar");
        }
        blockMovement = false;
        Debug.Log("se puede volver a mover normalmente");
    }

    void Move()
    {
        /*float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 rot = new Vector3(vertical, 0, -horizontal);*/
        rgbd.maxAngularVelocity = 7;

        if (Input.GetKey(KeyCode.D) && !blockMovement)
        {
            blockMovement = true;
            rgbd.velocity = Vector3.zero;
            rgbd.angularVelocity = Vector3.zero;
            //rgbd.AddForce(Vector3.right * moveSpeed * Time.deltaTime, ForceMode.Impulse);
            rgbd.AddTorque(new Vector3(0, 0, -1) * turnSpeed * Time.deltaTime, ForceMode.VelocityChange);
            m_turnAxis = TurnAxis.Y;
            StartCoroutine(TorqueReseter(transform.eulerAngles.z, false));
            Debug.Log("lanzó el empuje");
        }
        else if (Input.GetKey(KeyCode.A) && !blockMovement)
        {
            blockMovement = true;
            rgbd.velocity = Vector3.zero;
            rgbd.angularVelocity = Vector3.zero;
            //rgbd.AddForce(Vector3.left * moveSpeed * Time.deltaTime, ForceMode.Impulse);
            rgbd.AddTorque(new Vector3(0, 0, 1) * turnSpeed * Time.deltaTime, ForceMode.VelocityChange);
            m_turnAxis = TurnAxis.Y;
            StartCoroutine(TorqueReseter(transform.eulerAngles.z, true));
            Debug.Log("lanzó el empuje");
        }
        else if (Input.GetKey(KeyCode.W) && !blockMovement)
        {
            blockMovement = true;
            rgbd.velocity = Vector3.zero;
            rgbd.angularVelocity = Vector3.zero;
            //rgbd.AddForce(Vector3.forward * moveSpeed * Time.deltaTime, ForceMode.Impulse);
            rgbd.AddTorque(new Vector3(1, 0, 0) * turnSpeed * Time.deltaTime, ForceMode.VelocityChange);
            m_turnAxis = TurnAxis.X;
            StartCoroutine(TorqueReseter(transform.eulerAngles.x, true));
            Debug.Log("lanzó el empuje");
        }
        else if (Input.GetKey(KeyCode.S) && !blockMovement)
        {
            blockMovement = true;
            rgbd.velocity = Vector3.zero;
            rgbd.angularVelocity = Vector3.zero;
            //rgbd.AddForce(Vector3.back * moveSpeed * Time.deltaTime, ForceMode.Impulse);
            rgbd.AddTorque(new Vector3(-1, 0, 0) * turnSpeed * Time.deltaTime, ForceMode.VelocityChange);
            m_turnAxis = TurnAxis.X;
            StartCoroutine(TorqueReseter(transform.eulerAngles.x, false));
            Debug.Log("lanzó el empuje");
        }

        if (m_turnAxis == TurnAxis.X)
        {
            direction = transform.eulerAngles.x;
        }
        else if (m_turnAxis == TurnAxis.Y)
        {
            direction = transform.eulerAngles.z;
        }
    }

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
            //Move();
            SimpleMove();
        }
    }
}

public enum TurnAxis { X, Y }