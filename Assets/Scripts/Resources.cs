using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Resources : MonoBehaviour
{
    public int FoodResource;
    public int Scrap;
    private string FoodString;
    private string ScrapString;
    public TextMeshProUGUI FoodHUDObject;
    public TextMeshProUGUI ScrapHUDObject;
    public GameObject Player;
    protected Collider2D PlayerCollider;
    public LayerMask CollectionLayer;



    // Start is called before the first frame update
    void Start()
    {
        FoodResource = 0;
        Scrap = 0;
        PlayerCollider = Player.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FoodString = string.Format("Food: {0}", FoodResource);
        ScrapString = string.Format("Scrap: {0}", Scrap);
        FoodHUDObject.text = FoodString;
        ScrapHUDObject.text = ScrapString;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Collectables"))
        {
            if(other.tag == "Food")
            {
                FoodResource += 1;
                other.gameObject.SetActive(false);
            }
            if(other.tag == "Scrap")
            {
                Scrap += 1;
                other.gameObject.SetActive(false);
            }
        }
    }
}
