using UnityEngine;

public class FlyPathAgent : MonoBehaviour
{
    public FlyPath flyPath;
    public float flySpeed = 5f;

    private int nextIndex = 0;

    void Update()
    {
        if (flyPath == null) return;

        if (nextIndex >= flyPath.waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        Transform target = flyPath.waypoints[nextIndex].transform;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            flySpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            nextIndex++;
        }
    }
}