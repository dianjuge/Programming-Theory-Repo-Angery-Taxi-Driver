using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private Rigidbody vehicleRb;
    private PlayerController playerController;
    [SerializeField] float speed;
    private float damagePoint = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    protected virtual void MoveForward()
    {
        vehicleRb = gameObject.GetComponent<Rigidbody>();
        vehicleRb.AddForce(Vector3.back * speed);
    }

    public virtual void DealDamage()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerController.Health = damagePoint;
    }
}
