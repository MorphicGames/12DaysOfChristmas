using UnityEngine;
using System.Collections;


// Individual Nodes that represent a single spot on the grid
// We'll make sure that a node can be inserted into the heap (more on that later)
public class Node : IHeapItem<Node>
{
    public bool walkable; // can AI walk on it?

    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    // gCost = how far away is this node from the START position?
    public int gCost;

    // hCost = how far away is this node from the TARGET position?
    public int hCost;

    // Cost to move on layer
    public int movementPenalty;

    public Node parent;

    // where on the heap is this node?
    int heapIndex; 

    // Basic constructor
    public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY, int _penalty)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
        movementPenalty = _penalty;
    }

    // fCost = gCost + hCost
    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    //  Return heap index
    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }
        set
        {
            heapIndex = value;
        }
    }

    // Use this to compare the fCost of neighbouring nodes to this one
    public int CompareTo(Node nodeToCompare)
    {
        int compare = fCost.CompareTo(nodeToCompare.fCost);
        if (compare == 0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }
        return -compare;
    }
}
