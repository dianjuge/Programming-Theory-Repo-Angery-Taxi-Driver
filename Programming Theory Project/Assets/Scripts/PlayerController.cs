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
    public GameObject gameOver;
    public Slider healthSlider;
    public TextMeshProUGUI passengerNumText;
    public TextMeshProUGUI incomeText;
    public TextMeshProUGUI healthPointText;
    public TextMeshProUGUI[] ArriveCountDownText;


    private float verticalInput;
    private float horizontalInput;
    private float zTopBound = 29;
    private float zLowerBound = -2.5f;
    private float xRange = 18.5f;
    private float yBound = 0;
    private float income;
    private float passengerfees = 100;
    private int passengerNum = 0;
    private bool isGameOver;

    public float Income { get; private set; } = 0;
    public bool[] HasPassenger { get; private set; } = new bool[4];     //ENCAPSULATION
    public bool IsGameOver { get; private set; }    //ENCAPSULATION

    [SerializeField] float speed;
    [SerializeField] float health = 10;
    [SerializeField] float maxHealth = 10;
    public float Health 
    {
        get
        {
            return health;
        }
        set
        {
            if (health <= maxHealth)
            {
                health += value;
            }
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Income:" + Income);
        Move();
    }

    private void Move()     //ABSTRACTION
    {
        if (!IsGameOver)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * speed * horizontalInput);
            transform.Translate(Vector3.forward * speed * verticalInput);
        }
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
            healthPointText.text = health + " / " + maxHealth;
            explosionPacticle.transform.position = collision.gameObject.transform.position;
            explosionPacticle.Play();
            AudioSource.PlayClipAtPoint(explosionSound, mainCamera.transform.position);
            Destroy(collision.gameObject, 0.1f);

            //if player's health is below zero, then game over;
            if (health <= 0)
            {
                gameOver.SetActive(true);
                IsGameOver = true;
                UIController uIController = GameObject.Find("Canvas").GetComponent<UIController>();
                uIController.RecordBestScore();
                uIController.ShowBestScore();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Food"))
        {
            Food food = other.gameObject.GetComponent<Food>();
            food.HealthRegain();
            healthSlider.value = health;
            healthPointText.text = health + " / " + maxHealth;
            Destroy(other.gameObject);
        }
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
            GameObject.Find("CountDownManagement").GetComponent<CountDownManagement>().ChangeSinalColorsToGreen(i);
            PassengerIsArrived(i);
            Income += passengerfees;
            incomeText.text = "Income: $" + Income;
        }
    }
    private void PassengerIsArrived(int i)
    {

        GameObject.Find("Player").GetComponent<PlayerController>().ArriveCountDownText[i].text = "P" + (i + 1) + "        Has Arrived! ";
    }
}
