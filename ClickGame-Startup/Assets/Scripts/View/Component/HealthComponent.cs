using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour {

    public Slider healthSlider;
    private int currentHealth;
    public float smooth = 5f;

    public bool IsOver  //告知血量為零
    {
        get
        {
            return currentHealth <= healthSlider.minValue;
        }
    }

    [ContextMenu("Test Hurt")]
    private void TestHurt()
    {
        Init(100);
        Hurt(50);
    }
    public void Init(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = healthSlider.maxValue;
        currentHealth = (int)healthSlider.maxValue;
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
        currentHealth = (int)Mathf.Max(healthSlider.minValue, currentHealth) ;
    }

	void Update ()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value,currentHealth,Time.deltaTime * smooth) ;	
	}
}
