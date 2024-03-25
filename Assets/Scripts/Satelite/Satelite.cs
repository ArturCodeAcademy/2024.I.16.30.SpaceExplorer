using UnityEngine;

[RequireComponent(typeof(SateliteInfoPanel))]
[RequireComponent(typeof(Health))]
public class Satelite : MonoBehaviour
{
	[field: SerializeField] public SateliteInfoPanel Panel { get; private set; }
	[field: SerializeField] public Health Health { get; private set; }
}
