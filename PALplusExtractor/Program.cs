using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography;

namespace PALplusExtractor
{

    public class PALplusGeneratorPromSet
    {
        public string SegmentLsb0FileName { get; set; }
        public string SegmentLsb1FileName { get; set; }
        public string SegmentMsb0FileName { get; set; }
        public string SegmentMsb1FileName { get; set; }

        public string Ch1_0FileName { get; set; }
        public string Ch1_1FileName { get; set; }
        public string Ch1_2FileName { get; set; }
        public string Ch1_3FileName { get; set; }

        public string Ch1_2_0FileName { get; set; }
        public string Ch1_2_1FileName { get; set; }
        public string Ch1_2_2FileName { get; set; }
        public string Ch1_2_3FileName { get; set; }

        public string Ch2_3_0FileName { get; set; }
        public string Ch2_3_1FileName { get; set; }
        public string Ch2_3_2FileName { get; set; }
        public string Ch2_3_3FileName { get; set; }

        public string Ch3_0FileName { get; set; }
        public string Ch3_1FileName { get; set; }
        public string Ch3_2FileName { get; set; }
        public string Ch3_3FileName { get; set; }
    }

    public class PALplusGeneratorPromData
    {
        public ushort[] Segments { get; set; }
        public ushort[] Channel1 { get; set; }
        public ushort[] Channel2 { get; set; }
        public ushort[] Channel3 { get; set; }
    }

    public class PALplusGeneratorControlBits
    {
        public byte V30 { get; set; }
        public byte V32 { get; set; }
        public byte V33 { get; set; }
    }

    static class Program
    {
        static int SEGMENTS = 27;
        static int WIDTH = (SEGMENTS * 8 * 4);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            string inputDir_v1_1 = @"C:\Dev\PTV_Preservation\PM5644\PM5644_85\001_1\ROM_Dumps";
            string inputDir_v0_1 = @"C:\Dev\PTV_Preservation\PM5644\PM5644_85\000_1\ROM_Dumps";
            string workingDir = @"N:\Electronics\TV\PM5644\PM5644_85\PatternDumping\";

            var set_v1_1 = new PALplusGeneratorPromSet
            {
                SegmentLsb0FileName = "EPROM_4008_002_04311_CSUM_D1AA.BIN",
                SegmentLsb1FileName = "EPROM_4008_002_04331_CSUM_B2BF.BIN",
                SegmentMsb0FileName = "EPROM_4008_002_04321_CSUM_C01E.BIN",
                SegmentMsb1FileName = "EPROM_4008_002_04341_CSUM_BD5E.BIN",

                Ch1_0FileName = "EPROM_4008_002_04351_CSUM_6F54.BIN",
                Ch1_1FileName = "EPROM_4008_002_04361_CSUM_DB42.BIN",
                Ch1_2FileName = "EPROM_4008_002_04371_CSUM_89CE.BIN",
                Ch1_3FileName = "EPROM_4008_002_04381_CSUM_41CC.BIN",

                Ch1_2_0FileName = "EPROM_4008_002_04391_CSUM_CF3E.BIN",
                Ch1_2_1FileName = "EPROM_4008_002_04401_CSUM_E1DD.BIN",
                Ch1_2_2FileName = "EPROM_4008_002_04411_CSUM_5AE3.BIN",
                Ch1_2_3FileName = "EPROM_4008_002_04421_CSUM_6E60.BIN",

                Ch2_3_0FileName = "EPROM_4008_002_04471_CSUM_23E7.BIN",
                Ch2_3_1FileName = "EPROM_4008_002_04481_CSUM_9FD2.BIN",
                Ch2_3_2FileName = "EPROM_4008_002_04491_CSUM_8196.BIN",
                Ch2_3_3FileName = "EPROM_4008_002_04551_CSUM_D4F3.BIN",

                Ch3_0FileName = "EPROM_4008_002_04431_CSUM_A3BE.BIN",
                Ch3_1FileName = "EPROM_4008_002_04441_CSUM_4458.BIN",
                Ch3_2FileName = "EPROM_4008_002_04451_CSUM_48E1.BIN",
                Ch3_3FileName = "EPROM_4008_002_04461_CSUM_39AE.BIN",
            };

            var set_v0_1 = new PALplusGeneratorPromSet
            {
                SegmentLsb0FileName = "EPROM_4008_002_03461_CSUM_4E21.BIN",
                SegmentLsb1FileName = "EPROM_4008_002_03691_CSUM_C898.BIN",
                SegmentMsb0FileName = "EPROM_4008_002_03471_CSUM_0F7F.BIN",
                SegmentMsb1FileName = "EPROM_4008_002_03701_CSUM_3B83.BIN",

                Ch1_0FileName = "EPROM_4008_002_03511_CSUM_7740.BIN",
                Ch1_1FileName = "EPROM_4008_002_03521_CSUM_F7F8.BIN",
                Ch1_2FileName = "EPROM_4008_002_03531_CSUM_B498.BIN",
                Ch1_3FileName = "EPROM_4008_002_03541_CSUM_4ED8.BIN",

                Ch1_2_0FileName = "EPROM_4008_002_03551_CSUM_6DEE.BIN",
                Ch1_2_1FileName = "EPROM_4008_002_03561_CSUM_01BF.BIN",
                Ch1_2_2FileName = "EPROM_4008_002_03571_CSUM_23B3.BIN",
                Ch1_2_3FileName = "EPROM_4008_002_03581_CSUM_15A7.BIN",

                Ch2_3_0FileName = "EPROM_4008_002_03631_CSUM_6699.BIN",
                Ch2_3_1FileName = "EPROM_4008_002_03641_CSUM_2365.BIN",
                Ch2_3_2FileName = "EPROM_4008_002_03651_CSUM_EFB0.BIN",
                Ch2_3_3FileName = "EPROM_4008_002_03661_CSUM_A22E.BIN",

                Ch3_0FileName = "EPROM_4008_002_03591_CSUM_955E.BIN",
                Ch3_1FileName = "EPROM_4008_002_03601_CSUM_A33C.BIN",
                Ch3_2FileName = "EPROM_4008_002_03611_CSUM_0693.BIN",
                Ch3_3FileName = "EPROM_4008_002_03621_CSUM_2469.BIN",
            };

            DumpPattern(inputDir_v0_1, workingDir, set_v0_1, "PHILIPS_FILM_V0_1");
            DumpPattern(inputDir_v0_1, workingDir, set_v0_1, "PHILIPS_CAMERA_V0_1");
            DumpPattern(inputDir_v1_1, workingDir, set_v1_1, "PHILIPS_4_3_V1_1");
            DumpPattern(inputDir_v1_1, workingDir, set_v1_1, "PHILIPS_CAMERA_V1_1");
            DumpPattern(inputDir_v1_1, workingDir, set_v1_1, "PHILIPS_FILM_V1_1");
            DumpPattern(inputDir_v1_1, workingDir, set_v1_1, "MOTION_DETECTION_V1_1");
            DumpPattern(inputDir_v1_1, workingDir, set_v1_1, "HELPER_AMPLITUDE_V1_1");
            DumpPattern(inputDir_v1_1, workingDir, set_v1_1, "HELPER_TIMING_V1_1");
            DumpPattern(inputDir_v1_1, workingDir, set_v1_1, "ZONEPLATE_V1_1");
        }

        static void DumpPattern(string inputDir, string workingDir, PALplusGeneratorPromSet set, string pattern)
        {
            var data = LoadPromData(inputDir, set);
            var cb = LoadControlBits(workingDir, pattern + ".TXT");
            var samples = Decode(cb, data);
            var image = Render(samples);
            image.Save(Path.Combine(workingDir, pattern) + ".BMP");
            byte[] buffer = new byte[samples.Length * 2];
            Buffer.BlockCopy(samples, 0, buffer, 0, samples.Length * 2);
            File.WriteAllBytes(Path.Combine(workingDir, pattern) + ".BIN", buffer);
        }

        static List<PALplusGeneratorControlBits> LoadControlBits(string dir, string file)
        {
            var ret = new List<PALplusGeneratorControlBits>();
            var input = File.ReadAllLines(Path.Combine(dir, file));

            bool skipping = true;
            foreach (var line in input)
            {
                if (line == "16505_Data_Header_End")
                {
                    skipping = false;
                    continue;
                }

                if (skipping)
                    continue;

                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                ret.Add(new PALplusGeneratorControlBits
                {
                    V30 = (byte)int.Parse(parts[0], System.Globalization.NumberStyles.HexNumber),
                    V32 = (byte)int.Parse(parts[1], System.Globalization.NumberStyles.HexNumber),
                    V33 = (byte)int.Parse(parts[2], System.Globalization.NumberStyles.HexNumber)
                });
            }

            return ret;
        }

        static byte SaturateY(int min, int max, ushort romData)
        {
            var range = max - min;
            var factor = 255 / ((float)max - (float)min);

            float adjusted = romData - (max - range);
            //adjusted = range - adjusted;
            adjusted *= factor;

            return (byte)adjusted;
        }

        static Bitmap Render(ushort[] samples)
        {
            int lineCount = samples.Length / WIDTH;
            int minSample = samples.Min();
            int maxSample = samples.Max();
            var image = new Bitmap(WIDTH, lineCount);

            for (int line = 0; line < lineCount; line++)
            {
                for (int x = 0; x < WIDTH; x++)
                {
                    byte yValue = SaturateY(minSample, maxSample, samples[((line * WIDTH) + x)]);
                    image.SetPixel(x, line, Color.FromArgb(yValue, yValue, yValue));
                }
            }

            return image;
        }

        static ushort[] Decode(List<PALplusGeneratorControlBits> cb, PALplusGeneratorPromData data)
        {
            var samples = new List<ushort>();

            foreach (var line in cb)
            {
                ushort counterPreset = (ushort)(line.V33 | line.V32 << 8);

                for (int lineseg = 0; lineseg < SEGMENTS; lineseg++)
                {
                    int asCounter = (counterPreset << 4) + lineseg;
                    var segAddr = data.Segments[asCounter];

                    for (int lineblk = 0; lineblk < 4; lineblk++)
                    {
                        var promAddr = ((segAddr << 2) | lineblk) * 8;

                        if ((line.V30 & 0x07) == 6)
                        {
                            samples.Add(data.Channel1[promAddr + 0]);
                            samples.Add(data.Channel1[promAddr + 1]);
                            samples.Add(data.Channel1[promAddr + 2]);
                            samples.Add(data.Channel1[promAddr + 3]);
                            samples.Add(data.Channel1[promAddr + 4]);
                            samples.Add(data.Channel1[promAddr + 5]);
                            samples.Add(data.Channel1[promAddr + 6]);
                            samples.Add(data.Channel1[promAddr + 7]);
                        }
                        else if ((line.V30 & 0x07) == 5)
                        {
                            samples.Add(data.Channel2[promAddr + 0]);
                            samples.Add(data.Channel2[promAddr + 1]);
                            samples.Add(data.Channel2[promAddr + 2]);
                            samples.Add(data.Channel2[promAddr + 3]);
                            samples.Add(data.Channel2[promAddr + 4]);
                            samples.Add(data.Channel2[promAddr + 5]);
                            samples.Add(data.Channel2[promAddr + 6]);
                            samples.Add(data.Channel2[promAddr + 7]);
                        }
                        else if ((line.V30 & 0x07) == 3)
                        {
                            samples.Add(data.Channel3[promAddr + 0]);
                            samples.Add(data.Channel3[promAddr + 1]);
                            samples.Add(data.Channel3[promAddr + 2]);
                            samples.Add(data.Channel3[promAddr + 3]);
                            samples.Add(data.Channel3[promAddr + 4]);
                            samples.Add(data.Channel3[promAddr + 5]);
                            samples.Add(data.Channel3[promAddr + 6]);
                            samples.Add(data.Channel3[promAddr + 7]);
                        }
                        else
                        {
                            throw new InvalidDataException();
                        }
                    }
                }
            }

            return samples.ToArray();
        }

        static ushort[] ToUint16Array(byte[] input)
        {
            ushort[] ret = new ushort[input.Length / 2];

            for (int i = 0; i < input.Length / 2; i++)
                ret[i] = (ushort)(input[(i * 2)] | input[(i * 2) + 1] << 8);

            return ret;
        }

        static PALplusGeneratorPromData LoadPromData(string dir, PALplusGeneratorPromSet set)
        {
            var data = new PALplusGeneratorPromData();

            var lsb0 = File.ReadAllBytes(Path.Combine(dir, set.SegmentLsb0FileName));
            var lsb1 = File.ReadAllBytes(Path.Combine(dir, set.SegmentLsb1FileName));
            var msb0 = File.ReadAllBytes(Path.Combine(dir, set.SegmentMsb0FileName));
            var msb1 = File.ReadAllBytes(Path.Combine(dir, set.SegmentMsb1FileName));

            var ch1_0_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch1_0FileName)));
            var ch1_1_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch1_1FileName)));
            var ch1_2_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch1_2FileName)));
            var ch1_3_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch1_3FileName)));

            var ch1_2_0_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch1_2_0FileName)));
            var ch1_2_1_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch1_2_1FileName)));
            var ch1_2_2_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch1_2_2FileName)));
            var ch1_2_3_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch1_2_3FileName)));

            var ch2_3_0_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch2_3_0FileName)));
            var ch2_3_1_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch2_3_1FileName)));
            var ch2_3_2_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch2_3_2FileName)));
            var ch2_3_3_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch2_3_3FileName)));

            var ch3_0_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch3_0FileName)));
            var ch3_1_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch3_1FileName)));
            var ch3_2_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch3_2FileName)));
            var ch3_3_us = ToUint16Array(File.ReadAllBytes(Path.Combine(dir, set.Ch3_3FileName)));

            data.Segments = new ushort[0x80000 * 2];
            data.Channel1 = new ushort[0x40000 * 8];
            data.Channel2 = new ushort[0x40000 * 8];
            data.Channel3 = new ushort[0x40000 * 8];

            for (int i = 0; i < lsb0.Length; i++)
                data.Segments[i] = (ushort)(lsb0[i] | msb0[i] << 8);

            for (int i = 0; i < lsb0.Length; i++)
                data.Segments[i + lsb0.Length] = (ushort)(lsb1[i] | msb1[i] << 8);

            int j = 0;

            for (int i = 0; i < 0x40000; i++)
            {
                data.Channel1[j++] = (ushort)(ch1_0_us[i] & 0x3FF);
                data.Channel1[j++] = (ushort)((ch1_0_us[i] >> 10) | ((ch1_2_0_us[i] & 0x0F) << 6));

                data.Channel1[j++] = (ushort)(ch1_1_us[i] & 0x3FF);
                data.Channel1[j++] = (ushort)((ch1_1_us[i] >> 10) | ((ch1_2_1_us[i] & 0x0F) << 6));

                data.Channel1[j++] = (ushort)(ch1_2_us[i] & 0x3FF);
                data.Channel1[j++] = (ushort)((ch1_2_us[i] >> 10) | ((ch1_2_2_us[i] & 0x0F) << 6));

                data.Channel1[j++] = (ushort)(ch1_3_us[i] & 0x3FF);
                data.Channel1[j++] = (ushort)((ch1_3_us[i] >> 10) | ((ch1_2_3_us[i] & 0x0F) << 6));
            }

            j = 0;

            for (int i = 0; i < 0x40000; i++)
            {
                data.Channel2[j++] = (ushort)(ch1_2_0_us[i] >> 4);
                data.Channel2[j++] = (ushort)(ch2_3_0_us[i] & 0x3FF);

                data.Channel2[j++] = (ushort)(ch1_2_1_us[i] >> 4);
                data.Channel2[j++] = (ushort)(ch2_3_1_us[i] & 0x3FF);

                data.Channel2[j++] = (ushort)(ch1_2_2_us[i] >> 4);
                data.Channel2[j++] = (ushort)(ch2_3_2_us[i] & 0x3FF);

                data.Channel2[j++] = (ushort)(ch1_2_3_us[i] >> 4);
                data.Channel2[j++] = (ushort)(ch2_3_3_us[i] & 0x3FF);
            }

            j = 0;

            for (int i = 0; i < 0x40000; i++)
            {
                data.Channel3[j++] = (ushort)((ch2_3_0_us[i] >> 10) | ((ch3_0_us[i] & 0x0F) << 6));
                data.Channel3[j++] = (ushort)(ch3_0_us[i] >> 4);

                data.Channel3[j++] = (ushort)((ch2_3_1_us[i] >> 10) | ((ch3_1_us[i] & 0x0F) << 6));
                data.Channel3[j++] = (ushort)(ch3_1_us[i] >> 4);

                data.Channel3[j++] = (ushort)((ch2_3_2_us[i] >> 10) | ((ch3_2_us[i] & 0x0F) << 6));
                data.Channel3[j++] = (ushort)(ch3_2_us[i] >> 4);

                data.Channel3[j++] = (ushort)((ch2_3_3_us[i] >> 10) | ((ch3_3_us[i] & 0x0F) << 6));
                data.Channel3[j++] = (ushort)(ch3_3_us[i] >> 4);
            }

            return data;
        }
    }
}
