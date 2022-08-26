using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayingZombie : MonoBehaviour
{
    private Pictures DieCounts;

    private float layingZombies;

    public GameObject gameManager;
    public GameObject zombieprefab;
    public GameObject[] create;
    public GameObject CSV;

    public bool easyMode { get; private set; }

    private void OnEnable()
    {
        gameManager.GetComponent<GameManager>().ChangeEasyMode.RemoveListener(EasyMode);
        gameManager.GetComponent<GameManager>().ChangeEasyMode.AddListener(EasyMode);


        gameManager.GetComponent<GameManager>().ChangeNotEasyMode.RemoveListener(NotEasyMode);
        gameManager.GetComponent<GameManager>().ChangeNotEasyMode.AddListener(NotEasyMode);
    }

    void Start()
    {
        easyMode = false;
        layingZombies = CSV.GetComponent<CsvCoolTime>().layingZombies;
        StartCoroutine(layingZombie());
        DieCounts = GameObject.Find("Pictures").GetComponent<Pictures>();
        Debug.Log(layingZombies);
    }

    IEnumerator layingZombie()
    {
        while (true)
        {
            if (easyMode)
                yield return new WaitForSeconds(Mathf.Infinity);
            if (!easyMode)
                yield return new WaitForSeconds(layingZombies);

            int num;
            num = Random.Range(0, 2);
            Instantiate(zombieprefab, create[num].transform.position, create[num].transform.rotation);
            zombieprefab.layer = 6;
            ++DieCounts.setActiveCounts;

        }

    }

    void EasyMode()
    {
        StopAllCoroutines();
        easyMode = true;
        StartCoroutine(layingZombie());
    }

    void NotEasyMode()
    {
        StopAllCoroutines();
        easyMode = false;
        StartCoroutine(layingZombie());
    }

    void OnDisable()
    {
        gameManager.GetComponent<GameManager>().ChangeEasyMode.RemoveListener(EasyMode);
        gameManager.GetComponent<GameManager>().ChangeNotEasyMode.RemoveListener(NotEasyMode);
    }
}
