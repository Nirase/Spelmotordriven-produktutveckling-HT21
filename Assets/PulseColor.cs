using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseColor : MonoBehaviour
{
    [SerializeField] [ColorUsage(true, true)] Color colorRemap;
    [SerializeField] string tag;
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] float delay = 1f;

    [ColorUsage(true, true)] Color defaultColor;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            StartCoroutine(Pulse(other));
        }
    }

    IEnumerator Pulse(Collider other)
    {
        Renderer renderer = other.GetComponent<Renderer>();

        defaultColor = renderer.material.GetColor("_DefaultColor");
        float timer = 0;

        while (timer < fadeDuration)
        {
            Color color = Color.Lerp(defaultColor, colorRemap, timer / fadeDuration);
            renderer.material.SetColor("_DefaultColor", color);

            timer += Time.deltaTime;
            yield return null;
        }

        renderer.material.SetColor("_DefaultColor", colorRemap);
        timer = 0;

        while (timer < delay)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0;

        while (timer < fadeDuration)
        {
            Color color = Color.Lerp(colorRemap, defaultColor, timer / fadeDuration);
            renderer.material.SetColor("_DefaultColor", color);

            timer += Time.deltaTime;
            yield return null;
        }

        renderer.material.SetColor("_DefaultColor", defaultColor);
    }
}
