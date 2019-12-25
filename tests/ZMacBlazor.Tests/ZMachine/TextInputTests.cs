﻿using Blazork.Tests.Logging;
using Blazork.ZMachine;
using Blazork.ZMachine.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Blazork.Tests.ZMachine
{
    public class TextInputTests
    {
        [Fact]
        public void CanDecodeDictionary()
        {
            using var file = File.OpenRead(@"Data\ZORK1.DAT");
            var logger = NullLoggerFactory.GetLogger();
            var machine = new Machine(logger);
            machine.Load(file);

            var dictionary = new ParseDictionary(machine);

            Assert.Equal(0x2B9, dictionary.Words.Count);
            Assert.True(dictionary.Words.ContainsKey("altar"));
            Assert.False(dictionary.Words.ContainsKey("ackack"));
        }

        [Fact]
        public void CanWriteToTextBuffer()
        {
            var buffer = new byte[37];
            buffer[0] = (byte)buffer.Length;

            var memory = new MemoryLocation(1, buffer.AsMemory());
            var textBuffer = new TextBuffer(memory);

            textBuffer.Write("This is a long string with extra words.");

            Assert.Equal(buffer.Length, buffer[0]);
            Assert.Equal(36, textBuffer.MaxLength);
            Assert.Equal((byte)'t', buffer[1]);
            Assert.Equal((byte)'o', buffer[35]);
            Assert.Equal(0, buffer[36]);
        }
    }
}
