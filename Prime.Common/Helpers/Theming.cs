using Prime.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Prime.Common.Helpers
{
	public class Theming
	{
		public Theming()
		{
			AvailableLeagueColors = new List<string> {
					"red",
					"green",
					"blue",
					"pink",
					"teal",
					"asphalt",
					"yellow",
					"purple",
					"orange",
			};
		}

		public static List<string> AvailableLeagueColors
		{
			get;
			set;
		}

		public Dictionary<string, string> UsedLeagueColors
		{
			get;
			set;
		} = new Dictionary<string, string>();


		#region Theme

		/// <summary>
		/// Assigns a league a randomly-chosen theme from an existing finite list
		/// </summary>
		/// <returns>The theme.</returns>
		public ColorTheme GetTheme(Customer customer)
		{
			if(customer.Id == null)
				return null;

			var remaining = AvailableLeagueColors.Except(UsedLeagueColors.Values).ToList();
			if(remaining.Count == 0)
				remaining.AddRange(AvailableLeagueColors);

			var random = new Random().Next(0, remaining.Count - 1);
			var color = remaining[random];

			if(UsedLeagueColors.ContainsKey(customer.Id.ToString()))
			{
				color = UsedLeagueColors[customer.Id.ToString()];
			}
			else
			{
				UsedLeagueColors.Add(customer.Id.ToString(), color);
			}

			var theme = GetThemeFromColor(color);

			if(Application.Current.Resources.ContainsKey($"{color}Medium"))
				theme.Medium = (Color)Application.Current.Resources[$"{color}Medium"];

			return theme;
		}

		public ColorTheme GetThemeFromColor(string color)
		{
			return new ColorTheme
			{
				Primary = (Color)Application.Current.Resources[$"{color}Primary"],
				Light = (Color)Application.Current.Resources[$"{color}Light"],
				Dark = (Color)Application.Current.Resources[$"{color}Dark"],
			};
		}

		#endregion
	}
}

