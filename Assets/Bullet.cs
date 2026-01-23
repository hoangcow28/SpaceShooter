using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flySpeed;

    void Update()
    {
        var newPosition = transform.position;
        newPosition.y += Time.deltaTime * flySpeed;
        transform.position = newPosition;
    }
}
