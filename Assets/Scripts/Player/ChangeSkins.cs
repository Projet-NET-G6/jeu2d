using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkins : MonoBehaviour
{
    public GameObject skinsPanel;

    public GameObject player;

    //Si entre dans la porte du choix de Skins alors active le panel de skins
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            skinsPanel.gameObject.SetActive(true);
        }
    }
    //Si sort dans la porte du choix de Skins alors désactive le panel de skins
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            skinsPanel.gameObject.SetActive(false);
        }
    }

    //Set le skins du joueur
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
    
    //désactive le panel de skins et appel la methode ChangePlayerInMenu (voir PlayerSelected.cs)
    void ResetPlayerSkin()
    {
        skinsPanel.gameObject.SetActive(false);
        player.GetComponent<PlayerSelected>().ChangePlayerInMenu();
    }
}
