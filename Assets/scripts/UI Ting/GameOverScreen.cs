using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class GameOverScreen : NetworkBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Spil");
    }

    public void ExitButton()
    {
        Application.Quit();
    }


}
