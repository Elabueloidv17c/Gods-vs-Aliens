using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;

    public Image HBar;
    public Image SBar;
    public Image PBar1;
    public Image PBar2;
    public Image PBar3;

    float Health;
    float Stamina;
    float PowerAll;
    float PowerInBar;
    float MaxBarHP;
    float MaxBarStamina;
    float MaxBarPower;

    public void Start()
    {
        //Health = 100.0f;
        //Stamina = 100.0f;
        //PowerAll = 0.0f;
        //PowerInBar = 0.0f;
        //MaxBar = 100.0f;

        player = Camera.main.GetComponent<playerList>().arrPlyrList[0];

        MaxBarHP = player.GetComponent<PlayerInputStats>().m_maxHealth;
        MaxBarStamina = player.GetComponent<PlayerInputStats>().m_maxStamina;
        MaxBarPower = player.GetComponent<PlayerInputStats>().m_maxPower;

        Health = player.GetComponent<PlayerInputStats>().m_currentHealth;
        Stamina = player.GetComponent<PlayerInputStats>().m_currentStamina;
        PowerAll = player.GetComponent<PlayerInputStats>().m_currentPower;

        PBar1.fillAmount = 0.0f;
        PBar2.fillAmount = 0.0f;
        PBar3.fillAmount = 0.0f;
    }

    public void Damage(float value)
    {
        Health -= value;
        HBar.fillAmount = Health / MaxBarHP;
    }

    public void Attack(float value)
    {
        if (Stamina > 0)
        {
            Stamina -= value;

            if(PowerAll == 0.0f)
            {
                PowerInBar += 20.0f;
                PBar1.fillAmount = PowerInBar / MaxBarPower;
                if(PBar1.fillAmount==1)
                {
                    PowerAll += 20.0f;
                    PowerInBar = 0.0f;
                }
            }
            if(PowerAll == 20.0f)
            {
                PowerInBar += 10.0f;
                PBar2.fillAmount = PowerInBar / MaxBarPower;
                if(PBar2.fillAmount==1)
                {
                    PowerAll += 30.0f;
                    PowerInBar = 0.0f;
                }
            }
            if(PowerAll == 50.0f)
            {
                PowerInBar += 5;
                PBar3.fillAmount = PowerInBar / MaxBarPower;
                if(PBar3.fillAmount==1)
                {
                    PowerAll = 100.0f;
                    PowerInBar = 0.0f;
                }
            }
        }

        SBar.fillAmount = Stamina / MaxBarStamina;
    }

    void IncreaseStamina()
    {
        if (Stamina < 100)
        {
            Stamina += 0.3f;
            SBar.fillAmount = Stamina / MaxBarStamina;
        }
    }

    private void Update()
    {
        IncreaseStamina();
    }
}