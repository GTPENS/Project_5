using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Others : MonoBehaviour {
    public Text Price;
    public Shop shop;
	
	// Update is called once per frame
	void Update () {
        if (Price.gameObject.tag == "Price1")
        {
            Price.text = "$" + shop.StandardTurret.cost;
        }
        else if (Price.gameObject.tag == "Price2")
        {
            Price.text = "$" + shop.LaserTurret.cost;
        }
        else if (Price.gameObject.tag == "Price3")
        {
            Price.text = "$" + shop.GunnerTurret.cost;
        }
    }
}
