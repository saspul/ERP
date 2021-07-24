using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit
{
  public class clsBusinessLayerCandidateOtherDetails
    {

      public void insertCandidateDtls(clsEntityCandidateOtherDetails objEntityCandDtls, List<clsEntityStaffOtherSub> objEntityStaffOtherDetilsSub)
        {
            clsDatalayerCandidateOtherDetails ObjDataCandDtls = new clsDatalayerCandidateOtherDetails();
            ObjDataCandDtls.insertCandidateDtls(objEntityCandDtls, objEntityStaffOtherDetilsSub);
        }
      public void updatePersonalDtls(clsEntityCandidateOtherDetails objEntityCandDtls, List<clsEntityStaffOtherSub> objEntityStaffOtherDetilsSub, List<clsEntityStaffOtherSub> objEntityStaffOtherDeleteSub)
        {
            clsDatalayerCandidateOtherDetails ObjDataCandDtls = new clsDatalayerCandidateOtherDetails();
            ObjDataCandDtls.updatePersonalDtls(objEntityCandDtls, objEntityStaffOtherDetilsSub, objEntityStaffOtherDeleteSub);
        }

        public DataTable ReadPersnlDtlsById(clsEntityCandidateOtherDetails objEntityCandidateDtls)
        {
            clsDatalayerCandidateOtherDetails ObjDataCandDtls = new clsDatalayerCandidateOtherDetails();
          DataTable dt=  ObjDataCandDtls.ReadPersnlDtlsById(objEntityCandidateDtls);
          return dt;
        }

        public DataTable ReadStaffOtherSubByID(clsEntityCandidateOtherDetails objEntityCandidateDtls)
        {
            clsDatalayerCandidateOtherDetails ObjDataCandDtls = new clsDatalayerCandidateOtherDetails();
            DataTable dtDpt = ObjDataCandDtls.ReadStaffOtherSubByID(objEntityCandidateDtls);
            return dtDpt;
        }




    }



}
