using TMPro;
using UnityEngine;

public class GoalPrefab : MonoBehaviour
    
{
    [SerializeField]
    TextMeshProUGUI goalText;

  
    //Is trieer‚É”½‰‚ª‚ ‚é‚©‚Ç‚¤‚©
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        // Canvas‚ÉƒS[ƒ‹‚µ‚½î•ñ‚ğ‘—‚é
        goalText.enabled =true;

    }
} 
