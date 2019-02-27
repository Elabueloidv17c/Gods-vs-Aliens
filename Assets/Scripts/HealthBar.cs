using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Scrollbar HBar;
    public Scrollbar SBar;
    public Scrollbar PBar1;
    public Scrollbar PBar2;
    public Scrollbar PBar3;

    public float Health;
    public float Stamina;
    public float PowerAll;
    public float PowerInBar;

    public void Start()
    {
        Health = 100.0f;
        Stamina = 100.0f;
        PowerAll = 0.0f;
        PowerInBar = 0.0f;

        PBar1.size = 0.0f;
        PBar2.size = 0.0f;
        PBar3.size = 0.0f;
    }

    public void Damage(float value)
    {
        Health -= value;
        HBar.size = Health / 100f;
    }

    public void Attack(float value)
    {
        if (Stamina > 0)
        {
            Stamina -= value;

            if(PowerAll == 0.0f)
            {
                PowerInBar += 20.0f;
                PBar1.size = PowerInBar / 100;
                if(PBar1.size==1)
                {
                    PowerAll += 20.0f;
                    PowerInBar = 0.0f;
                }
            }
            if(PowerAll == 20.0f)
            {
                PowerInBar += 10.0f;
                PBar2.size = PowerInBar / 100;
                if(PBar2.size==1)
                {
                    PowerAll += 30.0f;
                    PowerInBar = 0.0f;
                }
            }
            if(PowerAll == 50.0f)
            {
                PowerInBar += 5;
                PBar3.size = PowerInBar / 100;
                if(PBar3.size==1)
                {
                    PowerAll = 100.0f;
                    PowerInBar = 0.0f;
                }
            }
        }

        SBar.size = Stamina / 100;
    }

    void IncreaseStamina()
    {
        if (Stamina < 100)
        {
            Stamina += 1;
            SBar.size = Stamina / 100;
        }
    }

    private void Update()
    {
        IncreaseStamina();
    }
}