using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private Transform target;
    private Transform otherTarget;
    private int waypointindex = 0;
    private Enemy enemy;
    //public bool isDamaged = false;
    // Use this for initialization
    void Start () {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
        otherTarget = AnotherWay.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.MoveUp == true)
        {
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWayPoint();
            }
            enemy.speed = enemy.StartSpeed;
        }
        else if (enemy.MoveDown == true)
        {
            Vector3 direction = otherTarget.position - transform.position;
            transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (Vector3.Distance(transform.position, otherTarget.position) <= 0.2f)
            {
                GetNextWayPoint();
            }
            enemy.speed = enemy.StartSpeed;
        }
    }

    void GetNextWayPoint()
    {
        if (SpawnEnemy.Above == true)
        {
            if (waypointindex >= Waypoints.points.Length - 1)
            {
                EndPath();
                return;
            }
        }
        else if (SpawnEnemy.Under == true)
        { 
            if (waypointindex >= AnotherWay.points.Length - 1)
            {
                EndPath();
                return;
            }
        }
        waypointindex++;
        target = Waypoints.points[waypointindex];
        otherTarget = AnotherWay.points[waypointindex];
    }

    void EndPath()
    {
        PlayerStats.PlayerHealth -= enemy.Damage;
        Destroy(gameObject);
    }
}
