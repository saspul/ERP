using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using DL_Compzit.DataLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_FMS
{
    public class clsBusinessLayer_DayBook
    {
        clsDataLayer_DayBook objDataDayBook = new clsDataLayer_DayBook();
        public DataTable ReadTransactionMode(clsEntity_DayBook objDayBook)
        {
            DataTable dtDept = new DataTable();
            dtDept = objDataDayBook.ReadTransactionMode(objDayBook);
            return dtDept;
        }
        public DataTable ReadDayBook(clsEntity_DayBook objDayBook)
        {
            DataTable dtDept = new DataTable();
            dtDept = objDataDayBook.ReadDayBook(objDayBook);
            return dtDept;
        }
    }
}
