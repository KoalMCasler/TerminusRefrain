using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    public int FoodResource;
    public int Scrap;
    private string FoodString;
    private string ScrapString;
    public TextMeshProUGUI FoodHUDObject;
    public TextMeshProUGUI ScrapHUDObject;


    // Start is called before the first frame update
    void Start()
    {
        FoodResource = 0;
        Scrap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FoodString = string.Format("Food: {0}", FoodResource);
        ScrapString = string.Format("Scrap: {0}", Scrap);
        FoodHUDObject.text = FoodString;
        ScrapHUDObject.text = ScrapString;
    }
}
