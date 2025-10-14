using System.Collections.Generic;

namespace CURIOsity_API.Models
{
    public class CuriosityDataModel
    {
        public Dictionary<string, int> StagecraftEquipmentPositions {get; set;}
        public Dictionary<string, int> LeftPanelApertures {get; set;}
        public Dictionary<string, int> RightPanelApertures {get; set;}
    }
}