using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class startgame : MonoBehaviour
{
    // Reference to the other script
    //public PlayerController playercontroller;
    public TextMeshProUGUI countText;
    public GameObject score;    
    public List<GameObject> pickups;
    public GameObject msg;
    public GameObject player;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(GameObject menu)
    {
        countText.text = "Count: 0";
        foreach (GameObject item in pickups)
        {
            item.SetActive(true);
        }
        msg.SetActive(false);
        menu.SetActive(false);

        //if (playercontroller != null)
        //{ ApplicationConstants.count = 0; }
        ApplicationConstants.count = 0;

        score.SetActive(true);
        player.transform.position = new Vector3(0,1,0);
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        player.SetActive(true);

        enemy.transform.position = new Vector3(1.61f, 0, -12.56f);


    }
    public void CloseHelp(GameObject helppanel)
    {
        helppanel.SetActive(false);
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
    public void Help(GameObject helppanel)
    {
        helppanel.SetActive(true);
    }
}
