using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GraphicsComponentsManager : MonoBehaviour {

    public float currentDropSpeed;
    public GameObject[] movingBG;

    public GameObject comboPoofPrefab, popPrefab, doubleScorePrefab, freezeTimePrefab, comboShieldPrefab;
    public RectTransform comboTextTransform;

    private GameManager gameManager;

    public bool doubleScoreInEffect, freezeTimeInEffect, comboShieldInEffect;
    public GameObject doubleScoreInEffectGraphics, freezeTimeInEffectGraphics, comboShieldInEffectGraphics, timeSlider;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(gameManager.CurrentGameState == GameState.Game)
        {
            ScrollBG();
            doubleScoreInEffectGraphics.SetActive(true);
            freezeTimeInEffectGraphics.SetActive(true);
            comboShieldInEffectGraphics.SetActive(true);

            if(doubleScoreInEffect)
            {
                doubleScoreInEffectGraphics.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(doubleScoreInEffectGraphics.GetComponent<CanvasGroup>().alpha, 1, Time.deltaTime);
            }
            else
            {
                doubleScoreInEffectGraphics.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(doubleScoreInEffectGraphics.GetComponent<CanvasGroup>().alpha, 0, Time.deltaTime);
            }
            if(freezeTimeInEffect)
            {
                timeSlider.GetComponent<Image>().color = Color.Lerp(timeSlider.GetComponent<Image>().color, new Color(8, 189, 255), 3 * Time.deltaTime);
                freezeTimeInEffectGraphics.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(doubleScoreInEffectGraphics.GetComponent<CanvasGroup>().alpha, 1, Time.deltaTime);
            }
            else
            {
                timeSlider.GetComponent<Image>().color = Color.Lerp(timeSlider.GetComponent<Image>().color, new Color(0, 255, 0), 3 * Time.deltaTime);
                freezeTimeInEffectGraphics.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(doubleScoreInEffectGraphics.GetComponent<CanvasGroup>().alpha, 0, Time.deltaTime);
            }
            if(comboShieldInEffect)
            {
                comboShieldInEffectGraphics.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(comboShieldInEffectGraphics.GetComponent<CanvasGroup>().alpha, 1, Time.deltaTime);
            }
            else
            {
                comboShieldInEffectGraphics.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(comboShieldInEffectGraphics.GetComponent<CanvasGroup>().alpha, 0, Time.deltaTime);
            }
        }
        else
        {
            doubleScoreInEffectGraphics.SetActive(false);
            freezeTimeInEffectGraphics.SetActive(false);
            comboShieldInEffectGraphics.SetActive(false);
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
        comboTextTransform.gameObject.GetComponent<Animator>().Play("ComboShake");
        Destroy(instance, .5f);
        
    }

    public void AddPowerUpGraphics(string powerUp, GameObject bubble)
    {
        GameObject prefab = null;
        switch(powerUp)
        {
            case "DoubleScore":
                prefab = doubleScorePrefab;
                break;
            case "FreezeTime":
                prefab = freezeTimePrefab;
                break;
            case "ComboShield":
                prefab = comboShieldPrefab;
                break;
        }

        GameObject instance = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
        instance.transform.SetParent(GameObject.Find("Game Canvas").transform);
        instance.GetComponent<RectTransform>().localScale = bubble.GetComponent<RectTransform>().localScale;
        instance.GetComponent<RectTransform>().anchoredPosition = bubble.GetComponent<RectTransform>().anchoredPosition;
        instance.transform.SetParent(bubble.transform);
        
    }

    public void OnPopPowerUp(Bubble bubble)
    {
        GameObject prefab = null;
        switch (bubble.effect)
        {
            case "DoubleScore":
                prefab = doubleScorePrefab;
                break;
            case "FreezeTime":
                prefab = freezeTimePrefab;
                break;
            case "ComboShield":
                prefab = comboShieldPrefab;
                break;
            case "":
                break;
        }

        GameObject instance = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
        instance.transform.SetParent(GameObject.Find("Game Canvas").transform);
        instance.GetComponent<RectTransform>().localScale = bubble.GetComponent<RectTransform>().localScale;
        instance.GetComponent<RectTransform>().anchoredPosition = bubble.GetComponent<RectTransform>().anchoredPosition;
        instance.GetComponent<Animator>().Play("Explode");
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
                    movingBG[i == 0 ? 1 : 0].GetComponent<RectTransform>().anchoredPosition.y + 475);
            }
        }
    }
}
