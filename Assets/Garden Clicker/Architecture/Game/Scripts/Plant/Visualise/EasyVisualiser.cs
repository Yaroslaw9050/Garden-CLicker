using System.Numerics;
using UnityEngine;

public class EasyVisualiser : DefaultVisualiser
{
    private AppearanceObject appearanceObject;

    private void Awake()
    {
        appearanceObject = gameObject.GetComponent<AppearanceObject>();
    }
    public override void StepVisualise()
    {
        appearanceObject.EndStep();
    }
    public override void StepHarvesting()
    {
        Deactivation();
    }
    private void Deactivation()
    {
        int items = plants.Count / step;
        for (int i = 0; i < items; i++)
        {
            if (activePlants.Count == 0) return;
            int randomPlants = Random.Range(0, activePlants.Count);

            activePlants[randomPlants].SetActive(false);
            activePlants.RemoveAt(randomPlants);
        }
    }
}
