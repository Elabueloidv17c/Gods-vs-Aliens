using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputStats : MonoBehaviour
{
    public KeyCode kChangeLayerUp;
    public KeyCode kChangeLayerDown;
    public KeyCode kUp;
    public KeyCode kRight;
    public KeyCode kLeft;
    public KeyCode kDown;
    public KeyCode kDash;
    public KeyCode kJump;

    public float m_fwalkSpeed;
    public float m_frunSpeed;
    public float m_fjumpForce;
    public float m_fHP;
    public float m_SpeedDampener;

    public int m_nlives;
}
