using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using System.Data;
using Oracle.DataAccess.Client;


namespace DL_Compzit
{
    public class clsDataLayerRecentMenu
    {
        public void InsertRecentMenu(clsEntityLayerRecentMenu objELRecentMenu)
        {
            string strQueryInsertRecentMenu = "MENU.SP_INSERT_RECENTMENU";
            using (OracleCommand cmdInsertRecentMenu = new OracleCommand())
            {
                cmdInsertRecentMenu.CommandText = strQueryInsertRecentMenu;
                cmdInsertRecentMenu.CommandType = CommandType.StoredProcedure;
                cmdInsertRecentMenu.Parameters.Add("R_CORPRT_ID", OracleDbType.Varchar2).Value = objELRecentMenu.CorpId;
                cmdInsertRecentMenu.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objELRecentMenu.OrgId;
                cmdInsertRecentMenu.Parameters.Add("R_USERID", OracleDbType.Int32).Value = objELRecentMenu.UserId;
                cmdInsertRecentMenu.Parameters.Add("R_MENUID", OracleDbType.Int32).Value = objELRecentMenu.MenuId;
                cmdInsertRecentMenu.Parameters.Add("R_APPID", OracleDbType.Varchar2).Value = objELRecentMenu.AppId;
                cmdInsertRecentMenu.Parameters.Add("R_DATE", OracleDbType.Date).Value = objELRecentMenu.Date;
                //cmdInsertRecentMenu.Parameters.Add("R_TIME", OracleDbType.TimeStamp).Value = objELRecentMenu.MenuTime;
                //cmdInsertRecentMenu.Parameters.Add("A_STATUS", OracleDbType.Int32).Value = objELRecentMenu.Count;
                clsDataLayer.ExecuteNonQuery(cmdInsertRecentMenu);
            }
        }
        public DataTable ReadRecentMenu(clsEntityLayerRecentMenu objELRecentMenu)
        {
            string strQueryInsertRecentMenu = "MENU.SP_READ_RECENTMENU";

            using (OracleCommand cmdInsertRecentMenu = new OracleCommand())
            {
                cmdInsertRecentMenu.CommandText = strQueryInsertRecentMenu;
                cmdInsertRecentMenu.CommandType = CommandType.StoredProcedure;
                cmdInsertRecentMenu.Parameters.Add("R_CORPRT_ID", OracleDbType.Varchar2).Value = objELRecentMenu.CorpId;
                cmdInsertRecentMenu.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objELRecentMenu.OrgId;
                cmdInsertRecentMenu.Parameters.Add("R_USERID", OracleDbType.Int32).Value = objELRecentMenu.UserId;
                cmdInsertRecentMenu.Parameters.Add("R_MENUID", OracleDbType.Int32).Value = objELRecentMenu.AppId;
                cmdInsertRecentMenu.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtRecentMenu = new DataTable();
                dtRecentMenu = clsDataLayer.ExecuteReader(cmdInsertRecentMenu);
                return dtRecentMenu;
            }
        }
        public DataTable ReadFrquentMenu(clsEntityLayerRecentMenu objELRecentMenu)
        {
            string strQueryInsertRecentMenu = "MENU.SP_READ_FREQUENTMENU";

            using (OracleCommand cmdInsertRecentMenu = new OracleCommand())
            {
                cmdInsertRecentMenu.CommandText = strQueryInsertRecentMenu;
                cmdInsertRecentMenu.CommandType = CommandType.StoredProcedure;
                cmdInsertRecentMenu.Parameters.Add("R_CORPRT_ID", OracleDbType.Varchar2).Value = objELRecentMenu.CorpId;
                cmdInsertRecentMenu.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objELRecentMenu.OrgId;
                cmdInsertRecentMenu.Parameters.Add("R_USERID", OracleDbType.Int32).Value = objELRecentMenu.UserId;
                cmdInsertRecentMenu.Parameters.Add("R_MENUID", OracleDbType.Int32).Value = objELRecentMenu.AppId;
                cmdInsertRecentMenu.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtRecentMenu = new DataTable();
                dtRecentMenu = clsDataLayer.ExecuteReader(cmdInsertRecentMenu);
                return dtRecentMenu;
            }
        }
    }
}
