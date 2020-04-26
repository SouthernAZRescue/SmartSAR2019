﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.Common.Domain.ValueTypes
{
    public class Person
    {
        public string First { get; }
        public string Middle { get; }
        public string Last { get; }
        public string Nickname { get; }
        public string Full => Nickname + " " + Last;

        public Person(string first, string middle, string last, string nickname)
        {
            First = first;
            Middle = middle;
            Last = last;
            Nickname = nickname;
        }
    }
}