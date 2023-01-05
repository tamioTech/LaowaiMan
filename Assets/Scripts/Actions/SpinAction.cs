using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    public delegate void SpinCompleteDelegate();
    private float totalSpinAmount;
    
    void Update()
    {
        if (!isActive) { return; }

        float spinAddAmount = 360f * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, spinAddAmount, 0);
        print(transform.eulerAngles);
            

        totalSpinAmount += spinAddAmount;
        if(totalSpinAmount >= 360)
        {
            isActive = false;
            onActionComplete();
        }

    }

    public void Spin(Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        isActive = true;
        totalSpinAmount = 0f;
    }

    public override string GetActionName()
    {
        return "Spin";
    }
}
