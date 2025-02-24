using System.Collections;
using UnityEngine;

public class SectionController : MonoBehaviour
{

    public float developmentTime = 95f;
    public float climaxTime = 160f;
    public float resolutionTime = 197f;

    public BalloonSpawner balloonSpawner;
    public GameObject redBalloon;
    public GameObject blueBalloonClone;
    public Transform cameraPos;

    private float timeElapsed;

    private enum Section
    {
        Exposition,
        Development,
        Climax,
        Resolution
    }

    private Section sec = Section.Exposition;

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed > developmentTime && sec == Section.Exposition)
        {
            Debug.Log("Changing to Development section");

            StartCoroutine(SpawnBalloons());

            sec = Section.Development;
        }

        if(timeElapsed > climaxTime && sec == Section.Development)
        {
            Debug.Log("Changing to Climax section");
            sec = Section.Climax;

            var de = blueBalloonClone.GetComponent<DelayedEntrance>();
            if(de != null)
            {
                de.mode = DelayedEntrance.Mode.Enter;
            }

            redBalloon.GetComponent<AudioFloat>().ampCutoff = 0.035f;
            redBalloon.GetComponent<AudioFloat>().floatStrength *= 3;

            blueBalloonClone.GetComponent<AudioFloat>().ampCutoff = 0.035f;
            blueBalloonClone.GetComponent<AudioFloat>().floatStrength *= 2.65f;

            StopCoroutine(SpawnBalloons());
        }

        if(timeElapsed > resolutionTime && sec == Section.Climax)
        {
            Debug.Log("Changing to Resolution section");
            sec = Section.Resolution;

            redBalloon.GetComponent<AudioFloat>().ampCutoff += 0.5f;
        }

        if(sec == Section.Resolution)
        {
            var fb = cameraPos.gameObject.GetComponent<FollowBalloons>();
            fb.zoomDistance += 0.005f;
        }
    }

    public IEnumerator SpawnBalloons()
    {
        while(true)
        {
            if (timeElapsed > climaxTime - 20f) yield break;
            GameObject balloon = balloonSpawner.SpawnBalloon();

            float randomX = cameraPos.position.x + Random.Range(-7.5f, 7.5f);
            float randomY = cameraPos.position.y - 20 + Random.Range(-5f, 0f);
            float randomZ = Random.Range(-3f, 3f);

            float randomFloatStrength = Random.Range(150f, 170f);

            balloon.transform.position = new Vector3(randomX, randomY, randomZ);

            AudioFloat af = balloon.GetComponent<AudioFloat>();
            af.floatStrength = randomFloatStrength;
            af.ampCutoff = Random.Range(0f, 0.075f);

            balloon.tag = "Untagged";
            yield return new WaitForSeconds(0.25f);
        }
    }
}
