using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkins : MonoBehaviour
{
    public GameObject skinsPanel;

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            skinsPanel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            skinsPanel.gameObject.SetActive(false);
        }
    }
    
    public void SetPlayerFrog()
    {
        PlayerPrefs.SetString("PlayerSelected", "FrogPlayer");
        ResetPlayerSkin();
    }
    public void SetPlayerMask()
    {
        PlayerPrefs.SetString("PlayerSelected", "MaskPlayer");
        ResetPlayerSkin();
    }
    public void SetPlayerPink()
    {
        PlayerPrefs.SetString("PlayerSelected", "PinkPlayer");
        ResetPlayerSkin();
    }
    public void SetPlayerVirtual()
    {
        PlayerPrefs.SetString("PlayerSelected", "VirtualPlayer");
        ResetPlayerSkin();
    }
    
    void ResetPlayerSkin()
    {
        skinsPanel.gameObject.SetActive(false);
        player.GetComponent<PlayerSelected>().ChangePlayerInMenu();
    }
}
