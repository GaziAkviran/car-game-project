using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Vehicles.Car;

public class GameManager : MonoBehaviour
{
    public CarController carCont;
    public TextMeshProUGUI speedText;
    private float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        speed = (int)carCont.kphSpeed;
        speedText.text = speed.ToString();
    }
}
