using System.Collections.Generic;
using UnityEngine;

public class DefaultVisualiser : MonoBehaviour
{
    [SerializeField] protected List<GameObject> plants;

    protected List<GameObject> activePlants = new List<GameObject>();
    private List<GameObject> deactivatePlants = new List<GameObject>();

    protected int step = 4;

    private void Start()
    {
        
        foreach(GameObject p in plants)
        {
            deactivatePlants.Add(p);
            activePlants.Add(p);
            p.SetActive(false);
        }
    }
    public void Visualise()
    {
        int items = plants.Count / step;
        for(int i = 0; i < items; i++)
        {
            if (deactivatePlants.Count == 0) return;
            int randomPlants = Random.Range(0, deactivatePlants.Count);

            deactivatePlants[randomPlants].SetActive(true);
            deactivatePlants.RemoveAt(randomPlants);
        }
    }
    public virtual void StepVisualise()
    {
        Debug.LogError("Dont use base method StepVisualise()");
    }
    public virtual void StepHarvesting()
    {
        Debug.LogError("Dont use base method StepHarvesting()");
    }
}
