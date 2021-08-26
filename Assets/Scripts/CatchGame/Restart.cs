using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour {
    public static int PuntajeLvl1;
    public static int PuntajeLvl2;
    public static int PuntajeLvl3;
    public void RestartGame() {
        if (LevelSelectMountain.lvl1Entrar == true)
        {
            LevelSelectMountain.lvl1Superado = true;
            PuntajeLvl1 = Score.scoreCompartido;
        }
        else if (LevelSelectMountain.lvl2Entrar == true)
        {
            LevelSelectMountain.lvl2Superado = true;
            PuntajeLvl2 = Score.scoreCompartido;
        }
        else if (LevelSelectMountain.lvl3Entrar == true)
        {
            LevelSelectMountain.lvl3Superado = true;
            PuntajeLvl3 = Score.scoreCompartido;
        }
        SceneManager.LoadScene(13);
    }
}
