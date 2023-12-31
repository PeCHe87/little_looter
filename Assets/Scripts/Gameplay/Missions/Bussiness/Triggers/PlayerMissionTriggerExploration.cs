/*
 * Date: November 15th, 2023
 * Author: Peche
 */

using LittleLooters.Model;

namespace LittleLooters.Gameplay
{
	public class PlayerMissionTriggerExploration
	{
		private const MissionType _missionType = MissionType.EXPLORATION;
		private ExplorableObjectType _goal = ExplorableObjectType.NONE;
		private bool _inProgress = false;
		private System.Action _callback = null;
		private int _objectId = -1;

		public void Initialize(System.Action callback)
		{
			_callback = callback;

			ExplorableObjectEvents.OnEnter += ExplorableFound;
		}

		public void Teardown()
		{
			ExplorableObjectEvents.OnEnter -= ExplorableFound;

			_callback = null;
		}

		public void ResetStatus(MissionType type, MissionConfigurationData mission)
		{
			if (_missionType != type)
			{
				Stop();
				return;
			}

			var data = (MissionExplorationData) mission;

			Start(data.explorableType, data.Id);
		}

		private void Start(ExplorableObjectType type, int id)
		{
			_goal = type;
			_inProgress = true;
			_objectId = id;
		}

		private void Stop()
		{
			_goal = ExplorableObjectType.NONE;
			_inProgress = false;
			_objectId = -1;
		}

		private void ExplorableFound(ExplorableObjectType explorableType, int id)
		{
			if (!_inProgress) return;

			if (explorableType != _goal) return;

			if (_objectId != id) return;

			UI_GameplayEvents.OnStopMissionAssistance?.Invoke();

			PlayerMissionsEvents.OnMissionProgress?.Invoke(1, 1);

			_callback?.Invoke();
		}
	}
}