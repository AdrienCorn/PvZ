using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    private int energy;
    private float time;

    public static Action onTimeUpdated;
    public static Action onEnergyUpdated;

    // Start is called before the first frame update
    private void Start()
    {
        time = 0;
        energy = 0;
        EnergyManager.Instance.SpawnEnergy(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    private void Update()
    {
        SetTime(Time.time);
    }

    public int GetEnergy()
    {
        return energy;
    }

    public float GetTime()
    {
        return time;
    }

    public void SetEnergy(int energy)
    {
        this.energy = energy;
        onEnergyUpdated?.Invoke();
    }

    public void SetTime(float time)
    {
        this.time = time;
        onTimeUpdated?.Invoke();
    }

    public void AddEnergy(int energy)
    {
        this.energy += energy;
        onEnergyUpdated?.Invoke();
    }

    public void RemoveEnergy(int energy)
    {
        this.energy -= energy;
        onEnergyUpdated?.Invoke();
    }
}
