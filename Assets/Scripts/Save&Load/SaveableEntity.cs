using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Saveable_Entity : MonoBehaviour
{
    [SerializeField] private string id = string.Empty;

    public string Id => id;

    [ContextMenu("Generate ID")]
    private void GenerateId() => id = System.Guid.NewGuid().ToString();
}
