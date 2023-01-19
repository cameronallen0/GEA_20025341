using UnityEngine;
using UnityEditor;

public class TrackLogicWindow : EditorWindow
{   
    string objectBaseName = "CheckpointSingle";
    int objectID = 1;
    public int numberOfLaps = 0;
    public int countdownTime = 0;
    GameObject parentObject;
    GameObject objectToSpawn;
    float spawnRadius = 0f;

    public GameObject gameController;

    //Puts editor in Window tab and names it
    [MenuItem("Window/Track Logic")]
    public static void ShowWindow ()
    {
        GetWindow<TrackLogicWindow>("Track Logic Editor");
    }

    public void OnGUI ()
    {
        //Visuals for Editor Window
        GUILayout.Label("Track Logic Editor.", EditorStyles.boldLabel);

        gameController = EditorGUILayout.ObjectField("GameController", gameController, typeof(GameObject), true) as GameObject;
        objectBaseName = EditorGUILayout.TextField("Object Name", objectBaseName);
        numberOfLaps = EditorGUILayout.IntField("Number of Laps", numberOfLaps);
        countdownTime = EditorGUILayout.IntField("Countdown", countdownTime);
        objectID = EditorGUILayout.IntField("Object ID", objectID);
        parentObject = EditorGUILayout.ObjectField("Parent Object", parentObject, typeof(GameObject), true) as GameObject;
        objectToSpawn = EditorGUILayout.ObjectField("Object to spawn", objectToSpawn, typeof(GameObject), true) as GameObject;

        if(GUILayout.Button("Update Laps"))
        {
            gameController.GetComponent<GameController>().EditorUpdate(numberOfLaps);
        }
        if(GUILayout.Button("Update Countdown"))
        {
            gameController.GetComponent<CountdownController>().CountdownUpdate(countdownTime);
        }
        if (GUILayout.Button("Add Checkpoint"))
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if(objectToSpawn == null)
        {
            Debug.LogError("Error: Please assign an object to be spawned.");
            return;
        }
        if(objectBaseName == string.Empty)
        {
            Debug.LogError("Error: Please enter a name for the object.");
            return;
        }
        
        Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(spawnCircle.x, 2f, spawnCircle.y);

        GameObject newObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
        newObject.transform.SetParent(parentObject.transform);
        newObject.name = objectBaseName + objectID;

        objectID++;
    }
}
