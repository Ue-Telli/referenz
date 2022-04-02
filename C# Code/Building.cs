using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Building : MonoBehaviour
{
    public BuildFunktion BuildF;
    public Tilemap map;
    public GameObject worker;
    public string stuffname = "leer";
    public Vector3Int cellPos { get; set; }
    public List<TreeTile> TilePos = new List<TreeTile>();

    private void Start()
    {
        map = GameObject.Find("build").GetComponent<Tilemap>();
        cellPos = map.WorldToCell(transform.position);
    }

    public void FindAllTile(string Stuff)
    {
        // int isoUp_Down=0;
        // int isoRL=0;
        TilePos.Clear();
        for (int x = -6; x < 6; x++)
        {
            for (int y = -6; y < 6; y++)
            {
                Vector3Int neigbhourGrid = new Vector3Int(cellPos.x + x, cellPos.y + y, 0);

                if (map.HasTile(neigbhourGrid))
                {
                    TileBase t = map.GetTile(neigbhourGrid);
                    if (t.name == Stuff)
                    {
                        TreeTile tt = new TreeTile()
                        {
                            cellOnGrid = neigbhourGrid,
                            Value = 4,
                            isCutted = false
                        };
                        TilePos.Add(tt);
                    }
                }
            }
        }
    }
    public int GetAllValueOfItem(string item) 
    {
        int v=0;
        Slot[] items = FindObjectsOfType<Slot>();
        foreach(Slot data in items) 
        {
            
        }
        return v;
    }

   
    public Vector3Int GetNextTile()
    {
        Vector3Int tree = cellPos;
        float nexttree = 1000;
        foreach (TreeTile data in TilePos)
        {
            if (data.isCutted == false)
            {
                if (nexttree > Vector3Int.Distance(cellPos, data.cellOnGrid))
                {
                    nexttree = Vector3Int.Distance(cellPos, data.cellOnGrid);
                    tree = data.cellOnGrid;
                }
            }
        }
        return tree;
    }
    public void EndOfFame(string trans) 
    {
        gameObject.GetComponent<Animator>().SetBool(trans, false);
    }
}
         

