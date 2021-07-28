using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeat : MonoBehaviour
{
    public float GroundSpeed { get; set; }

    private PlayerController playerController;
    Vector3 originPoz;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        originPoz = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        GroundSpeed = DataTransit.SpeedTransit;

        if (!playerController.IsGameOver)
        {
            transform.Translate(Vector3.back * Time.deltaTime * GroundSpeed);
            if (originPoz.z - transform.position.z > gameObject.GetComponent<BoxCollider>().size.z / 2)
            {
                transform.position = originPoz;
            }
        }
    }
}
