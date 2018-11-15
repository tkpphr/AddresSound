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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OpenTK.Audio.OpenAL;

namespace AddrSound.Core
{
    class ALSound 
    {
		public string SoundPath { get; private set; }
        private int BufferId { get; set; }
        private int[] SourceIds { get; set; }
		private int SourceIndex { get; set; }
		private static readonly int SourceIdMax = 5; 

        public ALSound(string filePath)
        {
			SoundPath = filePath;
			Initialize(filePath);
        }

		private void Initialize(string filePath)
		{
			using (var fileStream=File.OpenRead(filePath))
			{
				using (var binaryReader = new BinaryReader(fileStream, Encoding.Unicode))
				{
					int channel;
					int bit;
					int rate;
					ALFormat format;
					byte[] data;
					int dataLength;

					binaryReader.ReadBytes(22);
					channel = binaryReader.ReadUInt16();
					rate = binaryReader.ReadInt32();
					binaryReader.ReadBytes(6);
					bit = binaryReader.ReadUInt16();
					if (channel == 1)
					{
						format = bit == 8 ? ALFormat.Mono8 : ALFormat.Mono16;
					}
					else
					{
						format = bit == 8 ? ALFormat.Stereo8 : ALFormat.Stereo16;
					}
					binaryReader.ReadBytes(4);
					dataLength = binaryReader.ReadInt32();
					data = binaryReader.ReadBytes(dataLength);
					BufferId = AL.GenBuffer();
					AL.BufferData(BufferId, format, data, data.Length, rate);
					SourceIndex = 0;
					SourceIds = AL.GenSources(SourceIdMax);
					for (int i = 0; i < SourceIds.Length; i++)
					{
						AL.Source(SourceIds[i], ALSourcei.Buffer, BufferId);
					}
				}
			}
		}

        public void Dispose()
        {
			Stop();
			Array.ForEach(SourceIds, sourceId => AL.Source(sourceId,ALSourcei.Buffer,0));
			AL.DeleteSources(SourceIds);
			AL.DeleteBuffer(BufferId);
		}

        public void Play()
        {
			for (int i = 0; i < SourceIds.Length; i++)
			{
				var state = AL.GetSourceState(SourceIds[i]);
				if (state == ALSourceState.Stopped || state == ALSourceState.Initial)
				{
					AL.SourcePlay(SourceIds[i]);
					SourceIndex = i;
					break;
				}
				else
				{
					if (i == SourceIds.Length - 1)
					{
						AL.SourceStop(SourceIds[0]);
						AL.SourcePlay(SourceIds[0]);
						SourceIndex = 0;
					}

				}
			}
		}

        public void Stop()
        {
			foreach (int sourceId in SourceIds)
			{
				AL.SourceStop(sourceId);
			}
			SourceIndex = 0;
		}

    }
}
