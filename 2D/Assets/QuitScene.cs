using UnityEngine;

public class QuitScene : MonoBehaviour
{
    public void QuitButton()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}