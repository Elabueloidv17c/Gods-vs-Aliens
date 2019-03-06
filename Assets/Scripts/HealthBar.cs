using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image HBar;
    public Image SBar;
    public Image PBar1;
    public Image PBar2;
    public Image PBar3;

    float Health;
    float Stamina;
    float PowerAll;
    float PowerInBar;
    float MaxBar;

    public void Start()
    {
        Health = 100.0f;
        Stamina = 100.0f;
        PowerAll = 0.0f;
        PowerInBar = 0.0f;
        MaxBar = 100.0f;

        PBar1.fillAmount = 0.0f;
        PBar2.fillAmount = 0.0f;
        PBar3.fillAmount = 0.0f;
    }

    public void Damage(float value)
    {
        Health -= value;
        HBar.fillAmount = Health / MaxBar;
    }

    public void Attack(float value)
    {
        if (Stamina > 0)
        {
            Stamina -= value;

            if(PowerAll == 0.0f)
            {
                PowerInBar += 20.0f;
                PBar1.fillAmount = PowerInBar / MaxBar;
                if(PBar1.fillAmount==1)
                {
                    PowerAll += 20.0f;
                    PowerInBar = 0.0f;
                }
            }
            if(PowerAll == 20.0f)
            {
                PowerInBar += 10.0f;
                PBar2.fillAmount = PowerInBar / MaxBar;
                if(PBar2.fillAmount==1)
                {
                    PowerAll += 30.0f;
                    PowerInBar = 0.0f;
                }
            }
            if(PowerAll == 50.0f)
            {
                PowerInBar += 5;
                PBar3.fillAmount = PowerInBar / MaxBar;
                if(PBar3.fillAmount==1)
                {
                    PowerAll = 100.0f;
                    PowerInBar = 0.0f;
                }
            }
        }

        SBar.fillAmount = Stamina / MaxBar;
    }

    void IncreaseStamina()
    {
        if (Stamina < 100)
        {
            Stamina += 0.3f;
            SBar.fillAmount = Stamina / MaxBar;
        }
    }

    private void Update()
    {
        IncreaseStamina();
    }
}