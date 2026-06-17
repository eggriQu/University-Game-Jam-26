using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTyping : MonoBehaviour
{
    [SerializeField] private float typeSpeed = 0.1f;
    [SerializeField] private string fullText;
    private string currentText;

    public void PlayDialogue(string FTInput)
    {
        StartCoroutine(TypeDialogue(FTInput));
    }

    IEnumerator TypeDialogue(string FTDisplay)
    {
        fullText = FTDisplay;
        for (int i = 0; i < fullText.Length + 1; i++)
        {
            currentText = fullText.Substring(0,i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}
