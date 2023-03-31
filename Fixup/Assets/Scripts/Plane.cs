using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Plane : MonoBehaviour
{
    public MeshRenderer Renderer;

    private void Start()
    {
        Renderer = Renderer ?? GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if ((Camera.main == null) || (Renderer == null))
        {
            return;
        }

        Bounds adjustedBounds = Renderer.bounds;
        adjustedBounds.center = Camera.main.transform.position + (Camera.main.transform.forward * (Camera.main.farClipPlane - Camera.main.nearClipPlane) * 0.5f);
        adjustedBounds.extents = new Vector3(0.1f, 0.1f, 0.1f);

        Renderer.bounds = adjustedBounds;
    }
}