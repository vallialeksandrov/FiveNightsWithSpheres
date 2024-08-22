using UnityEngine;

public class AutoChangeScenes : MonoBehaviour
{
    private Scenes scenes;
    private int delay = 15;

    private void Start()
    {
        scenes = GetComponent<Scenes>();
        Invoke(nameof(ChangeScene), delay);
    }

    private void ChangeScene()
    {
        scenes.ChangeScenes(0);
    }
}
