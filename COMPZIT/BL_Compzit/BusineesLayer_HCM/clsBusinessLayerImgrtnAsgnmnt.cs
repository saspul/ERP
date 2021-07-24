using DL_Compzit.DataLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusinessLayerImgrtnAsgnmnt
    {
        clsDataLayer_Imgrtn_Asgnmnt ObjDataImmigrtn = new clsDataLayer_Imgrtn_Asgnmnt();

        public DataTable ReadEmployee(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
        {
            DataTable dtDetail = ObjDataImmigrtn.ReadEmployee(objEntityImmgrtn);
            return dtDetail;
        }
        public DataTable ReadEmployeeCandidate(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
        {
            DataTable dtDetail = ObjDataImmigrtn.ReadEmployeeCandidate(objEntityImmgrtn);
            return dtDetail;
        }
        public DataTable ReadEmployeeCndDtById(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
        {
            DataTable dtDetail = ObjDataImmigrtn.ReadEmployeeCndDtById(objEntityImmgrtn);
            return dtDetail;
        }

        public DataTable ReadEmployeeCandidatesList(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
        {
            DataTable dtDetail = ObjDataImmigrtn.ReadEmployeeCandidatesList(objEntityImmgrtn);
            return dtDetail;
        }

        public DataTable ReadImmgrtnRounds(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
        {
            DataTable dtDetail = ObjDataImmigrtn.ReadImmgrtnRounds(objEntityImmgrtn);
            return dtDetail;
        }
        public DataTable ReadImmgrtnRoundsDetails(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
        {
            DataTable dtDetail = ObjDataImmigrtn.ReadImmgrtnRoundsDetails(objEntityImmgrtn);
            return dtDetail;
        }
        public DataTable ReadDivisionOfEmp(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
        {
            DataTable dtDetail = ObjDataImmigrtn.ReadDivisionOfEmp(objEntityImmgrtn);
            return dtDetail;
        }

        public int Insert_ImmiAsignmnt(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
        {
            int id = ObjDataImmigrtn.Insert_ImmiAsignmnt(objEntityImmgrtn);
            return id;
        }
        public void Insert_Process_Detail(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn, List<clsEntityLayerImgrtnAsgnmntEmpLoy> ObjEmpList)
        {
            ObjDataImmigrtn.Insert_Process_Detail(objEntityImmgrtn, ObjEmpList);
        }
        public void Update_Process_Detail(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn, List<clsEntityLayerImgrtnAsgnmntEmpLoy> ObjEmpList)
        {
            ObjDataImmigrtn.Update_Process_Detail(objEntityImmgrtn, ObjEmpList);
        }
        public DataTable ReadImmgrtnAsignDetailsByCand(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
        {
            DataTable dtDetail = ObjDataImmigrtn.ReadImmgrtnAsignDetailsByCand(objEntityImmgrtn);
            return dtDetail;
        }
        public DataTable ReadAsignedEployees(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
        {
            DataTable dtDetail = ObjDataImmigrtn.ReadAsignedEployees(objEntityImmgrtn);
            return dtDetail;
        }
        public DataTable ReadCurrentStsByDtlId(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
        {
            DataTable dtDetail = ObjDataImmigrtn.ReadCurrentStsByDtlId(objEntityImmgrtn);
            return dtDetail;
        }
        public void RecallAssignment(clsEntityLayerImgrtnAsgnmnt objEntityImmgrtn)
        {
            ObjDataImmigrtn.RecallAssignment(objEntityImmgrtn);
        }
    }
}
