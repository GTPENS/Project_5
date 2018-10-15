using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    [Header("Attributes")]
    private Transform target;
    private Transform anotherTarget;
    private Enemy targetEnemy;

    [Header("General")]
    public float range = 5f;

    [Header("Default")]
    public GameObject bulletpref;
    public float fireRate = 1f;
    private float fireCD = 0f;

    [Header("Laser")]
    public bool useLaser = false;
    public int damageOverTime = 100;
    public float slowpct = .5f;

    public LineRenderer linerender;
    public ParticleSystem ImpactEffect;
    public Light ImpactLight;

    [Header("Balista")]
    public bool useBalista = false;

    [Header ("Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform firepoint;
    //public float TurnSpeed = 10f;
    //public Transform partToRotate;

    //public Transform partToRotate;
    // Use this for initialization


    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            if (useLaser)
            {
                if (linerender.enabled)
                {
                    linerender.enabled = false;
                    ImpactEffect.Stop();
                    ImpactLight.enabled = false;
                }
            }
            return;
        }
        //Vector3 dir = target.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = lookRotation.eulerAngles;
        //partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCD <= 0f)
            {
                Shoot();
                fireCD = 1f / fireRate;
            }
            fireCD -= Time.deltaTime;
        }
	}

    /*void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime);
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }*/

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowpct);
        if (!linerender.enabled)
        {
            linerender.enabled = true;
            ImpactEffect.Play();
            ImpactLight.enabled = true;
        }

        linerender.SetPosition(0, firepoint.position);
        linerender.SetPosition(1, target.position);
        Vector3 dir = firepoint.position - target.position;
        ImpactEffect.transform.position = target.position + dir.normalized;
        ImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletpref, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        // Slower slower = bulletGo.GetComponent<Slower>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
