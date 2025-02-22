using System.Collections;
using UnityEngine;

public class SectionController : MonoBehaviour
{

    public float developmentTime = 95f;
    public float climaxTime = 160f;
    public float resolutionTime = 197f;

    public BalloonSpawner balloonSpawner;
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

            StopCoroutine(SpawnBalloons());
        }

        if(timeElapsed > resolutionTime && sec == Section.Climax)
        {
            Debug.Log("Changing to Resolution section");
            sec = Section.Resolution;
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

            float randomFloatStrength = Random.Range(3f, 5f);

            balloon.transform.position = new Vector3(randomX, randomY, randomZ);

            AudioFloat af = balloon.GetComponent<AudioFloat>();
            af.floatStrength = randomFloatStrength;
            af.maxHeight = 200f;
            af.ampCutoff = Random.Range(0f, 0.15f);

            balloon.GetComponent<Renderer>().material.color = new Color(0.2f, 0.7f, 0.2f);

            balloon.tag = "Untagged";
            yield return new WaitForSeconds(0.25f);
        }
    }
}
