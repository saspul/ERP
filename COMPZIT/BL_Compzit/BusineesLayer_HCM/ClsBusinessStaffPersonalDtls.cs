using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_HCM;
using System.Data;
namespace BL_Compzit.BusineesLayer_HCM
{

   
        public class ClsBusinessStaffPersonalDtls
        {

            ClsDataLayerStaffPersonalDtls objDataLayerPersonalDtls = new ClsDataLayerStaffPersonalDtls();



            public void insertPersonalDtls(clsEntityStaffPersonalDtls objEntityPersonalDtls)
            {
                objDataLayerPersonalDtls.insertPersonalDtls(objEntityPersonalDtls);
            }


            public DataTable ReadDivision(clsEntityStaffPersonalDtls objEntityPersonalDtls)
            {
                DataTable dtDiv = objDataLayerPersonalDtls.ReadDivision(objEntityPersonalDtls);
                return dtDiv;
            }

            public DataTable ReadDesignation(clsEntityStaffPersonalDtls objEntityPersonalDtls)
            {
                DataTable dtDpt = objDataLayerPersonalDtls.ReadDesignation(objEntityPersonalDtls);
                return dtDpt;
            }

            public void UpdatepersonalDetails(clsEntityStaffPersonalDtls objEntityPersonalDtls)
            {
                objDataLayerPersonalDtls.UpdatepersonalDetails(objEntityPersonalDtls);
            }


            public DataTable ReadPersonalDetailsId(clsEntityStaffPersonalDtls objEntityPersonalDtls)
            {
                DataTable dtManpower = objDataLayerPersonalDtls.ReadPersonalDetailsId(objEntityPersonalDtls);
                return dtManpower;
            }

            public DataTable ReadCandidatePersonalDetailsList(clsEntityStaffPersonalDtls objEntityPersonalDtls)
            {
                DataTable dtManpower = objDataLayerPersonalDtls.ReadPersonalDetailsId(objEntityPersonalDtls);
                return dtManpower;
            }
        }
    }

