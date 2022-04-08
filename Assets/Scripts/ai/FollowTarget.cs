using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float pickNextWaypointDistance = 0.1f;

    public float pathRefreshRate = .5f;

    private Path path;
    int currentWaypoint = 0;

    private Seeker seeker;
    private Rigidbody rb;
    private bool shouldStop = false;

    void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody>();

        StartFollowing();
    }

    public void StartFollowing() {
        if(target != null)
            InvokeRepeating("GeneratePath", 0f, pathRefreshRate);
    }

    public void StopFollowing() {
        shouldStop = true;
        CancelInvoke("GeneratePath");
    }

    void GeneratePath() {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathCompleted);
    }

    void OnPathCompleted(Path p) {
        if(shouldStop) {
            shouldStop = false;
            return;
        }
        if(!p.error) {
            this.path = p;
            currentWaypoint = 0;
        }
    }

    void Update() {
        if(path == null) {
            rb.velocity = (target.position - transform.position).normalized * speed;
            return;
        }

        Vector3 dir = path.vectorPath[currentWaypoint] - rb.position;
        dir.y = 0;
        rb.velocity = dir.normalized * speed;

        if(dir.sqrMagnitude <= pickNextWaypointDistance * pickNextWaypointDistance)
            currentWaypoint++;
        
        if(currentWaypoint >= path.vectorPath.Count)
            this.path = null;
        

    }
}
