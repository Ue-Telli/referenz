
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu:MonoBehaviour
{
    private string levelKey = "KEY_LOCAL_PLACE";
   // private bool isLoading = false;

    public void NewGame() 
    {
        PlayerPrefs.SetInt(levelKey, 1);
        PlayerPrefs.DeleteKey("KEY_LOACAL_LOAD");
        SceneManager.LoadScene(1);

    }
    public void Fortsetzen() 
    {

        PlayerPrefs.SetInt("KEY_LOACAL_LOAD", 1);
        SceneManager.LoadScene(PlayerPrefs.GetInt(levelKey));

    }


}
