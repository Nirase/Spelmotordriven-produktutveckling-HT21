using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class UpdateShaderIceTrails : MonoBehaviour
{
    [SerializeField] RenderTexture iceTrailsRenderTexture;
    [SerializeField] Transform followTarget;

    void Awake()
    {
        Shader.SetGlobalTexture("IceTrailsTexture", iceTrailsRenderTexture);
        Shader.SetGlobalFloat("IceTrailsOrthoCamSize", GetComponent<Camera>().orthographicSize);
    }

    void Update()
    {
        transform.position = followTarget.transform.position + new Vector3(0, 5, 0);
        Shader.SetGlobalVector("IceTrailsOrthoCamPos", transform.position);
    }
}
