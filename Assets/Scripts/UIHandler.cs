using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UIHandler : MonoBehaviour
{
   private VisualElement m_Healthbar;
    public float CurrentHealth = 0.5f;
   void Start()
   {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBarBackground");
        //SetHealthValue(0.2f);
        m_Healthbar.style.width = Length.Percent(CurrentHealth*100.0f);
   }


   public void SetHealthValue(float percentage)
   {
       //m_Healthbar.style.width = Length.Percent(100 * percentage);
   }


}