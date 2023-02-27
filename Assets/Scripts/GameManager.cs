using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject starPrefab;
    public int starNum = 5;
    public int minX, maxX, minY, maxY;

    public List<GameObject> starObjects;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < starNum; i++)
        {
            Vector3 starPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            GameObject newStar = Instantiate(starPrefab, starPos, Quaternion.identity);
            starObjects.Add(newStar);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SceneManager.LoadScene(0);
        //}
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(0);
    }

}
