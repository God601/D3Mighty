﻿/*
 * Copyright (C) 2011 D3Sharp Project
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using System;
using System.Collections.Generic;

namespace D3Sharp.Net.Game.Message
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IncomingMessageAttribute : Attribute
    {
        public List<Opcodes> Opcodes { get; private set; }
        public Consumers Consumer { get; private set; }

        public IncomingMessageAttribute(Opcodes opcode, Consumers consumer = Consumers.None)
        {
            this.Opcodes = new List<Opcodes> {opcode};
            this.Consumer = consumer;
        }

        public IncomingMessageAttribute(Opcodes[] opcodes)
        {
            this.Opcodes = new List<Opcodes>();
            foreach (var opcode in opcodes)
            {
                this.Opcodes.Add(opcode);
            }
        }
    }
}
