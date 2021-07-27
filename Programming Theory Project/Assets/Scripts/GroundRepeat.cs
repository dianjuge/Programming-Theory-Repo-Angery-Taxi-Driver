using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeat : MonoBehaviour
{
    public const float groundSpeed = 10;
    
    Vector3 originPoz;
    // Start is called before the first frame update
    void Start()
    {
        originPoz = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * groundSpeed);
        if (originPoz.z - transform.position.z > gameObject.GetComponent<BoxCollider>().size.z / 2)
        {
            transform.position = originPoz;
        }
    }
}
