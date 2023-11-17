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

    private void OnEnable()
    {
        GameManager.onTimeUpdated += SetTimeUI;
        GameManager.onEnergyUpdated += SetEnergyUI;
    }

    private void OnDisable()
    {
        GameManager.onTimeUpdated -= SetTimeUI;
        GameManager.onEnergyUpdated -= SetEnergyUI;
    }

    private void Update()
    {
        SetTimeUI();
    }

    private void SetTimeUI()
    {
        float time = GameManager.Instance.GetTime();
        float minutes = Mathf.Floor(time / 60);
        float seconds = time % 60;
        timeTextMesh.text = "Time : " + minutes + ":" + Mathf.RoundToInt(seconds);
    }

    private void SetEnergyUI()
    {
        int energyValue = GameManager.Instance.GetEnergy();
        energyTextMesh.text = "Energy : " + energyValue;
    }
}
