using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;

namespace BL_Compzit
{
    public class clsBusinessLayerRecentMenu
    {
        public void InserRecentMenu(clsEntityLayerRecentMenu objELRecentMenu)
        {
            clsDataLayerRecentMenu ObjDLRecentMenu = new clsDataLayerRecentMenu();
            ObjDLRecentMenu.InsertRecentMenu(objELRecentMenu);
        }
        public DataTable ReadRecentMenu(clsEntityLayerRecentMenu objELRecentMenu)
        {
            clsDataLayerRecentMenu ObjDLRecentMenu = new clsDataLayerRecentMenu();
            DataTable dtRecentMenu = ObjDLRecentMenu.ReadRecentMenu(objELRecentMenu);
            return dtRecentMenu;
        }
        public DataTable ReadFrquentMenu(clsEntityLayerRecentMenu objELRecentMenu)
        {
            clsDataLayerRecentMenu ObjDLRecentMenu = new clsDataLayerRecentMenu();
            DataTable dtRecentMenu = ObjDLRecentMenu.ReadFrquentMenu(objELRecentMenu);
            return dtRecentMenu;
        }
    }
}
