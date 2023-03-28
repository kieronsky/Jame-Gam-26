using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image currenthealthBar;
    

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 3;
    }

}
