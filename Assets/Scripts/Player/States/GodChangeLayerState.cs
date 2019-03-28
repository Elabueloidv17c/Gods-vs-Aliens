using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodChangeLayerState : GodState
{
    private Vector3 newlayerScale;
    private Vector3 oldlayerScale;
    private Vector3 oldPos;
    private Vector3 newPos;
    private bool layerUp;
    private bool changedL;
    private int m_layer;
    private float m_lChangeTimer;
    private float m_gScalebackup;
    public void setLayerDir(bool layerDir)
    {
        layerUp = layerDir;
        m_lChangeTimer = 0;
        changedL = false;
    }
    public override void onEnter()
    {
        m_layer = gameObject.layer;
        if(m_layer < 14 && m_layer >= 12 && !layerUp)
        {
            --m_layer;
            changedL = true;
        }
        else if(m_layer <= 14 && m_layer > 12 && layerUp)
        {
            ++m_layer;
            changedL = true;
        }
        if (changedL)
        {
            /**
            * **********
            *  Turn off grvity & collisions
            * **********
            */
            m_gScalebackup = GSM.rb.gravityScale;
            GSM.rb.gravityScale = 0;
            GSM.m_collider.isTrigger = true;

            /**
            * **********
            *  Calc new position & scale
            * **********
            */
            oldPos = gameObject.transform.position;
            newPos = new Vector3(GSM.rb.velocity.x * GSM.PSInput.m_layerChangeDurtion, gameConstants.LAYER_DISTANCE);
            if (!layerUp)
            {
                newPos.y *= -1;
            }
            GSM.rb.velocity = Vector3.zero;

            oldlayerScale = gameObject.transform.lossyScale;

            if(m_layer == 12)
            {
                newlayerScale = Vector3.one;
            }
            if (m_layer == 13)
            {
                newlayerScale = Vector3.one * (1 - GSM.PSInput.m_layerScaleDown);
            }
            if (m_layer == 14)
            {
                newlayerScale = Vector3.one * (1 - (GSM.PSInput.m_layerScaleDown * 2));
            }
            m_lChangeTimer = 0;
        }
    }
    public override void onExit()
    {
        layerUp = false;
        m_lChangeTimer = 0;
        gameObject.layer = m_layer;
        GSM.rb.gravityScale = m_gScalebackup;
        GSM.m_collider.isTrigger = false;
    }
    public override void onUpdate()
    {
        m_lChangeTimer += Time.deltaTime;
        if (changedL)
        {
            float alpha = m_lChangeTimer / GSM.PSInput.m_layerChangeDurtion;
            gameObject.transform.localScale = Vec3Lerp(oldlayerScale, newlayerScale, alpha);
            gameObject.transform.position = Vec3Lerp(oldPos, newPos, alpha);

            if (m_lChangeTimer >= GSM.PSInput.m_layerChangeDurtion)
            {
                GSM.setState(GSM.Idle);
            }
        }
        else
        {
            GSM.setState(GSM.Idle);
        }
    }

    Vector3 Vec3Lerp(Vector3 vec1, Vector3 vec2, float alpha)
    {
        Mathf.Clamp(alpha, 0, 1);
        return (vec1 + (vec2 - vec1) * alpha);
    }
}
