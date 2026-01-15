using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rigibody;
    public float initialForce;

    public void Start()
    {
        rigibody.AddForce(transform.forward * initialForce, ForceMode.Impulse);
    }
}
