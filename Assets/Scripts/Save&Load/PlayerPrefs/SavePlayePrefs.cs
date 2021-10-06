using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayePrefs : MonoBehaviour
{
    //[SerializeField] GameObject gameObject;
    //private IUnit unit;

    ////Vector3 playerPosition;

    //private void Awake()
    //{
    //    unit = unitGO.GetComponent<IUnit>();
    //}

    private void Update()
    {
        //Save
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 playerPos = transform.position;
            PlayerPrefs.SetFloat("X", playerPos.x);
            PlayerPrefs.SetFloat("Y", playerPos.y);
            PlayerPrefs.SetFloat("Z", playerPos.z);
            PlayerPrefs.Save();
            Debug.Log("Saved");
        }

        //Load
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (PlayerPrefs.HasKey("X"))
            {
                float playerPositionX = PlayerPrefs.GetFloat("X");
                float playerPositionY = PlayerPrefs.GetFloat("Y");
                float playerPositionZ = PlayerPrefs.GetFloat("Z");
                Vector3 playerPosition = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
                //transform.GetComponent<CharacterController>().enabled = false;
                transform.position = playerPosition;
                //transform.GetComponent<CharacterController>().enabled = true;

                Debug.Log("Load");
            }
           
        }
    }

    //[ContextMenu("Save")]
    //private void Save()
    //{
    //    Vector3 playerPos = unit.GetPosition();
    //    PlayerPrefs.SetFloat("playerPositionX", playerPos.x);
    //    PlayerPrefs.SetFloat("playerPositionY", playerPos.y);
    //    PlayerPrefs.SetFloat("playerPositionZ", playerPos.z);
    //    PlayerPrefs.Save();

    //}

    //[ContextMenu("Load")]
    //private void Load()
    //{
    //    float playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
    //    float playerPositionY = PlayerPrefs.GetFloat("playerPositionY");
    //    float playerPositionZ = PlayerPrefs.GetFloat("playerPositionZ");
    //    Vector3 playerPosition = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
    //    unit.SetPosition(playerPosition);

    //}

}
