using System.Collections;
using UnityEngine;

public class Rooster : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed = 1f;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DieAfterTime());
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * moveSpeed, ForceMode.VelocityChange);
    }

    IEnumerator DieAfterTime()
    {
        yield return new WaitForSeconds(40f);
        Destroy(gameObject);
    }
}
