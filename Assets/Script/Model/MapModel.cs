using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Script.Config;
using Game.System;
using Game.Util;
using MainLogic.Manager;

namespace Game.Model
{
    public class MapModel : BaseModel
    {
        public Dictionary<int, string> MapDatas;

        public override void InitModel()
        {
            MapDatas = JsonUtil.ToObject<Dictionary<int, string>>(
                ResourcesManager.LoadText(JsonPath.MapPath, JsonFileName.GameMapName));
        }
    }
}
