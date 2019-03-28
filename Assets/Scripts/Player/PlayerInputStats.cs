using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LastState
{
    ChangeLayer,
    Crouch,
    CrouchWalk,
    Die,
    Dash,
    Idle,
    Jump,
    Run,
    Walk
}

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

    public float m_layerScaleDown;
    public float m_layerChangeDurtion;

    public float m_fwalkSpeed;
    public float m_frunSpeed;
    public float m_fjumpForce;

    public float m_fdashCoolDown;
    public float m_currentDashCooldown;
    public float m_fdashTime;
    public float m_fdashSpeed;

    public int m_nlives;

    public float m_maxHealth;
    public float m_currentHealth;

    public float m_maxStamina;
    public float m_currentStamina;

    public LastState m_lastState;
}
