using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveableEntity : MonoBehaviour
{
    [SerializeField] private string id = string.Empty;

    public string Id => id;

    [ContextMenu("Generate ID")]
    private void GenerateId() => id = System.Guid.NewGuid().ToString();

    public object CaptureState()
    {
        Dictionary<string, object> state = new Dictionary<string, object>();

        foreach (var saveable in GetComponents<ISaveable>())
        {
            state[saveable.GetType().ToString()] = saveable.CaptureState();
        }

        return state;
    }

    public void RestoreState(object state)
    {
        Dictionary<string, object> stateDictionary = (Dictionary<string, object>)state;

        foreach (var saveable in GetComponents<ISaveable>())
        {
            string typeName = saveable.GetType().ToString();

            if (stateDictionary.TryGetValue(typeName, out object value))
                saveable.RestoreState(value);
        }
    }
}
