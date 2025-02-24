using UnityEngine;
using System.Collections;

public class SkyControl : MonoBehaviour
{
    public Material material1;
    public Material material2;

    public Color color1;
    public Color color2;

    private Color originalColor1;
    private Color originalColor2;

    public float startTime = 62f; //Time before color change starts.
    public float changeDuration = 5f;  //Duration of the color change.
    public float revertTime = 90f; //Time before reverting starts.

    private void Start()
    {
        
        originalColor1 = material1.color;
        originalColor2 = material2.color;

        //Start the process
        StartCoroutine(ColorChangeRoutine());
    }

    private IEnumerator ColorChangeRoutine()
    {
        //Wait before starting the color change.
        yield return new WaitForSeconds(startTime);

        //Lerp to target colors.
        yield return StartCoroutine(LerpColor(material1, originalColor1, color1, changeDuration));
        yield return StartCoroutine(LerpColor(material2, originalColor2, color2, changeDuration));

        //Wait until it's time to revert.
        float timeUntilRevert = revertTime - (startTime + changeDuration);
        if (timeUntilRevert > 0)
            yield return new WaitForSeconds(timeUntilRevert);

        //Lerp back to original colors.
        yield return StartCoroutine(LerpColor(material1, color1, originalColor1, changeDuration));
        yield return StartCoroutine(LerpColor(material2, color2, originalColor2, changeDuration));
    }

    private IEnumerator LerpColor(Material mat, Color startColor, Color endColor, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            mat.color = Color.Lerp(startColor, endColor, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        mat.color = endColor;
    }
}
