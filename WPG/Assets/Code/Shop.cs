using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public TurretBlueprint StandardTurret;
    public TurretBlueprint LaserTurret;
    public TurretBlueprint GunnerTurret;
    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    // Use this for initialization
    public void SelectBomb () {

        buildManager.SelectTurretToBuild(StandardTurret);
	}
	
	// Update is called once per frame
	public void SelectLaser () {
        buildManager.SelectTurretToBuild(LaserTurret);
    }

    public void SelectGunner()
    {
        buildManager.SelectTurretToBuild(GunnerTurret);
    }
}
