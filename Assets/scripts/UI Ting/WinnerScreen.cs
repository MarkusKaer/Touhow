using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class WinnerScreen : NetworkBehaviour
{


    GameObject nMan;

    Network nM;


    public void Start()
    {
        nMan = GameObject.FindWithTag("NetworkManager");

        nM = nMan.GetComponent<Network>();
    }


    public void RestartButton()
    {

        nM.killNetwork();

        Invoke("Reload", 1);


    }

    void Reload()
    {
        SceneManager.LoadScene(0);

    }


    public void ExitButton()
    {
        Application.Quit();
    }



}
