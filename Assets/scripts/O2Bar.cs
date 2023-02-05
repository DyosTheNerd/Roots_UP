using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class O2Bar : MonoBehaviour
{
    public RectTransform innerBar;
    public GameObject percText;
    public GameObject playerObject;

    private float maxSize;

    private TextMeshProUGUI textcomp;
    private PlayerOxygenSystem _oxygenSystem;

    void Start()
    {
        maxSize = innerBar.sizeDelta.x;
        _oxygenSystem = playerObject.GetComponent<PlayerOxygenSystem>();
        textcomp = percText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        
        float currentO2 = _oxygenSystem.getCurrentO2();
        float maxO2 = _oxygenSystem.getMaxO2();

        float percentage = currentO2/maxO2;

        //innerBar = new Vector2(maxSize*percentage, innerBar.localScale.y);
        innerBar.sizeDelta = new Vector2(maxSize*percentage,innerBar.sizeDelta.y);
        textcomp.text = string.Format("Oxygen: {0}%", Mathf.CeilToInt(percentage*100));
    }

  
    
}
