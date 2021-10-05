using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSave : MonoBehaviour, ISaveable
{
    public object CaptureState()
    {
        return new SaveData
        {
            position = transform.position
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;

        transform.position = saveData.position;
    }

    [System.Serializable]
  private struct SaveData
    {
        public Vector3 position;
    }
}
