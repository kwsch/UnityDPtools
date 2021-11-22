using System;
using System.IO;

namespace UnityDPtools
{
    public static class MiniUtil
    {
        public static byte[] PackMini(byte[][] fileData, string identifier)
        {
            // Create new Binary with the relevant header bytes
            byte[] data = new byte[4];
            data[0] = (byte)identifier[0];
            data[1] = (byte)identifier[1];
            Array.Copy(BitConverter.GetBytes((ushort)fileData.Length), 0, data, 2, 2);

            int count = fileData.Length;
            int dataOffset = 4 + 4 + (count * 4);

            // Start the data filling.
            using MemoryStream dataout = new();
            using MemoryStream offsetMap = new();
            using BinaryWriter bd = new(dataout);
            using BinaryWriter bo = new(offsetMap);
            // For each file...
            for (int i = 0; i < count; i++)
            {
                // Write File Offset
                uint fileOffset = (uint)(dataout.Position + dataOffset);
                bo.Write(fileOffset);

                // Write File to Stream
                bd.Write(fileData[i]);

                // Pad the Data MemoryStream with Zeroes until len%4=0;
                while (dataout.Length % 4 != 0)
                    bd.Write((byte)0);
                // File Offset will be updated as the offset is based off of the Data length.
            }
            // Cap the File
            bo.Write((uint)(dataout.Position + dataOffset));

            using var newPack = new MemoryStream();
            using var header = new MemoryStream(data);
            header.WriteTo(newPack);
            offsetMap.WriteTo(newPack);
            dataout.WriteTo(newPack);
            return newPack.ToArray();
        }
    }
}
