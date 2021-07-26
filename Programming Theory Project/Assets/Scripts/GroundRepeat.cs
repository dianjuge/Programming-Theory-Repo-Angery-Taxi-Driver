using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeat : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 originPoz;
    // Start is called before the first frame update
    void Start()
    {
        originPoz = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Ground").transform.Translate(Vector3.back * Time.deltaTime * speed);
        Debug.Log(gameObject.GetComponent<BoxCollider>().size.z);
        if (originPoz.z - transform.position.z > gameObject.GetComponent<BoxCollider>().size.z / 2)
        {
            transform.position = originPoz;
        }
    }
}
