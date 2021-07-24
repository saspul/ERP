
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;
using DL_Compzit.HCM;
using EL_Compzit.HCM;


namespace BL_Compzit.HCM
{
   public class clsBusiness_Pay_Grade_Master
    {
       clsDataLayer_Pay_Grade_Master objDataPayGrd = new clsDataLayer_Pay_Grade_Master();

       public DataTable ReadCurrency(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataPayGrd.ReadCurrency(objEntityPaygrd);
           return dtGuarnt;
       }

       public DataTable ReadSalaryAddn(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataPayGrd.ReadSalaryAddn(objEntityPaygrd);
           return dtGuarnt;
       }
       public DataTable ReadSalaryDedctn(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataPayGrd.ReadSalaryDedctn(objEntityPaygrd);
           return dtGuarnt;
       }

       public void AddPayGrade(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {

           objDataPayGrd.AddPayGrade(objEntityPaygrd);
          
       }


       public DataTable ReadPayGradeList(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataPayGrd.ReadPayGradeList(objEntityPaygrd);
           return dtGuarnt;
       }


       public void ChangeRequestStatus(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {

           objDataPayGrd.ChangeRequestStatus(objEntityPaygrd);
          
       }


       public void CancelPayGrade(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {

           objDataPayGrd.CancelPayGrade(objEntityPaygrd);
          
       }
       public void ReCallPayGrade(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {

           objDataPayGrd.ReCallPayGrade(objEntityPaygrd);
          
       }


       public DataTable ReadPayGradeById(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataPayGrd.ReadPayGradeById(objEntityPaygrd);
           return dtGuarnt;
       }

       public string DuplCheckNamePayGrade(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           string dtGuarnt = "";
           dtGuarnt = objDataPayGrd.DuplCheckNamePayGrade(objEntityPaygrd);
           return dtGuarnt;
       }
       public void UpdatePayGrade(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           //DataTable dtGuarnt = new DataTable();
            objDataPayGrd.UpdatePayGrade(objEntityPaygrd);
           //return dtGuarnt;
       }

       public void AddSalaryAddnAllownce(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           //DataTable dtGuarnt = new DataTable();
            objDataPayGrd.AddSalaryAddnAllownce(objEntityPaygrd);
           //return dtGuarnt;
       }
       public string DuplCheckSalaryAllownce(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           string dtGuarnt = "";
           dtGuarnt = objDataPayGrd.DuplCheckSalaryAllownce(objEntityPaygrd);
           return dtGuarnt;
       }

       public string DuplCheckSalaryDedctn(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           string dtGuarnt = "";
           dtGuarnt = objDataPayGrd.DuplCheckSalaryDedctn(objEntityPaygrd);
           return dtGuarnt;
       }

       public void AddSalaryDedction(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           //DataTable dtGuarnt = new DataTable();
      objDataPayGrd.AddSalaryDedction(objEntityPaygrd);
           //return dtGuarnt;
       }

       public DataTable ReadAllounceList(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataPayGrd.ReadAllounceList(objEntityPaygrd);
           return dtGuarnt;
       }

       public void ChangeAllowStatus(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {

           objDataPayGrd.ChangeAllowStatus(objEntityPaygrd);
          
       }


       public DataTable ReadAllounceById(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataPayGrd.ReadAllounceById(objEntityPaygrd);
           return dtGuarnt;
       }

       public void UpdSalaryAddnAllownce(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {

           objDataPayGrd.UpdSalaryAddnAllownce(objEntityPaygrd);
          
       }

       public void CancelAllownce(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {

           objDataPayGrd.CancelAllownce(objEntityPaygrd);
          
       }
       public DataTable ReadDedctnList(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataPayGrd.ReadDedctnList(objEntityPaygrd);
           return dtGuarnt;
       }

       public void ChangeDedctnStatus(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {

           objDataPayGrd.ChangeDedctnStatus(objEntityPaygrd);
          
       }


       public DataTable ReadDedctnById(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataPayGrd.ReadDedctnById(objEntityPaygrd);
           return dtGuarnt;
       }
       public void CancelDedctn(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {

           objDataPayGrd.CancelDedctn(objEntityPaygrd);

       }


       public void UpdateSalaryDedction(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {

           objDataPayGrd.UpdateSalaryDedction(objEntityPaygrd);
          
       }

       public DataTable CurncyAbbrv(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataPayGrd.CurncyAbbrv(objEntityPaygrd);
           return dtGuarnt;
       }


       public DataTable ReadOvertimeById(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objDataPayGrd.ReadOvertimeById(objEntityPaygrd);
           return dtGuarnt;
       }
       public DataTable ReadCountPayGradeOverTime(clsEntity_Pay_Grade_Master objEntityPaygrd)
       {
           DataTable dtOvrtmCategory = new DataTable();
           dtOvrtmCategory = objDataPayGrd.ReadCountPayGradeOverTime(objEntityPaygrd);
           return dtOvrtmCategory;
       }

        //ReadCountPayGradeOverTime
    }
}
