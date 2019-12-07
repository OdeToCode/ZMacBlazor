﻿using Microsoft.Extensions.Logging;
using System.IO;

namespace ZMacBlazor.Client.ZMachine
{
    public class Machine
    {
        public void Load(Stream memoryBytes)
        {
            Memory = new MachineMemory(memoryBytes);
            PC = Memory.StartingProgramCounter;
        }

        public void Execute()
        {
                
        }

        public void SetPC(ushort newValue)
        {
            PC = newValue;
        }

        public ushort PC { get; protected set; }
        public MachineMemory Memory { get; protected set; }

    }
}
