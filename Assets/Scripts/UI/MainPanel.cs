using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeTextMesh;
    [SerializeField] private TextMeshProUGUI energyTextMesh;

    private void Start()
    {
        
    }

    private void Update()
    {
        SetTimeUI(GameManager.Instance.GetTime());
    }

    private void SetTimeUI(float timeValue)
    {
        float minutes = Mathf.Floor(timeValue / 60);
        float seconds = timeValue % 60;
        timeTextMesh.text = "Time : " + minutes + ":" + Mathf.RoundToInt(seconds);
    }

    private void SetEnergyUI(int energyValue)
    {
        energyTextMesh.text = "Energy : " + energyValue;
    }
}
