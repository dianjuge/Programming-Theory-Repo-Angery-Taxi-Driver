using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    [SerializeField] float speed;
    private float zTopBound = 29;
    private float zLowerBound = -3;
    private float xRange = 18.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * horizontalInput);
        transform.Translate(Vector3.forward * speed * verticalInput);

        if (transform.position.z > zTopBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTopBound);
        }
        if (transform.position.z < zLowerBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLowerBound);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
