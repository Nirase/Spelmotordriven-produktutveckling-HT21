using UnityEngine;


public class UpdateShader_Trails : MonoBehaviour
{
    [SerializeField] RenderTexture renderTexture;
    [SerializeField] Transform playerTarget;


    void Awake()
    {
        Camera orthoCam = GetComponent<Camera>();
        Shader.SetGlobalTexture("TrailTexture", renderTexture);
        Shader.SetGlobalFloat("TrailOrthoCamSize", orthoCam.orthographicSize);

    }
    void Update()
    {   
        transform.position = playerTarget.transform.position + new Vector3(0, 10, 0);
        Shader.SetGlobalVector("TrailOrthoCamPos", transform.position);
    }
} 
