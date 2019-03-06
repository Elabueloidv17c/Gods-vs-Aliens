using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerList : MonoBehaviour {
    /**
     * ************************
     * * This is a list that contains references to all players on the scene
     * * its used by anything that needs to know anything bout the players
     * ************************
     * */
    //public List<GameObject> player_list;
    public GameObject[] arrPlyrList;

    void Start () {
        //arrPlyrList = player_list.ToArray();
    }

    public GameObject[] getPlayerArr()
    {
        return arrPlyrList;
    }
	
}
