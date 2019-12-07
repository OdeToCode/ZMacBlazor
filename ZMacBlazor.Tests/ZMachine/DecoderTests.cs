﻿using Microsoft.Extensions.Logging;
using System.IO;
using Xunit;
using Xunit.Abstractions;
using ZMacBlazor.Client.ZMachine;
using ZMacBlazor.Client.ZMachine.Instructions;
using ZMacBlazor.Tests.Logging;

namespace ZMacBlazor.Tests.ZMachine
{
    public class DecoderTests
    {
        private readonly ILogger testLogger;

        public DecoderTests(ITestOutputHelper testOutput)
        {
            testLogger = new LoggerAdapter(testOutput);
        }

        [Fact]
        public void DecodesOpeningZorkInstruction()
        {
            var file = File.OpenRead(@"Data\ZORK1.DAT");
            var memory = new MachineMemory();
            memory.Load(file);

            var decoder = new InstructionDecoder(testLogger);
            var instruction = decoder.Decode(memory.SpanAt(memory.StartingProgramCounter));

            // Assert.IsType<VCall>(instruction);
        }
    }
}
