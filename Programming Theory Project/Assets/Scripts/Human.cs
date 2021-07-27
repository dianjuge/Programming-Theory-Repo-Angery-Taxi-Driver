using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Human : MonoBehaviour
{
    private GroundRepeat groundRepeat;
    private PlayerController playerController;

    [SerializeField] float speed;
   
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }
    protected virtual void MoveForward()
    {
        if (!playerController.IsGameOver)
        {
            transform.Translate(Vector3.forward * (speed + GroundRepeat.groundSpeed) * Time.deltaTime);
        }
    }

    
}
