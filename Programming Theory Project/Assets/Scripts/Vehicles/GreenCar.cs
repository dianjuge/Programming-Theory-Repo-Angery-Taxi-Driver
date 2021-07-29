using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCar : Vehicle     //INHERITANCE
{
    private float greenCarDamagePoint = -3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }
    public override void DealDamage()   //POLYMORPHYSIM
    {
        if (!isDamaged)
        {
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            playerController.Health = greenCarDamagePoint;
            isDamaged = true;
        }
    }
}
