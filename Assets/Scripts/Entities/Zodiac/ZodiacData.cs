using System;

[Serializable]
public class ZodiacData : EntityData<ZodiacSign>
{
    public int Cost;
    public bool GenerateEnergy = false;
    public int EnergyMin = 0;
    public int EnergyMax = 0;
}
