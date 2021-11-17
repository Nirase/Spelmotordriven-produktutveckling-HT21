using UnityEngine.VFX;
using UnityEngine;

public class vfxPlayRate : MonoBehaviour
{
    // Start is called before the first frame update   public VisualEffect vfx;
     
    VisualEffect vfx;
    [Range(0,1)] public float playRate;
 
    void Start()
    {
        vfx = GetComponent<VisualEffect>();
    }
 
    void Update()
    {
        vfx.playRate = playRate;
    }
}
