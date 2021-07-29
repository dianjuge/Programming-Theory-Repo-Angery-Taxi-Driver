using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCar : Vehicle  //INHERITANCE
{
    private float blueCarDamagePoint = -2.0f;
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
            playerController.Health = blueCarDamagePoint;
            isDamaged = true;
        }
    }
}
