using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Human : MonoBehaviour
{
    

    [SerializeField] float speed;
   
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
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    
}
