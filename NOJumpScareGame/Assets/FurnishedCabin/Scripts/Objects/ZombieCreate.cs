using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCreate : MonoBehaviour
{
    public GameObject zombieprefab;
    public GameObject[] create;
    public GameObject CSV;
    public GameObject gameManager;

    public float followZombies;
    public bool easyMode { get; private set; }

    private Pictures DeiCounts;
    private int num;

    private void OnEnable()
    {
        gameManager.GetComponent<GameManager>().ChangeEasyMode.RemoveListener(EasyMode);
        gameManager.GetComponent<GameManager>().ChangeEasyMode.AddListener(EasyMode);

        gameManager.GetComponent<GameManager>().ChangeNotEasyMode.RemoveListener(NotEasyMode);
        gameManager.GetComponent<GameManager>().ChangeNotEasyMode.AddListener(NotEasyMode);
    }

    void Start()
    {
        followZombies = CSV.GetComponent<CsvCoolTime>().followZombies;
        StartCoroutine(createZombie());
        DeiCounts = GameObject.Find("Pictures").GetComponent<Pictures>();
    }

    IEnumerator createZombie()
    {
        while (true)
        {
            if (easyMode)
                yield return new WaitForSeconds(Mathf.Infinity);
            if (!easyMode)
            yield return new WaitForSeconds(followZombies);

            num = Random.Range(0, 5);
            Instantiate(zombieprefab, create[num].transform.position, create[num].transform.rotation);
            zombieprefab.layer = 6;
            ++DeiCounts.setActiveCounts;
        }

    }

    void EasyMode()
    {
        StopAllCoroutines();
        easyMode = true;
        StartCoroutine(createZombie());
    }

    void NotEasyMode()
    {
        StopAllCoroutines();
        easyMode = false;
        StartCoroutine(createZombie());
    }

    void OnDisable()
    {
        gameManager.GetComponent<GameManager>().ChangeEasyMode.RemoveListener(EasyMode);
        gameManager.GetComponent<GameManager>().ChangeNotEasyMode.RemoveListener(NotEasyMode);
    }
}
