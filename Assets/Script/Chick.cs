using System.Collections;
using UnityEngine;

public class Chick : MonoBehaviour
{
    private GameController gameController;
    private Rigidbody rb;
    private float moveSpeed = 1f;
    private Vector3 movement;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * moveSpeed, ForceMode.VelocityChange);
    }
}
