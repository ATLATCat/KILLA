using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThanksPlaying : MonoBehaviour
{
    public void quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // 어플리케이션 종료
        #endif
    }

        public void restart()
    {
        SceneManager.LoadScene("Intro1");
    }
}
