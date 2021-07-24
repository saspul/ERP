using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusiness_Arrivl_Confrmtn
    {

        clsDataLayer_Arrivl_Confrmtn objDataJobDescrptn = new clsDataLayer_Arrivl_Confrmtn();

        public DataTable ReadArrvlConfrmtnList(clsEntity_Arrivl_Confrmtn objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadArrvlConfrmtnList(objEntityjob);
            return dtGuarnt;
        }

        public void StatusChangeArrvlConfrmtn(clsEntity_Arrivl_Confrmtn objEntityjob)
        {
            //DataTable dtGuarnt = new DataTable();
            objDataJobDescrptn.StatusChangeArrvlConfrmtn(objEntityjob);
            
        
        }
        public void Intw_skip_StatusChange(clsEntity_Arrivl_Confrmtn objEntityjob)
        {
            //DataTable dtGuarnt = new DataTable();
            objDataJobDescrptn.Intw_skip_StatusChange(objEntityjob);

        }
        
    }
}
