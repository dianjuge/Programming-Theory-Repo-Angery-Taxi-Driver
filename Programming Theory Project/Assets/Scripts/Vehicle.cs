using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private GroundRepeat groundRepeat;
    private Rigidbody vehicleRb;
    protected PlayerController playerController;
    [SerializeField] float speed;
    protected float damagePoint = -2.0f;
    protected bool isDamaged;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    protected virtual void MoveForward()    //ABSTRACTION
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        groundRepeat = GameObject.Find("Ground").GetComponent<GroundRepeat>();
        if (!playerController.IsGameOver)
        {
            vehicleRb = gameObject.GetComponent<Rigidbody>();
            vehicleRb.AddForce(Vector3.back * (speed + groundRepeat.GroundSpeed));
        }
    }

    public virtual void DealDamage()
    {
        if (!isDamaged)
        {
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            playerController.Health = damagePoint;
            isDamaged = true;
        }    
    }
}
