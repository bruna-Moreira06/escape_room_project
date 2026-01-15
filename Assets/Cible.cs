using UnityEngine;

public class Cible : MonoBehaviour
{
    public int vie;
    public float shakeIntensity;
    public float shakeFrequency;
    public float shakeDuration;

    private Vector3 _basePosition;
    private float shakeTimer;

    private void Start()
    {
        _basePosition = transform.position;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            float time = Time.time * shakeFrequency;

            Vector3 randomPosition = new Vector3(
                (Mathf.PerlinNoise(time, time + 10) - 0.5f) * shakeIntensity,
                (Mathf.PerlinNoise(time + 100, time + 200) - 0.5f) * shakeIntensity,
                (Mathf.PerlinNoise(time + 1000, time + 2000) - 0.5f) * shakeIntensity
            );

            transform.position = _basePosition + randomPosition;
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            transform.position = _basePosition;
        }
    }

    private void Damage()
    {
        vie--;
        shakeTimer = shakeDuration;
        if (vie <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            print("Cible hit");
            Damage();
        }
    }
}
