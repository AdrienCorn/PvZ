using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    [SerializeField] private int defaultMaxValue;
    [SerializeField] private int defaultMinValue;
    [SerializeField] private GameObject energyPrefab;

    public void SpawnEnergy(Vector3 postion)
    {
        SpawnEnergy(postion, defaultMinValue, defaultMaxValue);
    }

    public void SpawnEnergy(Vector3 postion, int minValue, int maxValue)
    {
        GameObject energyObject = energyPrefab;
        Energy energy = energyObject.GetComponent<Energy>();
        energy.SetValue((int)Random.Range(minValue, maxValue));

        var energyInstance = Instantiate(energyObject);
        energyInstance.transform.parent = transform;
        energyInstance.transform.position = postion;
    }
}
