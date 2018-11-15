/*
Copyright 2018 tkpphr

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using AddresSound.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddresSound.Core
{
	public enum Condition
	{
		Equals,
		UpEquals,
		UpGreaterThan,
		UpLessThan,
		DownEquals,
		DownGreaterThan,
		DownLessThan,
	}

	public static class ConditionUtils
	{
		private static readonly string[] ConditionNames = new string[]
		{
			Resources.EqualsCondition,
			Resources.UpEqualsCondition,
			Resources.UpGreaterCondition,
			Resources.UpLessCondition,
			Resources.DownEqualsCondition,
			Resources.DownGreaterCondition,
			Resources.DownLessCondition,
		};

		public static bool Compare(this Condition condition,ulong oldValue,ulong newValue, ulong specifiedValue)
		{
			ulong delta = Math.Max(oldValue,newValue) - Math.Min(oldValue,newValue);
			if(delta==0)
			{
				return false;
			}
			switch(condition)
			{
				case Condition.UpEquals:
					return oldValue < newValue && specifiedValue == delta;
				case Condition.UpGreaterThan:
					return oldValue < newValue && specifiedValue < delta;
				case Condition.UpLessThan:
					return oldValue < newValue && specifiedValue > delta;
				case Condition.DownEquals:
					return oldValue > newValue && specifiedValue == delta;
				case Condition.DownGreaterThan:
					return oldValue > newValue && specifiedValue < delta;
				case Condition.DownLessThan:
					return oldValue > newValue && specifiedValue > delta;
				default:
					return newValue==specifiedValue;
			}
		}

		
		public static string GetCompareInfo(this Condition condition, ulong oldValue, ulong newValue, ulong specifiedValue)
		{
			ulong delta = Math.Max(oldValue, newValue) - Math.Min(oldValue, newValue);
			switch (condition)
			{
				case Condition.UpEquals:
					return string.Format("{0} , {1} -> {2} , [ +{3} ]", condition.GetConditionName(),oldValue,newValue, specifiedValue);
				case Condition.UpGreaterThan:
					return string.Format("{0} , {1} -> {2} , [ +{3} ({4}{5}) ]", condition.GetConditionName(), oldValue, newValue,delta,specifiedValue,Resources.Greater);
				case Condition.UpLessThan:
					return string.Format("{0} , {1} -> {2} , [ +{3} ({4}{5}) ]", condition.GetConditionName(), oldValue, newValue,delta, specifiedValue, Resources.Less);
				case Condition.DownEquals:
					return string.Format("{0} , {1} -> {2} , [ -{3} ]", condition.GetConditionName(), oldValue, newValue, specifiedValue);
				case Condition.DownGreaterThan:
					return string.Format("{0} , {1} -> {2} , [ -{3} ({4}{5}) ]", condition.GetConditionName(), oldValue, newValue, delta,specifiedValue, Resources.Greater);
				case Condition.DownLessThan:
					return string.Format("{0} , {1} -> {2} , [ -{3} ({4}{5}) ]", condition.GetConditionName(), oldValue, newValue, delta,specifiedValue, Resources.Less);
				default:
					return string.Format("{0} , {1} -> {2} , [ ={3} ]", condition.GetConditionName(), oldValue,newValue, specifiedValue);
			}
		}

		public static string GetConditionName(this Condition condition)
		{
			return ConditionNames[(int)condition];
		}

		public static string[] GetConditionNames()
		{
			return ConditionNames;
		}
	}

}
