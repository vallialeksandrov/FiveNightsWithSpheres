using UnityEngine;

public class ControlDoors : Control
{
    [SerializeField] private Animator doorAnim;
    [SerializeField] private AudioSource doorAudioSource;

    public bool IsClose;

    private void Start() => ChangeButtonColor(Color.red);

    protected override void ControlObjects()
    {
        if (IsClose == false)
        {        
            IsClose = true;
            ChangeButtonColor(Color.green);
        }
        else
        {
            IsClose = false;
            ChangeButtonColor(Color.red);
        }

        doorAnim.SetBool("isOpen", IsClose);
        doorAudioSource.Play();

        onEnableObject?.Invoke(IsClose, 0.15f);
    }

    public void DisableControlDoors()
    {
        ChangeButtonColor(Color.red);

        IsClose = false;
        doorAnim.SetBool("isOpen", false);      
        Destroy(this);
    }
}
