using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.Common.Models
{
	public class Customer : BaseModel
	{
		public Customer()
		{
			Initialize();
		}

		#region Properties

		ColorTheme _theme;

		[JsonIgnore]
		public ColorTheme Theme
		{
			get
			{
				if(_theme == null)
					_theme = App.Instance.Theming.GetTheme(this);
				
				return _theme;
			}
		}

		public string Index
		{
			get;
			set;
		}

		bool _hasStarted;

		public bool HasStarted
		{
			get
			{
				return _hasStarted;
			}
			set
			{
				SetPropertyChanged(ref _hasStarted, value);
			}
		}

		string _name;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				SetPropertyChanged(ref _name, value);
			}
		}

		string _rulesUrl;

		public string RulesUrl
		{
			get
			{
				return _rulesUrl;
			}
			set
			{
				SetPropertyChanged(ref _rulesUrl, value);
			}
		}

		string _sport;

		public string Sport
		{
			get
			{
				return _sport;
			}
			set
			{
				SetPropertyChanged(ref _sport, value);
			}
		}

		bool _isEnabled;

		public bool IsEnabled
		{
			get
			{
				return _isEnabled;
			}
			set
			{
				SetPropertyChanged(ref _isEnabled, value);
			}
		}

		bool _isAcceptingMembers;

		public bool IsAcceptingMembers
		{
			get
			{
				return _isAcceptingMembers;
			}
			set
			{
				SetPropertyChanged(ref _isAcceptingMembers, value);
				SetPropertyChanged("LeagueDetails");
			}
		}

		int _minHoursBetweenChallenge;

		public int MinHoursBetweenChallenge
		{
			get
			{
				return _minHoursBetweenChallenge;
			}
			set
			{
				SetPropertyChanged(ref _minHoursBetweenChallenge, value);
				SetPropertyChanged("LeagueDetails");
			}
		}

		int _matchGameCount;

		public int MatchGameCount
		{
			get
			{
				return _matchGameCount;
			}
			set
			{
				SetPropertyChanged(ref _matchGameCount, value);
				SetPropertyChanged("LeagueDetails");
			}
		}

		string description;

		public string Description
		{
			get
			{
				return description;
			}
			set
			{
				SetPropertyChanged(ref description, value);
			}
		}

		int _season;

		public int Season
		{
			get
			{
				return _season;
			}
			set
			{
				SetPropertyChanged(ref _season, value);
			}
		}

		string imageUrl;

		public string ImageUrl
		{
			get
			{
				return imageUrl;
			}
			set
			{
				SetPropertyChanged(ref imageUrl, value);
			}
		}

		string createdByAthleteId;

		public string CreatedByAthleteId
		{
			get
			{
				return createdByAthleteId;
			}
			set
			{
				SetPropertyChanged(ref createdByAthleteId, value);
				SetPropertyChanged("CreatedByAthlete");
			}
		}

		DateTime? _startDate;

		public DateTime? StartDate
		{
			get
			{
				return _startDate;
			}
			set
			{
				SetPropertyChanged(ref _startDate, value);
				SetPropertyChanged("DateRange");
				SetPropertyChanged("LeagueDetails");
			}
		}

		DateTime? _endDate;

		public DateTime? EndDate
		{
			get
			{
				return _endDate;
			}
			set
			{
				SetPropertyChanged(ref _endDate, value);
				SetPropertyChanged("DateRange");
				SetPropertyChanged("LeagueDetails");
			}
		}

		#endregion

		void Initialize()
		{
			StartDate = DateTime.Now.AddDays(7);
			EndDate = DateTime.Now.AddMonths(6);
			//Memberships = new List<Membership>();

			MinHoursBetweenChallenge = 48;
			MatchGameCount = 3;

			IsAcceptingMembers = true;
			IsEnabled = true;
		}



		public override bool Equals(object obj)
		{
			var comp = new CustomersIdComparer();
			return comp.Equals(this, obj as Customer);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		
	}

	#region Comparers

	public class CustomersIdComparer : IEqualityComparer<Customer>
	{
		public bool Equals(Customer x, Customer y)
		{
			if(x == null || y == null)
				return false;
			
			return x.Id == y.Id;
		}

		public int GetHashCode(Customer obj)
		{
			return obj.Id != null ? obj.Id.GetHashCode() : base.GetHashCode();
		}
	}

	public class CustomerComparer : IEqualityComparer<Customer>
	{
		public bool Equals(Customer x, Customer y)
		{
			if(x == null || y == null)
				return false;

            var isEqual = x.Id == y.Id;
			              //&& x.MembershipIds?.Count == y.MembershipIds?.Count;

			return isEqual;
		}

		public int GetHashCode(Customer obj)
		{
			return obj.Id != null ? obj.Id.GetHashCode() : base.GetHashCode();
		}
	}

	#endregion
}