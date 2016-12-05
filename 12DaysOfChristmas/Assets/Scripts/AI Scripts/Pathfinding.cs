using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


// A* Pathfinding Calculator Class
[RequireComponent(typeof(Grid))]
[RequireComponent(typeof(PathRequestManager))]
public class Pathfinding : MonoBehaviour
{
    PathRequestManager requestManager;
    Grid grid;

    void Awake()
    {
        requestManager = GetComponent<PathRequestManager>();
        grid = GetComponent<Grid>();
    }

    // Start to find a path
    public void StartFindPath(Vector3 startPos, Vector3 targetPos)
    {
        StartCoroutine(FindPath(startPos, targetPos));
    }


    // The ACTUALLY A* ALGORITHM
    IEnumerator FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Vector3[] waypoints = new Vector3[0]; // build a set of waypoints for the agent to follow
        bool pathSuccess = false;

        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);


        if (startNode.walkable && targetNode.walkable)
        {
            ////////////////////////////////////////////////////////////////

            #region A* Pathfinding Algorithm

            Heap<Node> openSet = new Heap<Node>(grid.MaxSize); // OPEN SET - the set of nodes to be evaluated
            HashSet<Node> closedSet = new HashSet<Node>(); // CLOSED SET - set of nodes already evaluated
            openSet.Add(startNode); // Add the start node to OPEN SET

            while (openSet.Count > 0) // Loop while there is still nodes to be calculated
            {
                Node currentNode = openSet.RemoveFirst(); // CURRENT = node in OPEN w/ the lowest fCost
                closedSet.Add(currentNode); // Remove current from OPEN

                if (currentNode == targetNode) // A path has been FOUND -> break out of loop
                {
                    pathSuccess = true;
                    break;
                }

                // foreach neighbour of the current node
                foreach (Node neighbour in grid.GetNeighbours(currentNode)) 
                {
                    // if neighbour is not traversable or neighbour is in CLOSED
                    if (!neighbour.walkable || closedSet.Contains(neighbour)) 
                    {
                        continue; // skip to the next neighbour
                    }

                    // if new path to neighbour is shorter OR neighbour is not in OPEN
                    int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour) + neighbour.movementPenalty;


                    if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        // Set fCost (via gCost and hCost) of neighbour
                        neighbour.gCost = newMovementCostToNeighbour; 
                        neighbour.hCost = GetDistance(neighbour, targetNode);

                        // Set the parent of neighbour to this current node
                        neighbour.parent = currentNode;

                        // if neighbour is not in OPEN
                        if (!openSet.Contains(neighbour))
                            openSet.Add(neighbour); // add neighbour to OPEN
                        else
                            openSet.UpdateItem(neighbour); // or else update its neighbour
                    }
                }
            }

            #endregion

            //////////////////////////////////////////////////////////////
        }
        yield return null; // will return null if either start node or target node is unwalkable


        // Return the set of waypoints if and only if we successfully found a viable path to target
        if (pathSuccess == true) {
            waypoints = RetracePath(startNode, targetNode);
        }
        requestManager.FinishedProcessingPath(waypoints, pathSuccess);

    }

    Vector3[] RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        Vector3[] waypoints = SimplifyPath(path);
        Array.Reverse(waypoints);
        return waypoints;

    }

    Vector3[] SimplifyPath(List<Node> path)
    {
        List<Vector3> waypoints = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;

        for (int i = 1; i < path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i - 1].gridX - path[i].gridX, path[i - 1].gridY - path[i].gridY);
            if (directionNew != directionOld)
            {
                waypoints.Add(path[i].worldPosition);
            }
            directionOld = directionNew;
        }
        return waypoints.ToArray();
    }

    // Return the distance b/n two nodes on the grid
    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }


} // end class Pathfinding