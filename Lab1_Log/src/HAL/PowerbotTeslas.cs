using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab1_Log.src.HAL
{
    public enum CMDtype : byte
    {
        cmdSTX = 0x02,
        cmdExcute = 0x01,
        cmdInvFrequency = 0x20,
        cmdInvDuty = 0x21
    }
    public enum ExecutionCMD : byte
    {
        SaveToFlash = 0x01,
        FaultReset = 0x02,
        ChargeStart = 0x03,
        ChargeStop = 0x04,
        FeedbackRun = 0x05,
        FeedbackStop = 0x06,
        InverterOn = 0x07,
        InverterOff = 0x08,
        EnableSysInfo = 0x09,
        DisableSysInfo = 0x0A
    }

    [Flags]
    public enum FaultMode
    {
        None = 0,
        FaultStop = 1,
        Tx_OCP  = 2

        /*
         * FaultStop = 0b_1000_0000,
        Tx_OCP = 0b_0100_0000,
        Tx_UVLO = 0b_0010_0000
        */
    }

    //string[] msg = new string[] { "abc", "def" };
    // string 복잡한 문자열을 enum 타입의 간단한 문자로 변경하는것.


    public partial class BotPacket
    {


        public byte[] packet = new byte[6];
        public byte[] SerializeExe(ExecutionCMD cmd)
        {


        Array.Clear(packet, 0x0, packet.Length);
            int chk = 0x00;
            packet[0] = (byte)CMDtype.cmdSTX;
            packet[1] = (byte)CMDtype.cmdExcute;
            packet[2] = (byte)CMDtype.cmdExcute ^ 0xFF;
            packet[3] = 1;
            packet[4] = (byte)cmd;

            for (int i = 3; i < 5; i++)
            {
                chk ^= packet[i];
            }
            packet[5] = (byte)chk;

            return packet;
        }
    }

}
