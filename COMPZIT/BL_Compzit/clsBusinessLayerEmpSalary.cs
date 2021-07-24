using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;
using DL_Compzit;
using EL_Compzit;



namespace BL_Compzit
{
   public class clsBusinessLayerEmpSalary
    {
       clsDataLayerEmpSalary objDataEmpSalry = new clsDataLayerEmpSalary();
       public DataTable ReadDedctnLoad(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadDedctnLoad(objEntityPaygrd);
           return dtEmpSalry;
       }


       public DataTable ReadAddnLoad(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadAddnLoad(objEntityPaygrd);
           return dtEmpSalry;
       }

       public DataTable ReadPayGrade(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadPayGrade(objEntityPaygrd);
           return dtEmpSalry;
       }
       public string DuplCheckNamePayGrade(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           string dtEmpSalry = "";
           dtEmpSalry = objDataEmpSalry.DuplCheckNamePayGrade(objEntityPaygrd);
           return dtEmpSalry;
       }
       public void AddPayGrade(clsEntityLayerEmpSalary objEntityPaygrd)
       {
        
           objDataEmpSalry.AddPayGrade(objEntityPaygrd);
       
       }

       public DataTable RestrictionChk(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.RestrictionChk(objEntityPaygrd);
           return dtEmpSalry;
       }

       //public string DuplCheckSalaryAllownce(clsEntityLayerEmpSalary objEntityPaygrd)
       //{
       //    string dtEmpSalry = "";
       //    dtEmpSalry = objDataEmpSalry.DuplCheckSalaryAllownce(objEntityPaygrd);
       //    return dtEmpSalry;
       //}

       public void AddSalaryAddnAllownce(clsEntityLayerEmpSalary objEntityPaygrd)
       {

           objDataEmpSalry.AddSalaryAddnAllownce(objEntityPaygrd);
       
       }


       public DataTable ReadAllounceList(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadAllounceList(objEntityPaygrd);
           return dtEmpSalry;
       }

       public void ChangeAllowStatus(clsEntityLayerEmpSalary objEntityPaygrd)
       {

           objDataEmpSalry.ChangeAllowStatus(objEntityPaygrd);
       
       }
       public void ChangeDedctnStatus(clsEntityLayerEmpSalary objEntityPaygrd)
       {

           objDataEmpSalry.ChangeDedctnStatus(objEntityPaygrd);
       
       }
       

       public DataTable ReadAllounceById(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadAllounceById(objEntityPaygrd);
           return dtEmpSalry;
       }

       public void CancelAllownce(clsEntityLayerEmpSalary objEntityPaygrd)
       {

           objDataEmpSalry.CancelAllownce(objEntityPaygrd);
       
       }

       public void CancelDedctn(clsEntityLayerEmpSalary objEntityPaygrd)
       {

           objDataEmpSalry.CancelDedctn(objEntityPaygrd);
       
       }

       public string DuplCheckSalaryAllownce(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           string dtEmpSalry = "";
           dtEmpSalry = objDataEmpSalry.DuplCheckSalaryAllownce(objEntityPaygrd);
           return dtEmpSalry;
       }

       public void UpdSalaryAddnAllownce(clsEntityLayerEmpSalary objEntityPaygrd)
       {

           objDataEmpSalry.UpdSalaryAddnAllownce(objEntityPaygrd);
       
       }


       public DataTable ReadDedctnById(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadDedctnById(objEntityPaygrd);
           return dtEmpSalry;
       }

       public string DuplCheckSalaryDedctn(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           string dtEmpSalry = "";
           dtEmpSalry = objDataEmpSalry.DuplCheckSalaryDedctn(objEntityPaygrd);
           return dtEmpSalry;
       }


       public DataTable AllowncRestrictionChk(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.AllowncRestrictionChk(objEntityPaygrd);
           return dtEmpSalry;
       }

       public DataTable DedctnRestrictionChk(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.DedctnRestrictionChk(objEntityPaygrd);
           return dtEmpSalry;
       }

       public void AddSalaryDedction(clsEntityLayerEmpSalary objEntityPaygrd)
       {

           objDataEmpSalry.AddSalaryDedction(objEntityPaygrd);
       
       }

       public DataTable ReadDedctnList(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadDedctnList(objEntityPaygrd);
           return dtEmpSalry;
       }

       public void UpdateSalaryDedction(clsEntityLayerEmpSalary objEntityPaygrd)
       {

           objDataEmpSalry.UpdateSalaryDedction(objEntityPaygrd);
       
       }

       public string EpmlyCheckPayGrade(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           string dtEmpSalry = "";
           dtEmpSalry = objDataEmpSalry.EpmlyCheckPayGrade(objEntityPaygrd);
           return dtEmpSalry;
       }


       public DataTable ReadSalaryByEmpId(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadSalaryByEmpId(objEntityPaygrd);
           return dtEmpSalry;
       }



       public void UpdatePayGrade(clsEntityLayerEmpSalary objEntityPaygrd)
       {

           objDataEmpSalry.UpdatePayGrade(objEntityPaygrd);
       
       }
       public void UpdatePayGradeBasicPay(clsEntityLayerEmpSalary objEntityPaygrd)
       {

           objDataEmpSalry.UpdatePayGradeBasicPay(objEntityPaygrd);

       }

       public DataTable ReadAllounceByAddId(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadAllounceByAddId(objEntityPaygrd);
           return dtEmpSalry;
       }
       public DataTable ReadDedctnByDedId(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadDedctnByDedId(objEntityPaygrd);
           return dtEmpSalry;
       }
       public DataTable ReadSalaryAddnTableId(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadSalaryAddnTableId(objEntityPaygrd);
           return dtEmpSalry;
       }
       public DataTable ReadSalaryDeductnTableId(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadSalaryDeductnTableId(objEntityPaygrd);
           return dtEmpSalry;
       }
       public DataTable ReadRangeInfo(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadRangeInfo(objEntityPaygrd);
           return dtEmpSalry;
       }
       public DataTable ReadPayGradeCrncy(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtEmpSalry = new DataTable();
           dtEmpSalry = objDataEmpSalry.ReadPayGradeCrncy(objEntityPaygrd);
           return dtEmpSalry;
       }
       public DataTable ReadAmtPercSts(clsEntityLayerEmpSalary objEntityPaygrd)
       {
           DataTable dtAmtPercSts = new DataTable();
           dtAmtPercSts = objDataEmpSalry.ReadAmtPercSts(objEntityPaygrd);
           return dtAmtPercSts;
       }
    }
}
