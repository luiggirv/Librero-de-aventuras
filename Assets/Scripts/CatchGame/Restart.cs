using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour {
    public static int PuntajeLvl1;
    public static int PuntajeLvl2;
    public static int PuntajeLvl3;
    public void RestartGame() 
    {
        LevelSelectEcosistema.lvl1MountainEntrar = false;
        LevelSelectEcosistema.lvl2MountainEntrar = false;
        LevelSelectEcosistema.lvl3MountainEntrar = false;
        LevelSelectEcosistema.lvl4MountainEntrar = false;
        LevelSelectEcosistema.lvl5MountainEntrar = false;
        LevelSelectEcosistema.lvl6MountainEntrar = false;
        LevelSelectEcosistema.lvlTutorialMountain = false;

        SceneManager.LoadScene(13);
    }
}
