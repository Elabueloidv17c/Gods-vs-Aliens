using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodChangeLayerState : GodState
{
    private bool layerUp;
    public void setLayerDir(bool layerDir)
    {
        layerUp = layerDir;
    }
    public override void onEnter()
    {

    }
    public override void onExit()
    {
        layerUp = false;
    }
    public override void onUpdate()
    {

    }
}
