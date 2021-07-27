using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeat : MonoBehaviour
{
    public const float groundSpeed = 10;

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
        if (!playerController.IsGameOver)
        {
            transform.Translate(Vector3.back * Time.deltaTime * groundSpeed);
            if (originPoz.z - transform.position.z > gameObject.GetComponent<BoxCollider>().size.z / 2)
            {
                transform.position = originPoz;
            }
        }
    }
}
