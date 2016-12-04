﻿using UnityEngine;
using System.Collections;

public class AStarUnit : MonoBehaviour
{
    Transform target;
    float speed;
    Vector3[] path;
    int targetIndex;
    float time = 0.0f;

    Grid grid;

    Node currentNode;
    Node targetNode;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        grid = GameObject.FindGameObjectWithTag("AI").GetComponent<Grid>();
        speed = Random.Range(1.5f, 2.5f);

        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);

        targetNode = grid.NodeFromWorldPoint(target.position);
        currentNode = targetNode;
    }

    void Update()
    {
        targetNode = grid.NodeFromWorldPoint(target.position);
        time += Time.deltaTime;

        // is the player still on the same node as before?
        // if not, then change the path
        if (currentNode != targetNode) {
            //Debug.Log("Path changed!");

            if (time >= 2.0f)
            {
                // Update path 
                PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
                time = 0.0f;
                currentNode = targetNode;
            }
        }
        return;
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        if (path.Length == 0) {
            yield return null;
        }

        Vector3 currentWaypoint = Vector3.zero;

        try
        {
            currentWaypoint = path[0];
        }
        catch (System.IndexOutOfRangeException c) {
            string f = c.Message;
        }

        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }

                currentWaypoint = path[targetIndex];
            }

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            transform.LookAt(currentWaypoint);
            yield return null;
        }
    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }

} // end class Unit
