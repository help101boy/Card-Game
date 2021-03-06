﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayController : MonoBehaviour {

    NetworkManagerr NMScript;
    public Text username;
    public Image HealthFill;
    public Text HealthText;
    public float CurrentHP;
    public float MaxHP;
    private float MinHP;
    private float CalcHP;
    public GameObject BottomBackroundGO;



    void Start ()
    {
        /* gets Network Manager script */
        NMScript = GameObject.Find("NetworkManager").GetComponent<NetworkManagerr>();
        if (NMScript.PlayerClass.SelectedHero != null)
        {
            username.text = NMScript.PlayerClass.SelectedHero.Name;
        }
        CurrentHP = 100;
        /* Sets Overlay visuals on start */
        ChangeBottomOverlayVusials();
	}
	
	// Update is called once per frame
	void Update ()
    {
        /* USED FOR TESTING ONLY.....NEEDS TO BE REMOVED FOR GAME */
        if (Input.GetKey(KeyCode.P))
        {
            if (CurrentHP >= MinHP && CurrentHP <= MaxHP)
            {
                UnityEngine.Debug.Log("Reducing Player Health");
                CurrentHP -= 50 * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.O))
        {
            if (CurrentHP >= MinHP && CurrentHP <= MaxHP)
            {
                UnityEngine.Debug.Log("Increasing Player Health");
                CurrentHP += 50 * Time.deltaTime;
            }
        }
        /* END OF TESTING CODE */
        /* locks hp between 0  and 100 and then divides it to get a float between 0 and 1 for fill on image */
        if ( CurrentHP > 100)
        {
            CurrentHP = 100;
        }
        if (CurrentHP < 0)
        {
            CurrentHP = 0;
        }
        CalcHP = CurrentHP / MaxHP;
        HealthFill.fillAmount = CalcHP;
        /* Sets health text to current health rounded to nearest int */
        HealthText.text = ("Health: " + Mathf.Round(CurrentHP));
	}
    /* used to change bottom overlay visability */
    public void ChangeBottomOverlayVusials()
    {
        if (NMScript.ClientSpawned != true)
        {
            BottomBackroundGO.SetActive(false);
        }
        else
        {
            BottomBackroundGO.SetActive(true);
        }
    }
}
