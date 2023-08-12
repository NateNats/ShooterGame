using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHelath : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    public Image frontHealth;
    public Image backHealth;
    private float maxHealth = 100;
    private float health = 0;
    private float lerpTimer;
    public float chipSpeed = 2f;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateUIHealth();
        promptText.text = health.ToString() + "%";
        if (Input.GetKeyUp(KeyCode.Q))
        {   
            decreaceHealth(25);
        }

        if (Input.GetKeyUp(KeyCode.R))
        { 
            increaceHealth(10);
        }
        Debug.Log(health.ToString());
    }

    void UpdateUIHealth()
    {
        float front = frontHealth.fillAmount;
        float back = backHealth.fillAmount;
        float hFraction = health / maxHealth;

        //heal
        if (hFraction > front)
        {
            backHealth.fillAmount = hFraction;
            backHealth.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealth.fillAmount = Mathf.Lerp(back, backHealth.fillAmount, percentComplete);

        }

        //taking damage
        if (hFraction < front)
        {
            frontHealth.fillAmount = hFraction;
            backHealth.color= Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealth.fillAmount = Mathf.Lerp(back, frontHealth.fillAmount, percentComplete);
        }
    }

    void increaceHealth(float plus)
    { 
        health += plus;
    }

    void decreaceHealth(float minus)
    { 
        health -= minus;
    }
}
