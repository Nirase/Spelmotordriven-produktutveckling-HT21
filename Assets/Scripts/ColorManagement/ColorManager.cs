using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public enum ColorRemapTYPE { PINK, CYAN, RED, GREEN, BLUE, YELLOW }

[GenerateHLSL(PackingRules.Exact, false)]
public class ColorManager : MonoBehaviour
{
    [SerializeField]
    float fadeTime = 1;
    [SerializeField] [ColorUsage(true, true)]
    Color colorRemapPINK;
    [SerializeField] [ColorUsage(true, true)]
    Color colorRemapCYAN;
    [SerializeField] [ColorUsage(true, true)]
    Color colorRemapRED;
    [SerializeField] [ColorUsage(true, true)]
    Color colorRemapGREEN;
    [SerializeField] [ColorUsage(true, true)]
    Color colorRemapBLUE;
    [SerializeField] [ColorUsage(true, true)]
    Color colorRemapYELLOW;

    float StrengthPINK = 0;
    float StrengthCYAN = 0;
    float StrengthRED = 0;
    float StrengthGREEN = 0;
    float StrengthBLUE = 0;
    float StrengthYELLOW = 0;

    void Awake()
    {
        Shader.SetGlobalFloat("_strengthPINK", StrengthPINK);
        Shader.SetGlobalFloat("_strengthCYAN", StrengthCYAN);
        Shader.SetGlobalFloat("_strengthRED", StrengthRED);
        Shader.SetGlobalFloat("_strengthGREEN", StrengthGREEN);
        Shader.SetGlobalFloat("_strengthBLUE", StrengthBLUE);
        Shader.SetGlobalFloat("_strengthYELLOW", StrengthYELLOW);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(UnlockColor(this, ColorRemapTYPE.PINK));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(UnlockColor(this, ColorRemapTYPE.CYAN));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(UnlockColor(this, ColorRemapTYPE.RED));
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(UnlockColor(this, ColorRemapTYPE.GREEN));
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            StartCoroutine(UnlockColor(this, ColorRemapTYPE.BLUE));
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            StartCoroutine(UnlockColor(this, ColorRemapTYPE.YELLOW));
        }
    }

    // Possible endless loop if unlock and lock routines are triggered at the same time
    public static IEnumerator UnlockColor(ColorManager colorManager, ColorRemapTYPE colorType)
    {
        switch (colorType)
        {
            case ColorRemapTYPE.PINK:
                while (colorManager.StrengthPINK < 1)
                {
                    Shader.SetGlobalFloat("_strengthPINK", colorManager.StrengthPINK);
                    Shader.SetGlobalColor("_colorRemapPINK", colorManager.colorRemapPINK);
                    colorManager.StrengthPINK += Time.deltaTime / colorManager.fadeTime;
                    colorManager.StrengthPINK = Mathf.Clamp(colorManager.StrengthPINK, 0, 1);
                    yield return new WaitForEndOfFrame();
                }
                break;
            case ColorRemapTYPE.CYAN:
                while (colorManager.StrengthCYAN < 1)
                {
                    Shader.SetGlobalFloat("_strengthCYAN", colorManager.StrengthCYAN);
                    Shader.SetGlobalColor("_colorRemapCYAN", colorManager.colorRemapCYAN);
                    colorManager.StrengthCYAN += Time.deltaTime / colorManager.fadeTime;
                    colorManager.StrengthCYAN = Mathf.Clamp(colorManager.StrengthCYAN, 0, 1);
                    yield return new WaitForEndOfFrame();
                }
                break;
            case ColorRemapTYPE.RED:
                while (colorManager.StrengthRED < 1)
                {
                    Shader.SetGlobalFloat("_strengthRED", colorManager.StrengthRED);
                    Shader.SetGlobalColor("_colorRemapRED", colorManager.colorRemapRED);
                    colorManager.StrengthRED += Time.deltaTime / colorManager.fadeTime;
                    colorManager.StrengthRED = Mathf.Clamp(colorManager.StrengthRED, 0, 1);
                    yield return new WaitForEndOfFrame();
                }
                break;
            case ColorRemapTYPE.GREEN:
                while (colorManager.StrengthGREEN < 1)
                {
                    Shader.SetGlobalFloat("_strengthGREEN", colorManager.StrengthGREEN);
                    Shader.SetGlobalColor("_colorRemapGREEN", colorManager.colorRemapGREEN);
                    colorManager.StrengthGREEN += Time.deltaTime / colorManager.fadeTime;
                    colorManager.StrengthGREEN = Mathf.Clamp(colorManager.StrengthGREEN, 0, 1);
                    yield return new WaitForEndOfFrame();
                }
                break;
            case ColorRemapTYPE.BLUE:
                while (colorManager.StrengthBLUE < 1)
                {
                    Shader.SetGlobalFloat("_strengthBLUE", colorManager.StrengthBLUE);
                    Shader.SetGlobalColor("_colorRemapBLUE", colorManager.colorRemapBLUE);
                    colorManager.StrengthBLUE += Time.deltaTime / colorManager.fadeTime;
                    colorManager.StrengthBLUE = Mathf.Clamp(colorManager.StrengthBLUE, 0, 1);
                    yield return new WaitForEndOfFrame();
                }
                break;
            case ColorRemapTYPE.YELLOW:
                while (colorManager.StrengthYELLOW < 1)
                {
                    Shader.SetGlobalFloat("_strengthYELLOW", colorManager.StrengthYELLOW);
                    Shader.SetGlobalColor("_colorRemapYELLOW", colorManager.colorRemapYELLOW);
                    colorManager.StrengthYELLOW += Time.deltaTime / colorManager.fadeTime;
                    colorManager.StrengthYELLOW = Mathf.Clamp(colorManager.StrengthYELLOW, 0, 1);
                    yield return new WaitForEndOfFrame();
                }
                break;
            default:
                break;
        }

        yield return new WaitForEndOfFrame();
    }
    public static IEnumerator LockColor(ColorManager colorManager, ColorRemapTYPE colorType)
    {
        switch (colorType)
        {
            case ColorRemapTYPE.PINK:
                while (colorManager.StrengthPINK > 0)
                {
                    Shader.SetGlobalFloat("_strengthPINK", colorManager.StrengthPINK);
                    colorManager.StrengthPINK -= Time.deltaTime / colorManager.fadeTime;
                    colorManager.StrengthPINK = Mathf.Clamp(colorManager.StrengthPINK, 0, 1);
                    yield return new WaitForEndOfFrame();
                }
                break;
            case ColorRemapTYPE.CYAN:
                while (colorManager.StrengthCYAN > 0)
                {
                    Shader.SetGlobalFloat("_strengthCYAN", colorManager.StrengthCYAN);
                    colorManager.StrengthCYAN -= Time.deltaTime / colorManager.fadeTime;
                    colorManager.StrengthCYAN = Mathf.Clamp(colorManager.StrengthCYAN, 0, 1);
                    yield return new WaitForEndOfFrame();
                }
                break;
            case ColorRemapTYPE.RED:
                while (colorManager.StrengthRED > 0)
                {
                    Shader.SetGlobalFloat("_strengthRED", colorManager.StrengthRED);
                    colorManager.StrengthRED -= Time.deltaTime / colorManager.fadeTime;
                    colorManager.StrengthRED = Mathf.Clamp(colorManager.StrengthRED, 0, 1);
                    yield return new WaitForEndOfFrame();
                }
                break;
            case ColorRemapTYPE.GREEN:
                while (colorManager.StrengthGREEN > 0)
                {
                    Shader.SetGlobalFloat("_strengthGREEN", colorManager.StrengthGREEN);
                    colorManager.StrengthGREEN -= Time.deltaTime / colorManager.fadeTime;
                    colorManager.StrengthGREEN = Mathf.Clamp(colorManager.StrengthGREEN, 0, 1);
                    yield return new WaitForEndOfFrame();
                }
                break;
            case ColorRemapTYPE.BLUE:
                while (colorManager.StrengthBLUE > 0)
                {
                    Shader.SetGlobalFloat("_strengthBLUE", colorManager.StrengthBLUE);
                    colorManager.StrengthBLUE -= Time.deltaTime / colorManager.fadeTime;
                    colorManager.StrengthBLUE = Mathf.Clamp(colorManager.StrengthBLUE, 0, 1);
                    yield return new WaitForEndOfFrame();
                }
                break;
            case ColorRemapTYPE.YELLOW:
                while (colorManager.StrengthYELLOW > 0)
                {
                    Shader.SetGlobalFloat("_strengthYELLOW", colorManager.StrengthYELLOW);
                    colorManager.StrengthYELLOW -= Time.deltaTime / colorManager.fadeTime;
                    colorManager.StrengthYELLOW = Mathf.Clamp(colorManager.StrengthYELLOW, 0, 1);
                    yield return new WaitForEndOfFrame();
                }
                break;
            default:
                break;
        }

        yield return new WaitForEndOfFrame();
    }
}
