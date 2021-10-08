using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaySomething : MonoBehaviour
{
    [SerializeField] private TextMesh talkText;
    private string textToSay = "Crunch!, ups!, hey!, Yippie!, Yummie!";
    private int 
        previousOno,
        isCleaningText;

    public void Talk()
    {
        char[] separators = new char[] { ' ', ',' };
        string[] onomatos = textToSay.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
        int actualOnomato = Random.Range(0, 5);
        while (actualOnomato == previousOno)
        {
            actualOnomato = Random.Range(0, 5);
        }
        previousOno = actualOnomato;
        talkText.text = onomatos[actualOnomato];
        StartCoroutine(ClearText(1.5f));
    }

    private IEnumerator ClearText(float seconds)
    {
        isCleaningText++;
        yield return new WaitForSeconds(seconds);
        if (isCleaningText == 1)
        {
            talkText.text = "";
        }
        isCleaningText--;
    }
}
