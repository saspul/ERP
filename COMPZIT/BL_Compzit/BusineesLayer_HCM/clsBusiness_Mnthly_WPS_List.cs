using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusiness_Mnthly_WPS_List
    {
        ClsData_WPS_LIst ObjdataWps = new ClsData_WPS_LIst();
        public DataTable LoadBissnusUnit(ClsEntityLayerWps_List objEntityWPS, int AllBussChk)
        {

            return ObjdataWps.LoadBissnusUnit(objEntityWPS, AllBussChk);
        }
        public DataTable LoadDivision(ClsEntityLayerWps_List objEntityWPS)
        {
            return ObjdataWps.LoadDivision(objEntityWPS);

        }
        public DataTable LoadDep(ClsEntityLayerWps_List objEntityWPS)
        { return ObjdataWps.LoadDep(objEntityWPS); }



        public DataTable LoadDesg(ClsEntityLayerWps_List objEntityWPS)
        { return ObjdataWps.LoadDesg(objEntityWPS); }


        public DataTable LoadPayerBank(ClsEntityLayerWps_List objEntityWPS)
        { return ObjdataWps.LoadPayerBank(objEntityWPS); }

        public DataTable LoadBank(ClsEntityLayerWps_List objEntityWPS)
        { return ObjdataWps.LoadBank(objEntityWPS); }



        public DataTable ReadMonthlySal_PaidList(ClsEntityLayerWps_List objEntityWPS)
        {
            return ObjdataWps.ReadMonthlySal_PaidList(objEntityWPS);
        }
        public DataTable LoadEmpBank(ClsEntityLayerWps_List objEntityWPS)
        {
            return ObjdataWps.LoadEmpBank(objEntityWPS);
        }
        public DataTable LoadSIFHeaderDetails(ClsEntityLayerWps_List objEntityWPS)
        { return ObjdataWps.LoadSIFHeaderDetails(objEntityWPS); }

        public DataTable ReadBankName(ClsEntityLayerWps_List objEntityWPS)
        { return ObjdataWps.ReadBankName(objEntityWPS); }
        public DataTable ReadPayerBank(ClsEntityLayerWps_List objEntityWPS)
        { return ObjdataWps.ReadPayerBank(objEntityWPS); }

        public DataTable ReadDocumentName(ClsEntityLayerWps_List objEntityWPS)
        { return ObjdataWps.ReadDocumentName(objEntityWPS); }

        public DataTable ReadSIFRecordDetails(ClsEntityLayerWps_List objEntityWPS, string[] EmpList)
        { return ObjdataWps.ReadSIFRecordDetails(objEntityWPS, EmpList); }

       
        //0041


        public DataTable ReadSIFRecordDetailsESPandLSP(ClsEntityLayerWps_List objEntityWPS)
        { 
            return ObjdataWps.ReadSIFRecordDetailsESPandLSP(objEntityWPS); 
        }
        //end

        public DataTable LoadMonthlySalList(ClsEntityLayerWps_List objEntityWPS)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = ObjdataWps.LoadMonthlySalList(objEntityWPS);
            return dtGuarnt;
        }

        public void InsertToWPSList(ClsEntityLayerWps_List objEntityWPS)
        {
            ObjdataWps.InsertToWPSList(objEntityWPS);    

        }
        public DataTable ReadFor_PreView_Header(ClsEntityLayerWps_List objEntityWPS)
        {
            return ObjdataWps.ReadFor_PreView_Header(objEntityWPS);
        }
        public DataTable ReadFor_PreView_Record(ClsEntityLayerWps_List objEntityWPS)
        {
            return ObjdataWps.ReadFor_PreView_Record(objEntityWPS);
        }
        public void UpdateSettledStatus(ClsEntityLayerWps_List objEntityWPS, List<ClsEntityLayerWps_List> objEntityLayerWps_List)
        {         
            ObjdataWps.UpdateSettledStatus(objEntityWPS, objEntityLayerWps_List);
        }
        public DataTable ReadEmpWorkingDays(ClsEntityLayerWps_List objEntityWPS)
        { return ObjdataWps.ReadEmpWorkingDays(objEntityWPS); 
        }

        public DataTable ReadLeavSettlmentChk(ClsEntityLayerWps_List objEntityWPS)
        {
            DataTable dtEmp_List = new DataTable();
            dtEmp_List = ObjdataWps.ReadLeavSettlmentChk(objEntityWPS);
            return dtEmp_List;
        }
        public DataTable LoadSponsor(ClsEntityLayerWps_List objEntityWPS)
        {
            return ObjdataWps.LoadSponsor(objEntityWPS);

        }
    }

}
