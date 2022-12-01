using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedIndicator : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    
    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Speed: " + _player.GetComponent<Rigidbody>().velocity.z;
    }
}
