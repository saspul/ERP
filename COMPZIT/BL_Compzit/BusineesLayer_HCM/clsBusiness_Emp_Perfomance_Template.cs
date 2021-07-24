using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.HCM;
using EL_Compzit.HCM;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
namespace BL_Compzit.BusineesLayer_HCM
{
  public   class clsBusiness_Emp_Perfomance_Template
    {
      clsData_Emp_Perfomance_Template objDataPerfmnc_tmplte = new clsData_Emp_Perfomance_Template();
      public void InsertPerfomanceTemplate(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt, List<clsEntity_Emp_perfomance_Template> objSaveTemp, List<clsEntity_Emp_perfomance_Template>  objEntityPerfomListGrps)
      {
          objDataPerfmnc_tmplte.InsertPerfomanceTemplate(objEntityPermne_tmplt, objSaveTemp, objEntityPerfomListGrps);
      }
      public void UpdatePerfomanceTemplate(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt, List<clsEntity_Emp_perfomance_Template> objSaveTemp, List<clsEntity_Emp_perfomance_Template> objEntityPerfomListGrps, string[] strarrCancldtlIdsQst, string[] strarrCancldtlIdsGrp)
      {
          objDataPerfmnc_tmplte.UpdatePerfomanceTemplate(objEntityPermne_tmplt, objSaveTemp, objEntityPerfomListGrps, strarrCancldtlIdsQst, strarrCancldtlIdsGrp);
      }
      public DataTable ReadPerfomanceTemplateList(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt)
      {
          DataTable dtReadPrmnceTmplt = new DataTable();
          dtReadPrmnceTmplt = objDataPerfmnc_tmplte.ReadPerfomanceTemplateList(objEntityPermne_tmplt);
          return dtReadPrmnceTmplt;
      }
      public DataTable ReadPerfomanceByIdByid(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt)
      {
          DataTable dtReadPrmnceTmplt = new DataTable();
          dtReadPrmnceTmplt = objDataPerfmnc_tmplte.ReadPerfomanceByIdByid(objEntityPermne_tmplt);
          return dtReadPrmnceTmplt;
      }
      public void CancelPerfomanceTemplate(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt)
      {
          objDataPerfmnc_tmplte.CancelPerfomanceTemplate(objEntityPermne_tmplt);
      }
      public DataTable ReadPerfomanceTemplate(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt)
      {
          DataTable dtReadPrmnceTmplt = new DataTable();
          dtReadPrmnceTmplt = objDataPerfmnc_tmplte.ReadPerfomanceTemplate(objEntityPermne_tmplt);
          return dtReadPrmnceTmplt;
      }
      public DataTable ReadGrupsandQstnById(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt)
      {
          DataTable dtReadPrmnceTmplt = new DataTable();
          dtReadPrmnceTmplt = objDataPerfmnc_tmplte.ReadGrupsandQstnById(objEntityPermne_tmplt);
          return dtReadPrmnceTmplt;
      }

      public DataTable DuplicationCheckGrp(clsEntity_Emp_perfomance_Template objEntityPermne_tmplt)
      {
          DataTable dtReadPrmnceTmplt = new DataTable();
          dtReadPrmnceTmplt = objDataPerfmnc_tmplte.DuplicationCheckGrp(objEntityPermne_tmplt);
          return dtReadPrmnceTmplt;
      }
      
      
      
    }
}
