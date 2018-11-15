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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddresSound.Core
{
	public class NotifierSettings
	{
		[JsonProperty(PropertyName = "condition", Required = Required.Always)]
		public int Condition { get; set; }
		[JsonProperty(PropertyName = "specifiedValue", Required = Required.Always)]
		public ulong SpecifiedValue { get; set; }
		[JsonProperty(PropertyName = "enabled", Required = Required.Always)]
		public bool Enabled { get; set; }
		[JsonProperty(PropertyName = "soundPaths", Required = Required.Always)]
		public List<string> SoundPaths { get; set; }
	}
}
