using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem explosionPacticle;
    public AudioClip explosionSound;
    public AudioClip getOffSound1;
    public AudioClip getOffSound2;
    public AudioClip pickUpSound;

    public GameObject mainCamera;
    public GameObject countDownManagement;
    public Slider healthSlider;
    public TextMeshProUGUI passengerNumText;
    public TextMeshProUGUI incomeText;
    public TextMeshProUGUI[] ArriveCountDownText;

    private float verticalInput;
    private float horizontalInput;
    private float zTopBound = 29;
    private float zLowerBound = -2.5f;
    private float xRange = 18.5f;
    private float yBound = 0;
    private float income = 0;
    private float passengerfees = 100;
    private int passengerNum = 0;
    public bool[] HasPassenger { get; private set; } = new bool[4];
    
    [SerializeField] float speed;
    [SerializeField] float health = 10;
    public float Health 
    {
        get
        {
            return health;
        }
        set
        {
            health -= value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * horizontalInput);
        transform.Translate(Vector3.forward * speed * verticalInput);

        if (transform.position.z > zTopBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTopBound);
        }
        if (transform.position.z < zLowerBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLowerBound);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < yBound)
        {
            transform.position = new Vector3(transform.position.x, yBound, transform.position.z);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Vehicle>())
        {
            Vehicle vehicle = collision.gameObject.GetComponent<Vehicle>();
            vehicle.DealDamage();
            healthSlider.value = health;
            explosionPacticle.transform.position = collision.gameObject.transform.position;
            explosionPacticle.Play();
            AudioSource.PlayClipAtPoint(explosionSound, mainCamera.transform.position);
            Destroy(collision.gameObject, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Passenger"))
        {
            for(int i = 0; i < HasPassenger.Length; i++)
            {
                if(!HasPassenger[i])
                {
                    HasPassenger[i] = true;
                    passengerNum++;
                    AudioSource.PlayClipAtPoint(pickUpSound, mainCamera.transform.position);                   
                    countDownManagement.GetComponent<CountDownManagement>().RandomTravelingTime(i);
                    Destroy(other.gameObject);

                    passengerNumText.text = "PN: " + passengerNum + " / 4";
                    break;
                }
            }
                         
        }

        if (other.gameObject.CompareTag("GetOffLocation"))
        {
            int i = other.gameObject.GetComponent<Location>().PassengerID;
            Destroy(other.gameObject);
            //AudioSource.PlayClipAtPoint(getOffSound1, mainCamera.transform.position);
            AudioSource.PlayClipAtPoint(getOffSound2, mainCamera.transform.position);
            if (passengerNum > 0)
            {
                passengerNum--;
                passengerNumText.text = "PN: " + passengerNum + " / 4";
            }
            HasPassenger[i] = false;
            PassengerIsArrived(i);
            income += passengerfees;
            incomeText.text = "Income: $" + income;
        }
    }
    private void PassengerIsArrived(int i)
    {

        GameObject.Find("Player").GetComponent<PlayerController>().ArriveCountDownText[i].text = "P" + (i + 1) + " has arrived! ";
    }
}
