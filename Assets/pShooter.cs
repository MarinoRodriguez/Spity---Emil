using UnityEngine;

public class pShooter : MonoBehaviour
{
    public Transform prefab;
    public Transform barrel;

    Transform folder;
    private void Start()
    {
        folder = new GameObject("Folder").transform;
    }
    public void Shoot()
    {
        var b = Instantiate(prefab, folder);

        b.SetPositionAndRotation(barrel.position, barrel.rotation);

        b.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300);
    }
}
