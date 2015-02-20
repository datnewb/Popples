using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GraphicsComponentsManager : MonoBehaviour {

    public float currentDropSpeed;
    public GameObject[] movingBG;

    public GameObject comboPoofPrefab, popPrefab;
    public RectTransform comboTextTransform;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(gameManager.CurrentGameState == GameState.Game)
        {
            ScrollBG();
        }
    }

    public void ShakeScreen()
    {
        GameObject gameScreen = GameObject.Find("Game Screen");
        gameScreen.GetComponent<Animator>().Play("ScreenShake");
        
    }

    public void PopGraphics(RectTransform bubbleTransform, Sprite bubbleImage)
    {
        GameObject instance = Instantiate(popPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        instance.transform.SetParent(GameObject.Find("Game Canvas").transform);
        instance.transform.Find("PopImage").GetComponent<Image>().sprite = bubbleImage;
        instance.GetComponent<RectTransform>().anchoredPosition = bubbleTransform.anchoredPosition;
        instance.transform.SetParent(GameObject.Find("UI Canvas").transform);
        Destroy(instance, .5f);
    }

    public void AddComboGraphics(uint combo)
    {
        GameObject instance = Instantiate(comboPoofPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        instance.transform.SetParent(GameObject.Find("UI Canvas").transform);
        instance.GetComponent<RectTransform>().anchoredPosition = comboTextTransform.anchoredPosition;
        Destroy(instance, .5f);
        
    }

    void ScrollBG()
    {
        for(int i = 0; i<movingBG.Length; i++)
        {
            movingBG[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(movingBG[i].GetComponent<RectTransform>().anchoredPosition.x, 
                movingBG[i].GetComponent<RectTransform>().anchoredPosition.y - currentDropSpeed);

            if(movingBG[i].GetComponent<RectTransform>().anchoredPosition.y <= -240)
            {
                movingBG[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(movingBG[i].GetComponent<RectTransform>().anchoredPosition.x,
                    movingBG[i == 0 ? 1 : 0].GetComponent<RectTransform>().anchoredPosition.y + 480);
            }
        }
    }
}
