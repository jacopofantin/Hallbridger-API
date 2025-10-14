using CURIOsity_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CURIOsity_API.Parsers
{
    public static class TxtParser
    {
        public static CuriosityDataModel Parse(Stream stream)
        {
            var result = new CuriosityDataModel
            {
                StagecraftEquipmentPositions = new Dictionary<string, int>(),
                LeftPanelApertures = new Dictionary<string, int>(),
                RightPanelApertures = new Dictionary<string, int>()
            };

            using (var reader = new StreamReader(stream))
            {
                try
                {
                    var lines = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        lines.Add(reader.ReadLine());
                    }

                    foreach (var line in lines.Skip(3).Take(13))
                    {
                        result.StagecraftEquipmentPositions.Add(line.Substring(0, 6), int.Parse(line.Substring(9, 5)));
                    }

                    foreach (var line in lines.Skip(17).Take(26))
                    {
                        result.LeftPanelApertures.Add(line.Substring(0, 6), int.Parse(line.Substring(9, 5)));
                    }

                    foreach (var line in lines.Skip(44).Take(26))
                    {
                        result.RightPanelApertures.Add(line.Substring(0, 6), int.Parse(line.Substring(9, 5)));
                    }
                }
                catch (Exception error)
                {
                    throw new FormatException("Error while reading hall file: " + error.Message + "\n" + "Please make sure the file coming from the hall is formatted as expected (described in the readme file)");
                }
            }

            return result;
        }
    }
}