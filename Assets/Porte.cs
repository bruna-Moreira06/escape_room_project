using UnityEngine;

public class Porte : MonoBehaviour
{
    public bool opened;

    public Transform pivot;
    public Transform openendReference;
    public Transform closedReference;
    public float speed;

    public void Open()
    {
        opened = true;
    }

    public void Close()
    {
        opened = false;
    }

    private void Update()
    {
        if (opened)
        {
            pivot.localRotation = Quaternion.Lerp(pivot.localRotation, openendReference.localRotation, Time.deltaTime * speed);
        }
        else
        {
            pivot.localRotation = Quaternion.Lerp(pivot.localRotation, closedReference.localRotation, Time.deltaTime * speed);
        }
    }
}
