using System;

namespace Prime.Common.Models
{
	public interface IDirty
	{
		bool IsDirty
		{
			get;
			set;
		}
	}
}