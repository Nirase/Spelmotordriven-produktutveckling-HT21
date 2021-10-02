using UnityEngine;

public class UpdateShader_Trails : MonoBehaviour
{
    void Update()
    {
        Shader.SetGlobalVector("PlayerPos", transform.position);
    }
}
