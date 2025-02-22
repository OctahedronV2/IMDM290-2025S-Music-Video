using UnityEngine;

public class MaxTester : MonoBehaviour
{

    public float developmentTime = 95f;
    public float climaxTime = 160f;
    public float resolutionTime = 197f;

    public BalloonSpawner balloonSpawner;
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

            for(int i = 0; i < 20; i++)
            {
                GameObject balloon = balloonSpawner.SpawnBalloon();
                balloon.transform.position = new Vector3(cameraPos.position.x, cameraPos.position.y - 10f, 0);

                AudioFloat af = balloon.GetComponent<AudioFloat>();
                af.floatStrength = 5;
                af.ampCutoff = 0;

                balloon.tag = "Untagged";
            }

            sec = Section.Development;
        }

        if(timeElapsed > climaxTime && sec == Section.Development)
        {
            Debug.Log("Changing to Climax section");
            sec = Section.Climax;
        }

        if(timeElapsed > resolutionTime && sec == Section.Climax)
        {
            Debug.Log("Changing to Resolution section");
            sec = Section.Resolution;
        }
    }
}
