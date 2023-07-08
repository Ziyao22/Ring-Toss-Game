using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBarController : MonoBehaviour
{
    public GameObject energy_icon_prefab;
    public List<GameObject> energies;
    public GameObject start_point;
    public GameObject energy_parent;

    public int energy_num;

    private Vector3 start_position;
    private int last_energy_num;
    // Start is called before the first frame update
    void Start()
    {
        energy_num = 3;
        start_position = start_point.GetComponent<RectTransform>().localPosition;
        // initialize with 3 energies
        for (int i = 0; i < 3; i++)
        {
            GameObject energy = Instantiate(energy_icon_prefab, start_position + new Vector3(i * 50, 0, 0), Quaternion.identity);
            energy.transform.SetParent(energy_parent.transform, false);
            energies.Add(energy);
        }
        last_energy_num = energy_num;
    }

    // Update is called once per frame
    void Update()
    {
        if (energy_num < last_energy_num)
        {
            for (int i = 0; i < last_energy_num - energy_num; i++)
            {
                GameObject energy_icon = energies[energies.Count - 1];
                Destroy(energy_icon);
                energies.RemoveAt(energies.Count - 1);
                if (energies.Count == 0)
                {
                    energies = new List<GameObject>();
                }
            }
        }
        else if (energy_num > last_energy_num)
        {
            for (int i=1; i<energy_num + 1 - last_energy_num;i++)
            {
                GameObject energy = Instantiate(energy_icon_prefab, start_position + new Vector3((energies.Count) *50, 0, 0), Quaternion.identity);
                energy.transform.SetParent(energy_parent.transform, false);
                energies.Add(energy);
            }
        }

        last_energy_num = energies.Count;
    }
}
