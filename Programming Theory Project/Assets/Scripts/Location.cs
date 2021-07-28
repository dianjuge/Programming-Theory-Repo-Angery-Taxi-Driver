using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    private int passengerID;
    private float rotateSpeed = 200;
    public int PassengerID { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    public void GetPassengerID(int i)
    {
        PassengerID = i;
    }
    protected void Rotation()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
