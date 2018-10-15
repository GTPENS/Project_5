using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public TurretBlueprint standardTurret;
    public TurretBlueprint LaserTurret;
    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    // Use this for initialization
    public void SelectBomb () {

        buildManager.SelectTurretToBuild(standardTurret);
	}
	
	// Update is called once per frame
	public void SelectLaser () {
        buildManager.SelectTurretToBuild(LaserTurret);
    }
}
