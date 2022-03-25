//All rights by : Ümüt Telli
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;
using UnityEngine.UI;

public class BuildSystem : MonoBehaviour
{
    //*********BELIEBTHEITSWERTE***********//
    private static int BH_Gesamt=0;
    private static int BH_Steuer=0;
    private static int BH_Jemek = 0;
    private static int BH_Calisma = 0;
    private static int BH_Deko = 0;
    //******** wichtige Spiel Werte********//
    private const int MaxNuefus = 200;
    private int currentMaxNuefus = 0;
    private int currentNuefus = 0;
    //******** BAUSYSTEMVARIABLEN**********//
    public Grid iso;    //Grid in dem Tilemaps zur vervendung sind
    private GameObject Buildobject,Buildplan; // Buildobject ist das Prefab wo erzeugt wird BuildPlan die Blaupausen
    private bool buildingIsSelected=false;      // ein zu bauendes Gebäude ausgewählt 
    private bool canDisable;         
    private GameData data; // DatenTyp das in JSon übertragen wird
    private List<GameObject> bluePrint = new List<GameObject>(); // Liste der BlauPausen 
    private List<GameObject> AllBuilds = new List<GameObject>(); // lister aller erzeugten Gebäude
    public int RationProzent = 5;
    private float Ration;
   
    private  List<string> planeNames = new List<string> // liste aller namen der Blaupausen
    {
        "BluePrintStronhold",
        "BluePrintWareHouse",
        "BluePrintJäger",
        //"BluePrintHouse",
    };
    //********* UI WERTE ****************//
    private Slot[] zeug;
    private int gesamtHolz=0; // wert das die gasamte gelagerte ressorce Holz speichert
    private int GeStein = 0;
    private int GesEt = 0;
    private Text[] counterText; // ui element Text zum darstellen von gesamtHolz
    public Transform scheisse; // Possiton der Text UIs


    void Start()
    {
        
        SaveGame.SavePath = SaveGamePath.DataPath; // lege fest wo gespeichert werden soll 
        
        SaveGame.Encode = false;                     // festlegen ob die daten Verschlüsseld werden sollen

        if (PlayerPrefs.HasKey("KEY_LOACAL_LOAD"))  // hat der Pc das key führe LoadGame aus
        {
                LoadGame();
        }
       
        data = new GameData(); // erzeugen einer neuen GameData
        GameObject tmp;

        foreach (string datei in planeNames)  
        {
            tmp = Instantiate(Resources.Load<GameObject>(datei)); // erzeugen eines objektes aus dem Resources Ordner
            tmp.name = datei; // name des objektes festlegen
            tmp.SetActive(false); // gameobjekt is deaktiviert
            bluePrint.Add(tmp); // in die liste bluprints Speichern
        }
        
        if(!PlayerPrefs.HasKey("KEY_LOACAL_LOAD")) // wenn der Ke verfügbar ist wird sie buttonevent ausglößt
        {
                SelctedBuildIcon("Säule");
        }
        counterText = scheisse.GetComponentsInChildren<Text>();
        counterText[0].text = gesamtHolz.ToString();
        counterText[1].text = GeStein.ToString();
    }

    void Update()
    {   
        if (buildingIsSelected) // wen ein button ansgewählt 
        {
            Vector3 worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // übergebe die aktuell maus Pos
            worldpos.z = 0f;
            Vector3Int cp = iso.LocalToCell(worldpos); // maus Pos in Localisation zur der Zellen pos in ein int übergeben
            
            Buildplan.transform.localPosition = iso.GetCellCenterLocal(cp);// Blaubause auf die Pos der Zelle geben
              
             if (Input.GetMouseButtonDown(0))  // wenn die linke maustaste gedrükt ist
             {
                if(Buildplan.GetComponentInChildren<SpriteRenderer>().color == Buildplan.GetComponent<Coloring>().GetColor()) // un die fabe gleich die farbe Grün ist
                { 
                    GameObject build= Instantiate(Buildobject, Buildplan.transform.position, Quaternion.identity); // erzeugen eines gebäudes
                    build.transform.parent = this.transform; 
                    build.name = Buildobject.name; // setzen des gebäude name
                    AllBuilds.Add(build); // speichen in der liste 
                    NewBuildingEigenschaft(build.name);
                    if (!canDisable) // wenn bauplan nicht entfernt werden kann
                    {
                        Buildplan.SetActive(false); // dann deaktiviere Blaupause
                        buildingIsSelected = false; // button ist aosgwählt is false
                        canDisable = true; // baublan kann entfernt werden
                    }
                }         
             }
             else if (Input.GetMouseButtonDown(1)&& canDisable) // wenn rechte maustaste gedrückt und canDisabel wahr 
             {
                 Buildplan.SetActive(false);  // deaktiviere bauplan
                 buildingIsSelected = false; // gabädetype ist ausgawählt falsch
             }
         }
    }

    private void LateUpdate()
    {
        GetBH();
        if (BH_Gesamt > 50) 
        { 
        
        }
    }
    private void NewBuildingEigenschaft(string name) 
    {
        switch (name) 
        {
            case "Hütte":if (currentMaxNuefus < MaxNuefus) {
                            currentMaxNuefus += 10;};break;
            case "Jäger":; break;
            case "Holzfäller":; break;
            case "Steinmetz":; break;
        }    
    }
    private List<GameObject> KontrolNuefus(string name) 
    {
        List<GameObject> spezifyBuild = new List<GameObject>();
        
    foreach(GameObject data in AllBuilds) 
        {
            if (data.CompareTag(name)) 
            {
               spezifyBuild.Add(data);
            }
        }
        return spezifyBuild;
    }

        public void Chance()
        {
            Slot[] items = FindObjectsOfType<Slot>();
            int i = 0;
            gesamtHolz = 0;
            GesEt = 0;
            foreach (Slot data in items)
            {
            i = 0;
            foreach(string stuff in data.itemname) 
            {
                if (stuff != null)
                {
                    switch (stuff) 
                    {
                     case "Latten":gesamtHolz+= data.itemvalue[i];break;
                     case "Fleisch":GesEt +=data.itemvalue[i];break;
                    }
                 }
                i++;
            }
            counterText[0].text = gesamtHolz.ToString();
            counterText[1].text = GesEt.ToString();
            //counterText[2].text = data.itemvalue[2].ToString();
            //counterText[3].text = data.itemvalue[3].ToString();
        }
            
        }
        private void GetBH()        // Maximale Zufriedenheit ist 100%
    {
        GameObject[] wr = GameObject.FindGameObjectsWithTag("Arbeiter");
        float Zufriedenheit_Wr = 0.5f * currentNuefus;
        float current = Zufriedenheit_Wr / 100 * 20;

        if (GesEt < Ration) { BH_Jemek -= 1; }
        else if (BH_Jemek < 50) { BH_Jemek += 1; }// Essenszufriedenheit geht maximal bis 50

        if (currentNuefus > wr.Length) { BH_Calisma = (int)current; }

        BH_Gesamt = BH_Steuer + BH_Jemek + BH_Calisma +BH_Deko; // gesamt zufriedenheit geht bis maxwert 130 und minwert 0
    }

    private bool Check(string filename) // überptüfung ob eine Datei existiert
    {
        bool exists = SaveGame.Exists(filename);
        return exists;
    }

 //********* Speichersystem**********//
    public void SaveTheGame() 
    {      
        PlayerPrefs.SetInt("KEY_LOCAL_PLACE", SceneManager.GetActiveScene().buildIndex); // Setzen ein Key mit der zahl des aktuellen levels

        data.Holz = gesamtHolz;
        data.Stone = GeStein;
        foreach(GameObject obj in AllBuilds)  
        {
            
            data.builded.Add(obj.name);  // eintrangen des namens in GameData des aktuellen Gebäude
            data.buildpos.Add(obj.transform.position); // eintrangen der Pos in GameData des aktuellen Gebäude
            if (obj.CompareTag("Lager")) 
            {
                data.storage.Add(obj.GetComponent<Slot>());
            }
         }
        string json = JsonUtility.ToJson(data); // GameData in eine Json umwandeln 
        
        SaveGame.Save<string>("appdata.ill",json); // übergabe der Json mit Schlüssel
        Debug.Log(json);
    }
    public void LoadGame() 
        {
            if (Check("appdata.ill")) //Überprüfe ob datei vorhanden
            {
                string json = SaveGame.Load<string>("appdata.ill",false,"penis"); // setzen den schlüssel ein und lande das den String in  json
                int i = 0;
                data = JsonUtility.FromJson<GameData>(json);                    // übertrage den json string und Convertirung in eine GameData, ablegen der infos in Data

                foreach (string obj in data.builded)                            // foreach für alle gespeicherten gebäude
                {
                    GameObject myobject = Instantiate(Resources.Load(obj) as GameObject, data.buildpos[i], Quaternion.identity);// erzeuge eines neuen Gebäudes sowie Pos
                    myobject.name = obj;                                        // name des gebäudes eintragen
                    myobject.transform.parent = transform;
                    if (obj == "Lager") 
                    {
                    myobject.GetComponent<Slot>().itemvalue[0] = data.storage[i].itemvalue[0];
                    }
                    i++;
                }
                Debug.Log(SaveGame.SavePath.ToString());
            }
            else 
            {
                Debug.Log("existiert nicht");                
            }
        }
        //*********Button Event********//

    public void  CurrentRation(int RationsType)
    {
        RationProzent = RationsType;
        Ration = currentNuefus / 100 * RationProzent;
    }
    public void SelctedBuildIcon(string name)   // funktion wird aufgerufen wenn ein Baubutton gedrückt wird
    {
        switch (name)
        {
            case "Säule":   Buildobject = Resources.Load("Bergfried") as GameObject; // übergeben des perfabs von dem Ordner in Builobject
                            Buildplan = bluePrint[0];// erstes object von der liste blueprint in Buildplan übergeben
                            Buildplan.SetActive(true); // aktiviere Buildplan
                            buildingIsSelected=true;break;

            case "Lager":   Buildobject = Resources.Load("Lager") as GameObject;
                            Buildplan = bluePrint[1];
                            Buildplan.SetActive(true);
                            buildingIsSelected = true; break;

            case "Jäger":   Buildobject = Resources.Load("Jäger") as GameObject;
                            Buildplan = bluePrint[2];
                            Buildplan.SetActive(true);
                            buildingIsSelected = true; break;

            case "Hütte":   Buildobject= Resources.Load("Hütte") as GameObject;
                            Buildplan = bluePrint[3];
                            Buildplan.SetActive(true);
                            buildingIsSelected = true; break;
        }
    }
}
