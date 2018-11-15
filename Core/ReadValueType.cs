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
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AddresSound.Core
{
	public enum ReadValueType
	{
		Byte,
		Word,
		DWord,
		QWord,
	}

	public static class ReadValueTypeConstants
	{
		public static readonly string[] ValueTypeNames=new string[]
			{
				"Byte",
				"Word",
				"DWord",
				"QWord",
			};
	}

	public static class ValueTypeExtension
	{
		public static ulong ToValue(this ReadValueType valueType,byte[] data)
		{
			switch (valueType)
			{
				case ReadValueType.Word:
					return BitConverter.ToUInt16(data, 0);
				case ReadValueType.DWord:
					return BitConverter.ToUInt32(data, 0);
				case ReadValueType.QWord:
					return BitConverter.ToUInt64(data, 0);
				default:
					return data[0];
			}
		}
	}

}
