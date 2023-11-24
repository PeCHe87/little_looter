/*
 * Date: November 23th, 2023
 * Author: Peche
 */

using UnityEngine;

namespace LittleLooters.Gameplay
{
    public class ExplorableObject : MonoBehaviour
    {
		[SerializeField] private ExplorableObjectType _type = ExplorableObjectType.NONE;

		private const string _tag = "Player";

		private void OnTriggerEnter(Collider other)
		{
			if (!other.tag.Equals(_tag)) return;

			ExplorableObjectEvents.OnEnter?.Invoke(_type);
		}

		private void OnTriggerExit(Collider other)
		{
			if (!other.tag.Equals(_tag)) return;

			ExplorableObjectEvents.OnExit?.Invoke(_type);
		}
	}
}