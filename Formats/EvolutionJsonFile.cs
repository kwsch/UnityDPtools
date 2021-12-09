using System.IO;
using PKHeX.Core;

namespace UnityDPtools.Evolution
{
    public class EvolutionJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Evolve[] Evolve { get; set; }
    }

    public class Evolve
    {
        public int id { get; set; }
        public int[] ar { get; set; }

        public byte[] Convert(int species)
        {
            using var ms = new MemoryStream();
            using var bw = new BinaryWriter(ms);
            if (!IsReversedExport(species))
            {
                for (int i = 0; i < ar.Length; i += 5)
                {
                    bw.Write(checked((ushort)ar[i + 0]));
                    bw.Write(checked((ushort)ar[i + 1]));
                    bw.Write(checked((ushort)ar[i + 2]));
                    bw.Write(checked((byte)ar[i + 3]));
                    bw.Write(checked((byte)ar[i + 4]));
                }
            }
            else // Write evolutions in reverse (less restricted ones first)
            {
                for (int i = ar.Length - 5; i >= 0; i -= 5)
                {
                    bw.Write(checked((ushort)ar[i + 0]));
                    bw.Write(checked((ushort)ar[i + 1]));
                    bw.Write(checked((ushort)ar[i + 2]));
                    bw.Write(checked((byte)ar[i + 3]));
                    bw.Write(checked((byte)ar[i + 4]));
                }
            }
            return ms.ToArray();
        }

        private bool IsReversedExport(int species)
        {
            // Feebas Prism Scale first (still unobtainable), and Thunderstone Magneton
            return species is (int)Species.Feebas or (int)Species.Magneton;
        }
    }
}
