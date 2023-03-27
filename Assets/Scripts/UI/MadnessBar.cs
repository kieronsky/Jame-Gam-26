using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MadnessBar : MonoBehaviour
{
    [SerializeField] private CollectibleCard collectible;
    [SerializeField] private Image currentMadnessBar;
    



    private void Update()
    {
        currentMadnessBar.fillAmount = collectible.currentCards / 52;
    }
}
