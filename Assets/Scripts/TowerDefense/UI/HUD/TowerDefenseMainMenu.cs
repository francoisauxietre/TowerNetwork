using Core.UI;
using System;
using UnityEngine;

//il manquait 4 erreurs ici 
namespace TowerDefense.UI.HUD
{
	/// <summary>
	/// Main menu implementation for tower defense
	/// </summary>
	public class TowerDefenseMainMenu : MainMenu
	{
		//ajouter 
		private SimpleMainMenuPage m_CurrentPage;
		/// <summary>
		/// Reference to options menu
		/// </summary>
		public OptionsMenu optionsMenu;
		
		/// <summary>
		/// Reference to title menu
		/// </summary>
		public SimpleMainMenuPage titleMenu;
		
		/// <summary>
		/// Reference to level select menu
		/// </summary>
		public LevelSelectScreen levelSelectMenu;

		/// <summary>
		/// Bring up the options menu
		/// </summary>
		public void ShowOptionsMenu()
		{
			ChangePage(optionsMenu);
		}

		//ajouter
		private void ChangePage(OptionsMenu optionsMenu)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Bring up the options menu
		/// </summary>
		public void ShowLevelSelectMenu()
		{
			ChangePage(levelSelectMenu);
		}

		//ajouter
		private void ChangePage(LevelSelectScreen levelSelectMenu)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns to the title screen
		/// </summary>
		public void ShowTitleScreen()
		{
			Back(titleMenu);
		}

		private void Back(SimpleMainMenuPage titleMenu)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Set initial page
		/// </summary>
		protected virtual void Awake()
		{
			ShowTitleScreen();
		}

		/// <summary>
		/// Escape key input
		/// </summary>
		protected virtual void Update()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				if ((SimpleMainMenuPage)m_CurrentPage == titleMenu)
				{
					Application.Quit();
				}
				else
				{
					Back();
				}
			}
		}
		//ajouter
		private void Back()
		{
			throw new NotImplementedException();
		}
	}
}