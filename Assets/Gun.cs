using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public InputActionReference touche;

    public GameObject projectile;

    private void OnEnable()
    {
        touche.action.Enable();
        touche.action.performed += OnTouchePressed;
    }

    private void OnDisable()
    {
        touche.action.Disable();
        touche.action.performed -= OnTouchePressed;
    }

    private void OnTouchePressed(InputAction.CallbackContext obj)
    {
        print("Touche pressed!");
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
