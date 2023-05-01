using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text Spt;
    [SerializeField] private TMP_Text Set;
    [SerializeField] private GameObject PResult;
    [SerializeField] private GameObject PWin;
    [SerializeField] private GameObject PLose;
    [SerializeField] private int maxScore=12;
    [SerializeField] private GameObject Ppause;
    public int Sp=0;
    public int Se=0;

    public PlayerMovement Player;
    public List<EnemyAI> Enemy;
    public GameObject Ball;

    public List<Sprite> skin;

    public Transform ppf;
    public Transform bpf;

    public bool start=false;
    public bool endgame;

    void Start()
    {
        instanceObj();
        endgame = false;
        int randSriteA=Random.RandomRange(0,skin.Count);
        int randSriteB=Random.RandomRange(0,skin.Count);

        while (randSriteB==randSriteA)
        {
            randSriteB = Random.RandomRange(0, skin.Count);
        }
        Player.PlayerSkin.sprite=skin[randSriteA];
        foreach (var e in Enemy)
        {
            e.skin.sprite = skin[randSriteB];
        }
    }
    void Update()
    {
        
        if (endgame==false)
        {
            if (start == false)
            {
                if (endgame == false)
                {
                    instanceObj();
                }
            }
            Spt.text = Sp.ToString();
            Set.text = Se.ToString();
            if (Sp == maxScore)
            {
                PResult.SetActive(true);
                PWin.SetActive(true);
                endgame = true;
            }
            else if (Se == maxScore)
            {
                PResult.SetActive(true);
                PLose.SetActive(true);
                endgame = true;
            }
        }
    }
    public void navigasi(string SceneName)
    {
        StartCoroutine(gotoScene(SceneName, 0.5f));
    }
    public void instanceObj()
    {
        foreach (var e in Enemy)
        {
            e.transform.position = e.epf.position;
        }
        Player.transform.position = ppf.position;
        Ball.transform.position = bpf.position;
        Ball.transform.rotation = bpf.rotation;
        StartCoroutine(wait(1f));
    }
    public IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        start = true;
    }

    IEnumerator gotoScene(string SceneName,float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(SceneName);
    }

    public void pauseBtn()
    {
        Time.timeScale=0;
        Ppause.SetActive(true);
    }
    public void resume()
    {
        Time.timeScale=1;
        Ppause.SetActive(false);
    }
}
