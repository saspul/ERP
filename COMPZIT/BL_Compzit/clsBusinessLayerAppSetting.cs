using System;
using DL_Compzit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;

namespace BL_Compzit
{
    //START
    //EVM040
    public class clsBusinessLayerAppSetting
    {
        clsDataLayerAppSetting objDataLayerAppSetting = new clsDataLayerAppSetting();
        public void UpdateAppSettingHCM(clsEntityAppSetting objEntityAppSetting)
        {
            objDataLayerAppSetting.UpdateAppSettingHCM(objEntityAppSetting);
        }
        public void UpdateAppSettingFAS(clsEntityAppSetting objEntityAppSetting)
        {
            objDataLayerAppSetting.UpdateAppSettingFAS(objEntityAppSetting);
        }
        public void UpdateAppSettingGeneral(clsEntityAppSetting objEntityAppSetting)
        {
            objDataLayerAppSetting.UpdateAppSettingGeneral(objEntityAppSetting);
        }
    }
    //END
    //EVM040
}
