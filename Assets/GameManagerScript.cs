using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;
    public GameObject block2;
    public GameObject goal;
    public GameObject coin;
    public TextMeshProUGUI scoreText;
    public static int score = 0;
    public GameObject goalParticle;

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
        Screen.SetResolution(1920, 1080, false);

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

                    //UI�c�[���L�b�g�ɂ��ĕ���
                }
                if (map[y, x] == 2)
                {
                    goal.transform.position = position;
                }
                //�R�C��
                if (map[y, x] == 3)
                {
                    Instantiate(coin, position, Quaternion.identity);
                }
                //�S�[���ʒu�ݒ�
                if (map[y,x]==2)
                {
                    goal.transform.position = position;
                    goalParticle.transform.position = position;
                }
            }
        }
        //�w�i
        for(int y=0;y<lenY+5;y++)
        {
            for(int x=0;x<lenX;x++)
            {
                position.x = x;
                position.y = -y + 10;
                position.z = 3;
                Instantiate(block2, position, Quaternion.identity);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���N���A�ŃX�y�[�X�L�[�Ń^�C�g���ֈڍs
        if (GoalScript.isGameClear == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }

        scoreText.text = "SCORE" + score;
    }
}
