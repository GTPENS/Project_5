using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Vector3 positionOffset;
    public Color hoverColor;
    public Color notEnoughMoneyColor;


    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    public GameObject SFXSelect;

    BuildManager buildManager;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        //shop = GetComponent<Shop>();
        buildManager = BuildManager.instance;
	}

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        
        if (turret != null)
        {
            buildManager.SelectNode(this);
            GameObject SFXSelected = (GameObject)Instantiate(SFXSelect);
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        //buildManager.BuildTurretOn(this);
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not Enough Money");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        GameObject SfxBuild = (GameObject)Instantiate(buildManager.SFXBuild);
        Destroy(SfxBuild, 1f);

        Debug.Log("Turret Has Been Built !, Money Left : " + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.UpgradeCost)
        {
            Debug.Log("Not Enough Money To Upgrade That");
            return;
        }
        PlayerStats.Money -= turretBlueprint.UpgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.UpgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;


        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        GameObject SfxUpgrade = (GameObject)Instantiate(buildManager.SFXUpgrade);
        Destroy(SfxUpgrade, 1f);

        isUpgraded = true;

        Debug.Log("Turret Has Been Built !, Money Left : " + PlayerStats.Money);
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        GameObject SfxSell = (GameObject)Instantiate(buildManager.SFXSell);
        Destroy(SfxSell, 1f);

        Destroy(turret);
        turretBlueprint = null;
    }

    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor; 
        }

        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
           
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;    
    }
}
