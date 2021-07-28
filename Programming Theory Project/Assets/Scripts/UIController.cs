using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ZeroHealthHideSliderFill();
    }

    void ZeroHealthHideSliderFill()
    {
        if (healthSlider.value == 0)
        {
            if (GameObject.Find("Fill Area"))
            {
                GameObject.Find("Fill Area").SetActive(false);
            } 
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        GameObject data = GameObject.Find("DataTransit");
        Destroy(data);
        SceneManager.LoadScene(0);
    }
}
