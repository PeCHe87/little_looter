/*
 * Date: November 18th, 2023
 * Author: Peche
 */

using UnityEngine;

namespace LittleLooters.Gameplay.UI
{
    public class UI_CurrentMissionExtraInfoPanel : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private UI_CurrentMission_DestructionDetails _destructionPanel = default;
        [SerializeField] private UI_CurrentMission_UpgradeToolDetails _upgradeToolPanel = default;

		#endregion

		#region Public methods

        public void Refresh(MissionConfigurationData mission)
		{
			if (mission.Type == MissionType.DESTRUCTION)
			{
				ShowDestructionPanel(mission);
				return;
			}

			if (mission.Type == MissionType.TOOL_UPGRADE)
			{
				ShowUpgradeToolPanel(mission);
				return;
			}
		}

		#endregion

		#region Private methods

		private void HidePanels()
		{
			_destructionPanel.gameObject.SetActive(false);
			_upgradeToolPanel.gameObject.SetActive(false);
		}

		private void ShowDestructionPanel(MissionConfigurationData mission)
		{
			HidePanels();

			_destructionPanel.gameObject.SetActive(true);

			var missionInfo = (MissionResourceDestructionData)mission;

			_destructionPanel.Setup(missionInfo.Destructible.LevelRequired);
		}

		private void ShowUpgradeToolPanel(MissionConfigurationData mission)
		{
			HidePanels();

			_upgradeToolPanel.gameObject.SetActive(true);

			var missionInfo = (MissionToolUpgradeData)mission;

			_upgradeToolPanel.Setup(missionInfo.ToolLevel);
		}

		#endregion
	}
}