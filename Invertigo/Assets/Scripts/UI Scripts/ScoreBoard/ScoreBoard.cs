using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScoreBoard : MonoBehaviour {

    public List<PlayerStats> players;
    public List<ScoreBoardScore> scores;
    public ScoreBoardScore template;
    public GameObject background;
    bool initd = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Gametype_Manager.GameOver && initd == false)
        {
            initd = true;
            background.SetActive(true);
            init();
        }
      /*  if (Input.GetKeyDown("p"))
        {
            //init();
        }
        if(Input.GetKeyDown("o"))
        {
            for (int i = 0; i < scores.Count; i++)
            {
                Destroy(scores[i].gameObject);
            }
            scores.Clear();
        }*/
	}

    void init()
    {
        bool[] slots = new bool[4];
        for (int j = 0; j < 4; j++)
        {
             for (int i = 0; i < players.Count; i++)
             {
                if (players[i].place == j)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (!slots[k])
                        {
                            slots[k] = true;
                            ScoreBoardScore temp = Instantiate(template, this.transform);
                            temp.transform.position -= new Vector3(0, 55 * k, 0);
                            temp.playerName = players[i].playername;
                            temp.score = players[i].score;
                            temp.place = players[i].place;

                            print(players[i].name + " " + players[i].place);

                            temp.playerName = players[i].playername;

                            if (players[i].deaths > 0)
                            {
                                temp.Kd = players[i].kills / players[i].deaths;
                            }
                            else
                            {
                                temp.Kd = players[i].kills;
                            }


                            scores.Add(temp);

                            k = 5;
                        }
                    }
                }
             }
        }
    }
}
