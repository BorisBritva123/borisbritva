﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TouchpadServiceDebugging {
    class MouseController {
        public enum Flags { Absolute = 0x8000, LeftDown = 0x0002, LeftUp = 0x0004, Move = 0x0001, RightDown = 0x0008, RightUp = 0x0010 }

        [DllImport("user32.dll")]
        public static extern void mouse_event(int flags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

        public static void Move(int dx, int dy) {
            mouse_event((int)Flags.Move, dx, dy, 0, new UIntPtr());
        }

        public static void Left(bool up) {
            if (up)
                mouse_event((int)Flags.LeftUp, 0, 0, 0, new UIntPtr());
            else
                mouse_event((int)Flags.LeftDown, 0, 0, 0, new UIntPtr());
        }
        public static void Right(bool up) {
            if (up)
                mouse_event((int)Flags.RightUp, 0, 0, 0, new UIntPtr());
            else
                mouse_event((int)Flags.RightDown, 0, 0, 0, new UIntPtr());
        }
    }
}
