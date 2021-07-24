using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusiness_Accomodation_Report
    {
        cls_DataLayer_Accomodation_Report ObjData_Accomodation = new cls_DataLayer_Accomodation_Report();
        public DataTable ReadDepts(clsEntity_Accomodation_Report objEntityAccomodation_Report)
        {
            DataTable dtDepts = new DataTable();
            dtDepts = ObjData_Accomodation.ReadDepts(objEntityAccomodation_Report);
            return dtDepts;
        }
        public DataTable ReadDivision(clsEntity_Accomodation_Report objEntityAccomodation_Report)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = ObjData_Accomodation.ReadDivision(objEntityAccomodation_Report);
            return dtDivision;
        }
        public DataTable ReadAccommodation(clsEntity_Accomodation_Report objEntityAccomodation_Report)
        {
            DataTable dtAccommodation = new DataTable();
            dtAccommodation = ObjData_Accomodation.ReadAccommodation(objEntityAccomodation_Report);
            return dtAccommodation;
        }
        public DataTable ReadAccommodationList(clsEntity_Accomodation_Report objEntityAccomodation_Report)
        {
            DataTable dtAccommodation = new DataTable();
            dtAccommodation = ObjData_Accomodation.ReadAccommodationList(objEntityAccomodation_Report);
            return dtAccommodation;
        }
        public DataTable ReadCorporateAddress(clsEntity_Accomodation_Report objEntityAccomodation_Report)
        {
            DataTable dtAccommodation = new DataTable();
            dtAccommodation = ObjData_Accomodation.ReadCorporateAddress(objEntityAccomodation_Report);
            return dtAccommodation;
        }
        public DataTable ReadDivisionOfEmp(clsEntity_Accomodation_Report objEntityAccomodation_Report)
        {
            DataTable dtDetail = ObjData_Accomodation.ReadDivisionOfEmp(objEntityAccomodation_Report);
            return dtDetail;
        }
    }
}
