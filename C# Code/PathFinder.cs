using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathFinder
{
    public Vector3Int StartNode;
    public Vector3Int EndNode;
    public Tilemap Feld;
    //private Vector3Int currentNode;

    struct Node 
    { 
    public int XNode;
    public int yNode;

    public int NodeCost;
    }

    private List<Vector3Int> Path= new List<Vector3Int>();
    private List<List<Vector3Int>> AllPaths = new List<List<Vector3Int>>();
   
    private void Pahts() 
    {
        Node currentNode = new Node();

        currentNode.XNode = StartNode.x;
        currentNode.yNode = StartNode.y;
        bool foundPath=false;
        while (foundPath)
        {
            if (currentNode.XNode != EndNode.x) 
            { 
            
            }
            if (EndNode.x < 0 && EndNode.y < 0)
            {
                Vector3Int nextNode = new Vector3Int(currentNode.XNode - 1, currentNode.yNode - 1, 0);
                if (Feld.HasTile(nextNode))
                {
                    TileBase tb = Feld.GetTile(nextNode);
                    if (tb.name == "ground")
                    {
                        Path.Add(nextNode);
                    }
                }
                currentNode.XNode -= 1;
                currentNode.yNode -= 1;
                currentNode.NodeCost += 1;
            }
            else if (EndNode.x < 0 || EndNode.y < 0)
            {

            };
        }
    }

    private void KuerzeterYol() 
    {
    
    }
}
