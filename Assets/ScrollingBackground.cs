using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public Renderer bgRenderer;
    public float speed = 0.2f;

    void Update()
    {
        bgRenderer.material.mainTextureOffset +=
            new Vector2(0, speed * Time.deltaTime);
    }
}