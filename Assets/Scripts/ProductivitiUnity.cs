using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivitiUnity : Unit
{
    [SerializeField] 
    private Color furColor;

    //veriable
    private ResourcePile m_CurrentPile;
    public float ProductiviteMultiplier = 2;


  
        

    protected override void BuildingInRange()
    {
        if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductiviteMultiplier;
            }
        }

    }

    void ResetPRoductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ProductiviteMultiplier;
            m_CurrentPile = null;

            Debug.Log("Entering ");
        }
    }
    public override void GoTo(Building target)
    {
        ResetPRoductivity(); // para llamar a metodo implementado en la clase unity
        base.GoTo(target); //llamar al metodo de la clase base
    }
    public override void GoTo(Vector3 position)
    {
        ResetPRoductivity();
        base.GoTo(position);
    }

}
