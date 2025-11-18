using System.Collections.Generic;

namespace Hallbridger_API.Models
{
    public class CurioDataModel
    {
        public Dictionary<string, int> StagecraftEquipmentPositions {get; set;}
        public Dictionary<string, int> LeftPanelApertures {get; set;}
        public Dictionary<string, int> RightPanelApertures {get; set;}
    }
}