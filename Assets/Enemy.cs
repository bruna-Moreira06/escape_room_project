using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private Transform _playerCamera;
    public Rigidbody rigibody;
    public float vitesse;
    public Animator animator;
    public float distanceToStop;

    public int vie;

    public void Damage()
    {
        vie--;
        if (vie <= 0)
        {
            animator.SetBool("Dead", true);
            Destroy(gameObject, 2f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            print("Enemy hit");
            Damage();
        }
    }

    void Start()
    {
        _playerCamera = Camera.main.transform;
    }

    void Update()
    {
        Vector3 directionToPlayer = _playerCamera.position - transform.position;
        directionToPlayer.y = 0;
        transform.rotation = Quaternion.LookRotation(directionToPlayer);
        
        float distanceToPlayer = Vector3.Distance(transform.position, _playerCamera.position);

        if (distanceToPlayer >= distanceToStop)
        {
            Vector3 movement = directionToPlayer.normalized * vitesse;
            rigibody.linearVelocity = movement + new Vector3(0, rigibody.linearVelocity.y, 0);

            animator.SetBool("Moving", true);
        }else
        {
            rigibody.linearVelocity = new Vector3(0, rigibody.linearVelocity.y, 0);
            animator.SetBool("Moving", false);
        }
    }
}
