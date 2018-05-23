using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour {

    public bool trainMode, exit;

	public void OnClicked()
    {
        if (trainMode)
        {
            SceneManager.LoadScene("Scenes/training");
        }
        else if (exit)
        {
            SceneManager.LoadScene("Scenes/Menu");
        }
        else
        {
            SceneManager.LoadScene("Scenes/mainGame");
        }
    }
}
