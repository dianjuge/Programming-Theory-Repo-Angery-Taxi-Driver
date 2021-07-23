using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem explosionPacticle;
    public AudioClip explosionSound;
    public GameObject mainCamera;
    private float verticalInput;
    private float horizontalInput;
    [SerializeField] float speed;
    private float zTopBound = 29;
    private float zLowerBound = -2.5f;
    private float xRange = 18.5f;
    private float yBound = 0;

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
        if (transform.position.y < yBound)
        {
            transform.position = new Vector3(transform.position.x, yBound, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Vehicle>())
        {
            explosionPacticle.transform.position = collision.gameObject.transform.position;
            explosionPacticle.Play();
            AudioSource.PlayClipAtPoint(explosionSound, mainCamera.transform.position);
            Destroy(collision.gameObject, 0.1f);
        }
    }
}
