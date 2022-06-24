using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetController : MonoBehaviour
{
    // Input keys
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    // Set speed
    private int speed = 4;

    // Rigidbody
    private Rigidbody rb;

    // Read Input
    private Vector3 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector3.forward * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector3.back * speed;
        }
        else if (Input.GetKey(leftKey))
        {
            return Vector3.left * speed;
        }
        else if (Input.GetKey(rightKey))
        {
            return Vector3.right * speed;
        }
        else
        {
            return Vector3.zero;
        }
    }

    // Appy input to rigidbody 
    private void MoveObject(Vector3 movement)
    {
        rb.velocity = movement;
        Debug.Log("TEST: " + movement);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moving the bet
        MoveObject(GetInput());
    }
}
