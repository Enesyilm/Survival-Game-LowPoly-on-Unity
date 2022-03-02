using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
namespace EnesTalhaYılmaz_Fps.Level{

public class LevelCreator : MonoBehaviour
{
    [SerializeField] int numberOfLevels;
    [SerializeField] int SpawnOffSet;
    [SerializeField] Text LevelText;
    [SerializeField] GameObject LevelCompleteText;
    EnesTalhaYılmaz_Fps.EnemyPirates.SpawnEnemies.CreateTargets createTargets;
    int levelCounter=0;
    public int NumberOfLevels   // property
    {
        get { return numberOfLevels; }
        set { numberOfLevels = value; }
    }
  public int LevelCounter   // property
    {
        get { return levelCounter; }
        set { levelCounter = value; }
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        createTargets=GetComponent<EnesTalhaYılmaz_Fps.EnemyPirates.SpawnEnemies.CreateTargets>();
    }

    // Update is called once per frame
    void Update()
    {
        // createTargets.UpdateTargetText();
        // UpdateLevelText();
        createTargets.SpawnTargets();
        
        
    }
    public IEnumerator ShowLevelStatusText(){
        LevelCompleteText.SetActive(true);
        
        if(numberOfLevels>levelCounter){
            LevelCompleteText.GetComponent<TextMeshProUGUI>().text="Level "+ levelCounter+" has been completed !!";
            
            yield return new WaitForSeconds(4f);
            LevelCompleteText.SetActive(false);}
        else{
            LevelCompleteText.GetComponent<TextMeshProUGUI>().text="Game has been completed !!";
        }
        

    }
    
    public void UpdateLevelText(){
        LevelText.text= levelCounter.ToString();

    }
}


}
