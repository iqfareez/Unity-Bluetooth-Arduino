using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Linq;
using UnityEngine.Serialization;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private String serialPort = "COM3";

    [SerializeField] private int serialBaudRate = 9600;

    private SerialPort _btStream;

    [SerializeField] private GameObject arrowUp;
    [SerializeField] private GameObject arrowDown;
    [SerializeField] private GameObject arrowLeft;
    [SerializeField] private GameObject arrowRight;
    
    private float _vehicleSpeed = 0.0f;
    private float _vehiclePosition = 0.0f;
    private Rigidbody _rigidbodyComponent;



    // Start is called before the first frame update
    void Start()
    {
        _btStream = new SerialPort(serialPort, serialBaudRate);
        _btStream.Open();
        _rigidbodyComponent = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var data = _btStream.ReadLine();
        // Debug.Log(data);

        // x direction
        if (data.StartsWith("vrx"))
        {
            var command = data.Split(':').Last().Trim();

            switch (command)
            {
                case "C":
                    arrowLeft.SetActive(false);
                    arrowRight.SetActive(false);
                    break;
                case "L":
                    arrowLeft.SetActive(true);
                    arrowRight.SetActive(false);
                    _vehiclePosition -= .5f;
                    break;
                case "R":
                    arrowLeft.SetActive(false);
                    arrowRight.SetActive(true);
                    _vehiclePosition += .5f;

                    break;
            }
        }

        if (data.StartsWith("vry"))
        {
            var command = data.Split(':').Last().Trim();
            
            switch (command)
            {
                case "C":
                    arrowUp.SetActive(false);
                    arrowDown.SetActive(false);
                    break;
                case "U":
                    arrowUp.SetActive(true);
                    arrowDown.SetActive(false);
                    _vehicleSpeed += .1f;
                    break;
                case "D":
                    arrowUp.SetActive(false);
                    arrowDown.SetActive(true);
                    _vehicleSpeed -= .1f;
                    break;
            }
        }

        _rigidbodyComponent.velocity = new Vector3(0, 0, _vehicleSpeed);
        _rigidbodyComponent.position = new Vector3(_vehiclePosition, _rigidbodyComponent.position.y, _rigidbodyComponent.position.z);

    }

    private void OnApplicationQuit()
    {
        _btStream.Close();
    }
}