
using System;
using System.Collections.Generic;
using UnityEngine;



    [Serializable]
    public class GameData
    {
        public int currentLevel { get; set; }
        public int Holz { get; set; }
        public int Stone { get; set; }

    public List<string> builded = new List<string>();
    public List<Vector3> buildpos = new List<Vector3>();
    public List<Vector3Int> cellPos = new List<Vector3Int>();
    public List<Slot> storage = new List<Slot>();
    /* public List<string> builded { get; set; }
     public List<Vector3> buildpos { get; set; }
     public List<Slot> storage { get; set; }*/
}