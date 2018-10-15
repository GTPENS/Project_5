using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private Transform target;
    private int waypointindex = 0;
    private Enemy enemy;
    public bool isDamaged = false;
    // Use this for initialization
    void Start () {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
        enemy.speed = enemy.StartSpeed;
    }

    void GetNextWayPoint()
    {
        if (waypointindex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        waypointindex++;
        target = Waypoints.points[waypointindex];
    }

    void EndPath()
    {
        isDamaged = true;
        Destroy(gameObject);
    }
}
