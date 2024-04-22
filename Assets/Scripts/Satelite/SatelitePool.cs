using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelitePool : MonoBehaviour
{
	public static SatelitePool Instance { get; private set; }

	public event Action<Satelite> SateliteAdded;
	public event Action<Satelite> SateliteRemoved;

	public int SateliteCount => _satelites.Count;

	private List<Satelite> _satelites = new();

	public Satelite this[int index] => _satelites[index];

	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
	}

	public void AddSatelite(Satelite satelite)
	{
		_satelites.Add(satelite);
		SateliteAdded?.Invoke(satelite);
	}

	public void RemoveSatelite(Satelite satelite)
	{
		_satelites.Remove(satelite);
		SateliteRemoved?.Invoke(satelite);
	}
}
