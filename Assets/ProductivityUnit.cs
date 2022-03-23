using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile m_CurrentPile = null;
    public float productivityMultiplier = 2;
    protected override void BuildingInRange(){
        if(m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if(pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *=  productivityMultiplier;
            }
        }
    }

    void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= productivityMultiplier;
            m_CurrentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity(); // call your new method
        base.GoTo(target); // run method from base class
    }

    public override void GoTo(Vector3 pos)
    {
        ResetProductivity(); // call your new method
        base.GoTo(pos); // run method from base class
    }
}
