using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EquipmentMenu : MonoBehaviour
{
    public GameObject EquipMenu;
    public GameObject PauseMenu;
    public GameObject HUD;
    [SerializeField]
    private bool MenuIsUsed;
    public bool MenuCanBeUsed;
    // Start is called before the first frame update
    void Start()
    {
        EquipMenu.SetActive(false);
        MenuIsUsed = false;
    }
    void Update()
    {
        if(Input.GetButtonDown("Interact") && MenuCanBeUsed == true)
        {
            OpenMenu();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && MenuIsUsed == true)
        {
            CloseMenu();
        }
    }
    void OpenMenu()
    {
        gameObject.GetComponent<RangedCombat>().lightAmmo = gameObject.GetComponent<RangedCombat>().lightAmmoMax;
        gameObject.GetComponent<RangedCombat>().heavyAmmo = gameObject.GetComponent<RangedCombat>().heavyAmmoMax;
        MenuIsUsed = true;
        EquipMenu.SetActive(true);
        PauseMenu.SetActive(false);
        HUD.SetActive(false);
        Time.timeScale = 0.0f;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wardrobe"))
        {
            MenuCanBeUsed = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Wardrobe"))
        {
            MenuCanBeUsed = false;
        }
    }
    public void CloseMenu()
    {
            Time.timeScale = 1f;
            MenuIsUsed = false;
            EquipMenu.SetActive(false);
            PauseMenu.SetActive(true);
            HUD.SetActive(true);
    }
}
