using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("References")]
    public Transform turretPipe;
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Materials")]
    public Material matRed;
    public Material matBlue;
    public Material matYellow;
    public Material matGreen;

    private int currentColorIndex = 0;
    private Material currentMaterial;
    private Renderer pipeRenderer;

    void Start()
    {
        if (turretPipe != null)
        {
            pipeRenderer = turretPipe.GetComponent<Renderer>();
        }

        currentMaterial = matRed;
        UpdatePipeColor();
    }

    void Update() // Method to handle input for changing color and shooting
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentColorIndex = currentColorIndex + 1; // Increment the color index to cycle through colors
            if (currentColorIndex > 3)
            {
                currentColorIndex = 0;
            }

            if (currentColorIndex == 0) currentMaterial = matRed;
            if (currentColorIndex == 1) currentMaterial = matBlue;
            if (currentColorIndex == 2) currentMaterial = matYellow;
            if (currentColorIndex == 3) currentMaterial = matGreen;

            UpdatePipeColor(); // Update the color of the turret pipe based on the current material
        }
 
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

    void UpdatePipeColor() // Method to update the color of the turret pipe
    {
        if (pipeRenderer != null)
        {
            pipeRenderer.material = currentMaterial;
        }
    }

    void Shoot() // Method to instantiate a bullet and set its material
    {
        if (bulletPrefab != null && firePoint != null) 
        {

            GameObject spawnedBullet = Instantiate(bulletPrefab, firePoint.position, turretPipe.rotation);

            Renderer bulletRenderer = spawnedBullet.GetComponent<Renderer>();
            if (bulletRenderer != null)
            {
                bulletRenderer.material = currentMaterial;
            }
        }
    }
}
