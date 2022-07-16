using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class represents the health bar for the Boss Octopus in Level 10.
public class OctopusHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //Sets the maximum value for the health bar, equivalently maximum health of boss octopus
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        
        fill.color = gradient.Evaluate(1f); //1 is the color on the right, which is what max health should be;
    }
    //Sets a current value for the health bar, equivalently current health of boss octopus
    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
