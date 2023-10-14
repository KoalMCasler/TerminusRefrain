using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasicHealth : MonoBehaviour
{
    public int Health;
    private string HealthString;
    public TextMeshProUGUI HealthText;
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        HealthString = string.Format("Health: {0}%", Health);
        HealthText.text = HealthString;
    }
}
