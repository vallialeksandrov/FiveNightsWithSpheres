using UnityEngine;

public class AppleMacButton : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private Texture[] textures;

    private int currentTexture = 0;

    private void Start() => ChangeTexture();

    private void OnMouseDown()
    {
        if (currentTexture == textures.Length)
            currentTexture = 0;

        ChangeTexture();
    }

    private void ChangeTexture()
    {
        material.mainTexture = textures[currentTexture];
        material.SetTexture("_EmissionMap", textures[currentTexture]);
        currentTexture++;
    }
}
