using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;
    //public GameObject goal;

    int[,] map =
    {
          {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
          {1,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,3,3,0,0,0,0,1 },
          {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,3,0,0,0,1 },
          {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,1,1,1,0,0,0,1,1,0,0,0,0,0,2,1 },
          {1,0,0,0,0,0,0,3,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
          {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
          {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
          {1,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
          {1,0,0,0,0,1,1,1,0,0,0,3,0,0,0,1,1,1,1,1,0,0,0,0,3,0,3,0,0,0,0,0,0,3,0,0,0,0,0,1 },
          {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
    };

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = Vector3.zero;
        int lenY = map.GetLength(0);
        int lenX = map.GetLength(1);

        for (int x = 0; x < 40; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                position.x = x;
                position.y = -y + 5;

                if (map[y, x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);

                    //UIツールキットについて聞く
                }
                //if (map[y, x] == 2)
                //{
                //    goal.transform.position = position;
                //}
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
