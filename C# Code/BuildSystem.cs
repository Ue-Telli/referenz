//All rights by : �m�t Telli
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
    private bool buildingIsSelected=false;      // ein zu bauendes Geb�ude ausgew�hlt 
    private bool canDisable;         
    private GameData data; // DatenTyp das in JSon �bertragen wird
    private List<GameObject> bluePrint = new List<GameObject>(); // Liste der BlauPausen 
    private List<GameObject> AllBuilds = new List<GameObject>(); // lister aller erzeugten Geb�ude
    public int RationProzent = 5;
    private float Ration;
   
    private  List<string> planeNames = new List<string> // liste aller namen der Blaupausen
    {
        "BluePrintStronhold",
        "BluePrintWareHouse",
        "BluePrintJ�ger",
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
        
        SaveGame.Encode = false;                     // festlegen ob die daten Verschl�sseld werden sollen

        if (PlayerPrefs.HasKey("KEY_LOACAL_LOAD"))  // hat der Pc das key f�hre LoadGame aus
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
        
        if(!PlayerPrefs.HasKey("KEY_LOACAL_LOAD")) // wenn der Ke verf�gbar ist wird sie buttonevent ausgl��t
        {
                SelctedBuildIcon("S�ule");
        }
        counterText = scheisse.GetComponentsInChildren<Text>();
        counterText[0].text = gesamtHolz.ToString();
        counterText[1].text = GeStein.ToString();
    }

    void Update()
    {   
        if (buildingIsSelected) // wen ein button ansgew�hlt 
        {
            Vector3 worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // �bergebe die aktuell maus Pos
            worldpos.z = 0f;
            Vector3Int cp = iso.LocalToCell(worldpos); // maus Pos in Localisation zur der Zellen pos in ein int �bergeben
            
            Buildplan.transform.localPosition = iso.GetCellCenterLocal(cp);// Blaubause auf die Pos der Zelle geben
              
             if (Input.GetMouseButtonDown(0))  // wenn die linke maustaste gedr�kt ist
             {
                if(Buildplan.GetComponentInChildren<SpriteRenderer>().color == Buildplan.GetComponent<Coloring>().GetColor()) // un die fabe gleich die farbe Gr�n ist
                { 
                    GameObject build= Instantiate(Buildobject, Buildplan.transform.position, Quaternion.identity); // erzeugen eines geb�udes
                    build.transform.parent = this.transform; 
                    build.name = Buildobject.name; // setzen des geb�ude name
                    AllBuilds.Add(build); // speichen in der liste 
                    NewBuildingEigenschaft(build.name);
                    if (!canDisable) // wenn bauplan nicht entfernt werden kann
                    {
                        Buildplan.SetActive(false); // dann deaktiviere Blaupause
                        buildingIsSelected = false; // button ist aosgw�hlt is false
                        canDisable = true; // baublan kann entfernt werden
                    }
                }         
             }
             else if (Input.GetMouseButtonDown(1)&& canDisable) // wenn rechte maustaste gedr�ckt und canDisabel wahr 
             {
                 Buildplan.SetActive(false);  // deaktiviere bauplan
                 buildingIsSelected = false; // gab�detype ist ausgaw�hlt falsch
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
            case "H�tte":if (currentMaxNuefus < MaxNuefus) {
                            currentMaxNuefus += 10;};break;
            case "J�ger":; break;
            case "Holzf�ller":; break;
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

    private bool Check(string filename) // �berpt�fung ob eine Datei existiert
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
            
            data.builded.Add(obj.name);  // eintrangen des namens in GameData des aktuellen Geb�ude
            data.buildpos.Add(obj.transform.position); // eintrangen der Pos in GameData des aktuellen Geb�ude
            if (obj.CompareTag("Lager")) 
            {
                data.storage.Add(obj.GetComponent<Slot>());
            }
         }
        string json = JsonUtility.ToJson(data); // GameData in eine Json umwandeln 
        
        SaveGame.Save<string>("appdata.ill",json); // �bergabe der Json mit Schl�ssel
        Debug.Log(json);
    }
    public void LoadGame() 
        {
            if (Check("appdata.ill")) //�berpr�fe ob datei vorhanden
            {
                string json = SaveGame.Load<string>("appdata.ill",false,"penis"); // setzen den schl�ssel ein und lande das den String in  json
                int i = 0;
                data = JsonUtility.FromJson<GameData>(json);                    // �bertrage den json string und Convertirung in eine GameData, ablegen der infos in Data

                foreach (string obj in data.builded)                            // foreach f�r alle gespeicherten geb�ude
                {
                    GameObject myobject = Instantiate(Resources.Load(obj) as GameObject, data.buildpos[i], Quaternion.identity);// erzeuge eines neuen Geb�udes sowie Pos
                    myobject.name = obj;                                        // name des geb�udes eintragen
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
    public void SelctedBuildIcon(string name)   // funktion wird aufgerufen wenn ein Baubutton gedr�ckt wird
    {
        switch (name)
        {
            case "S�ule":   Buildobject = Resources.Load("Bergfried") as GameObject; // �bergeben des perfabs von dem Ordner in Builobject
                            Buildplan = bluePrint[0];// erstes object von der liste blueprint in Buildplan �bergeben
                            Buildplan.SetActive(true); // aktiviere Buildplan
                            buildingIsSelected=true;break;

            case "Lager":   Buildobject = Resources.Load("Lager") as GameObject;
                            Buildplan = bluePrint[1];
                            Buildplan.SetActive(true);
                            buildingIsSelected = true; break;

            case "J�ger":   Buildobject = Resources.Load("J�ger") as GameObject;
                            Buildplan = bluePrint[2];
                            Buildplan.SetActive(true);
                            buildingIsSelected = true; break;

            case "H�tte":   Buildobject= Resources.Load("H�tte") as GameObject;
                            Buildplan = bluePrint[3];
                            Buildplan.SetActive(true);
                            buildingIsSelected = true; break;
        }
    }
}
