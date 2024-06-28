using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A subclass of Building that produce resource at a constant rate.
/// </summary>
public class ResourcePile : Building
{
    public ResourceItem Item;

    private float m_ProductionSpeed = 0.5f;

    private float m_CurrentProduction = 0.0f;


    //propiedad
    public float ProductionSpeed
    {
        get //retornar campo de respaldo
        {
            return this.m_ProductionSpeed;
        }
        set //asignar un valor al campo de respaldo
        {
            if (value < 0.0f)
            {
                Debug.LogError("no se puede asignar valores negativos");

            }
            else
            {
                m_ProductionSpeed = value;
            }
            
        }
    }
    private void Update()
    {
        if (m_CurrentProduction > 1.0f)
        {
            int amountToAdd = Mathf.FloorToInt(m_CurrentProduction);
            int leftOver = AddItem(Item.Id, amountToAdd);

            m_CurrentProduction = m_CurrentProduction - amountToAdd + leftOver;
        }
        
        if (m_CurrentProduction < 1.0f)
        {
            m_CurrentProduction += m_ProductionSpeed * Time.deltaTime;
        }
    }

    public override string GetData()
    {
        return $"Producing at the speed of {m_ProductionSpeed}/s";
        
    }
    
    
}
