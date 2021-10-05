using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PositionSave : MonoBehaviour, ISaveable
{
    //[SerializeField] float[] position = { 0, 0, 0 };
    //[SerializeField] int level = 1;
    public object CaptureState()
    {
        
        return new SaveData
        {
            position = new float[]{
            transform.position.x,
            transform.position.y,
            transform.position.z
            }

            //level = level
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;

        transform.position = new Vector3(saveData.position[0], saveData.position[1], saveData.position[2]);
        //level = saveData.level;
    }

    [Serializable]
    private struct SaveData
    {
        public float[] position;
        //public int level;
    }
}
