using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint{
    public GameObject prefab;
    public int cost;

    public GameObject UpgradedPrefab;
    public int UpgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
