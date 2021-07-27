using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private PlayerController playerController;
    private float healthRegainPoint = 2;

    float rotateSpeed = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    public virtual void HealthRegain()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerController.Health = healthRegainPoint;
    }

    protected void Rotation()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
