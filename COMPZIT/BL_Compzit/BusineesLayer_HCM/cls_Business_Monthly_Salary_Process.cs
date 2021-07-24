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
  public  class cls_Business_Monthly_Salary_Process
    {
      
      cls_Data_Monthly_Salary_Process objData = new cls_Data_Monthly_Salary_Process();

      public DataTable ReadLastDatePrint(cls_Entity_Monthly_Salary_Process objEntitySalary)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.ReadLastDatePrint(objEntitySalary);
          return dtGuarnt;
      }


      public DataTable LoadBissnusUnit(cls_Entity_Monthly_Salary_Process objEntitySalary, int AllBussChk)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.LoadBissnusUnit(objEntitySalary, AllBussChk);
          return dtGuarnt;
      }
      public DataTable LoadDivision(cls_Entity_Monthly_Salary_Process objEntitySalary)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.LoadDivision(objEntitySalary);
          return dtGuarnt;
      }
      public DataTable LoadDep(cls_Entity_Monthly_Salary_Process objEntitySalary)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.LoadDep(objEntitySalary);
          return dtGuarnt;
      }
      public DataTable ReadLastLeaveStlDate(cls_Entity_Monthly_Salary_Process objEntitySalary)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.ReadLastLeaveStlDate(objEntitySalary);
          return dtGuarnt;
      }
      public DataTable LoadDesg(cls_Entity_Monthly_Salary_Process objEntitySalary)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.LoadDesg(objEntitySalary);
          return dtGuarnt;
      }

      public DataTable LoadSalaryPrssList(cls_Entity_Monthly_Salary_Process objEntitySalary,List<cls_Entity_Monthly_Salary_Process> OBJ)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.LoadSalaryPrssList(objEntitySalary, OBJ);
          return dtGuarnt;
      }

       public DataTable ReadAllounceList(cls_Entity_Monthly_Salary_Process objEntitySalary)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.ReadAllounceList(objEntitySalary);
          return dtGuarnt;
      }
       public DataTable ReadDeductionList(cls_Entity_Monthly_Salary_Process objEntitySalary)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.ReadDeductionList(objEntitySalary);
          return dtGuarnt;
      }
       public DataTable ReadDeductionListEdit(clsEntityLayerEmpSalary objEntitySalary, string strid)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objData.ReadDeductionListEdit(objEntitySalary, strid);
           return dtGuarnt;
       }
       public DataTable ReadAllounceListEdit(clsEntityLayerEmpSalary objEntitySalary, string strid)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objData.ReadAllounceListEdit(objEntitySalary, strid);
           return dtGuarnt;
       }
       public DataTable ReadPaymenDeductionList(cls_Entity_Monthly_Salary_Process objEntitySalary)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.ReadPaymenDeductionList(objEntitySalary);
          return dtGuarnt;
      }
            public DataTable ReadAllounceDailyhrList(cls_Entity_Monthly_Salary_Process objEntitySalary)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.ReadAllounceDailyhrList(objEntitySalary);
          return dtGuarnt;
      }

            public void InsertProssDtls(cls_Entity_Monthly_Salary_Process objEntitySalary, List<cls_Entity_Monthly_Salary_Process> OBJ, List<cls_Entity_Monthly_Salary_Process> ObjAllwance, List<cls_Entity_Monthly_Salary_Process> ObjDeductn)
            {
               // DataTable dtGuarnt = new DataTable();
                objData.InsertProssDtls(objEntitySalary, OBJ, ObjAllwance, ObjDeductn);
               // return dtGuarnt;
            }

            public DataTable LoadSalaryPrssListPrssTable(cls_Entity_Monthly_Salary_Process objEntitySalary)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.LoadSalaryPrssListPrssTable(objEntitySalary);
          return dtGuarnt;
      }
              public DataTable ReadAllounceListPrssTable(cls_Entity_Monthly_Salary_Process objEntitySalary)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.ReadAllounceListPrssTable(objEntitySalary);
          return dtGuarnt;
      }
              public DataTable ReadDeductionListPrssTable(cls_Entity_Monthly_Salary_Process objEntitySalary)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.ReadDeductionListPrssTable(objEntitySalary);
          return dtGuarnt;
      }


      public void ConfrmProssDtls(cls_Entity_Monthly_Salary_Process objEntitySalary, List<cls_Entity_Monthly_Salary_Process> OBJ, List<cls_Entity_Monthly_Salary_Process> OBJDailyHrList, List<cls_Entity_Monthly_Salary_Process> objDistinctPrjctList)
       {
           objData.ConfrmProssDtls(objEntitySalary, OBJ, OBJDailyHrList, objDistinctPrjctList);
       }
      //Below Section For Monthly Salary List Page


            public DataTable LoadMonthlySalList(cls_Entity_Monthly_Salary_Process objEntitySalary)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objData.LoadMonthlySalList(objEntitySalary);
          return dtGuarnt;
      }
        //Below Section For Monthly Salary Action Page

            public DataTable AllowncRestrictionChk(clsEntityLayerEmpSalary objEntitySalary)
            {
                DataTable dtGuarnt = new DataTable();
                dtGuarnt = objData.AllowncRestrictionChk(objEntitySalary);
                return dtGuarnt;
            }
            public DataTable DedctnRestrictionChk(clsEntityLayerEmpSalary objEntitySalary)
            {
                DataTable dtGuarnt = new DataTable();
                dtGuarnt = objData.DedctnRestrictionChk(objEntitySalary);
                return dtGuarnt;
            }
            public DataTable ReadAddnLoad(clsEntityLayerEmpSalary objEntitySalary)
            {
                DataTable dtGuarnt = new DataTable();
                dtGuarnt = objData.ReadAddnLoad(objEntitySalary);
                return dtGuarnt;
            }
            public DataTable ReadAllounceList(clsEntityLayerEmpSalary objEntitySalary)
            {
                DataTable dtGuarnt = new DataTable();
                dtGuarnt = objData.ReadAllounceList(objEntitySalary);
                return dtGuarnt;
            }
            public DataTable ReadDedctnList(clsEntityLayerEmpSalary objEntitySalary, string salProssId)
            {
                DataTable dtGuarnt = new DataTable();
                dtGuarnt = objData.ReadDedctnList(objEntitySalary, salProssId);
                return dtGuarnt;
            }

            public DataTable ReadAllounceById(clsEntityLayerEmpSalary objEntitySalary)
            {
                DataTable dtGuarnt = new DataTable();
                dtGuarnt = objData.ReadAllounceById(objEntitySalary);
                return dtGuarnt;
            }
            public void CancelAllownce(clsEntityLayerEmpSalary objEntitySalary)
            {
               objData.CancelAllownce(objEntitySalary);
               
            }
            public void CancelDedctn(clsEntityLayerEmpSalary objEntitySalary)
            {
             objData.CancelDedctn(objEntitySalary);
               
            }
            public DataTable ReadDedctnById(clsEntityLayerEmpSalary objEntitySalary)
            {
                DataTable dtGuarnt = new DataTable();
                dtGuarnt = objData.ReadDedctnById(objEntitySalary);
                return dtGuarnt;
            }
            public string DuplCheckSalaryAllownce(clsEntityLayerEmpSalary objEntitySalary)
            {
                string dtGuarnt ="";
                dtGuarnt = objData.DuplCheckSalaryAllownce(objEntitySalary);
                return dtGuarnt;
            }

            public string DuplCheckSalaryDedctn(clsEntityLayerEmpSalary objEntitySalary)
            {
                string dtGuarnt ="";
                dtGuarnt = objData.DuplCheckSalaryDedctn(objEntitySalary);
                return dtGuarnt;
            }


            public void AddSalaryDedction(clsEntityLayerEmpSalary objEntitySalary)
            {
             
                objData.AddSalaryDedction(objEntitySalary);
             
            }

            public void UpdateSalaryDedction(clsEntityLayerEmpSalary objEntitySalary)
            {

                objData.UpdateSalaryDedction(objEntitySalary);

            }
            public void AddSalaryAddnAllownce(clsEntityLayerEmpSalary objEntitySalary)
            {

                objData.AddSalaryAddnAllownce(objEntitySalary);

            }

            public void UpdSalaryAddnAllownce(clsEntityLayerEmpSalary objEntitySalary)
            {

                objData.UpdSalaryAddnAllownce(objEntitySalary);

            }

            public DataTable ReadDedctnLoad(clsEntityLayerEmpSalary objEntitySalary)
            {
                DataTable dtGuarnt = new DataTable();
                dtGuarnt = objData.ReadDedctnLoad(objEntitySalary);
                return dtGuarnt;
            }

      //BELOW SECTION FOR MONTHLY SALARY PAYMENT
            public DataTable LoadSalaryPrssPaymentTable(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtGuarnt = new DataTable();
                dtGuarnt = objData.LoadSalaryPrssPaymentTable(objEntitySalary);
                return dtGuarnt;
            }
            public DataTable GetArrearAmount(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtGuarnt = new DataTable();
                dtGuarnt = objData.GetArrearAmount(objEntitySalary);
                return dtGuarnt;
            }
            public void SaveSinglePayment(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {

                objData.SaveSinglePayment(objEntitySalary);

            }
            public void SaveAllPayment(List<cls_Entity_Monthly_Salary_Process> objEntitySalary)
            {

                objData.SaveAllPayment(objEntitySalary);

            }


            public DataTable ReadEmp_List_For_Print(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtEmp_List = new DataTable();
                dtEmp_List = objData.ReadEmp_List_For_Print(objEntitySalary);
                return dtEmp_List;
            }

            public DataTable ReadSalaryProssDtlsById(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtEmp_List = new DataTable();
                dtEmp_List = objData.ReadSalaryProssDtlsById(objEntitySalary);
                return dtEmp_List;
            }
            public DataTable ReadEmp_List_Holyday(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtEmp_List = new DataTable();
                dtEmp_List = objData.ReadEmp_List_Holyday(objEntitySalary);
                return dtEmp_List;
            }

            public DataTable ReadCorporateAddress(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtEmp_List = new DataTable();
                dtEmp_List = objData.ReadCorporateAddress(objEntitySalary);
                return dtEmp_List;
            }

            public DataTable ReadLeavListList(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtEmp_List = new DataTable();
                dtEmp_List = objData.ReadLeavListList(objEntitySalary);
                return dtEmp_List;
            }
            public DataTable ReadPrevLeav(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtEmp_List = new DataTable();
                dtEmp_List = objData.ReadPrevLeav(objEntitySalary);
                return dtEmp_List;
            }

            public DataTable ReadLeavSettlmentChk(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtEmp_List = new DataTable();
                dtEmp_List = objData.ReadLeavSettlmentChk(objEntitySalary);
                return dtEmp_List;
            }
            public DataTable ReadMessSettlement(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtEmp_List = new DataTable();
                dtEmp_List = objData.ReadMessSettlement(objEntitySalary);
                return dtEmp_List;
            }

            public DataTable ReadEmp_List_For_PaySlip_Print(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtEmp_List = new DataTable();
                dtEmp_List = objData.ReadEmp_List_For_PaySlip_Print(objEntitySalary);
                return dtEmp_List;
            }

            public DataTable ReadLeavSettlmentDat(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtEmp_List = new DataTable();
                dtEmp_List = objData.ReadLeavSettlmentDat(objEntitySalary);
                return dtEmp_List;
            }

            public DataTable ReadLeaveDate(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtEmp_List = new DataTable();
                dtEmp_List = objData.ReadLeaveDate(objEntitySalary);
                return dtEmp_List;
            }
            public DataTable ReadRejoinDate(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtLevSetlmt = new DataTable();
                dtLevSetlmt = objData.ReadRejoinDate(objEntitySalary);
                return dtLevSetlmt;
            }
            public DataTable ReadRejoinLeave(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtLevSetlmt = new DataTable();
                dtLevSetlmt = objData.ReadRejoinLeave(objEntitySalary);
                return dtLevSetlmt;
            }
            public DataTable ReadPrevLeaveDetails(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtLevSetlmt = new DataTable();
                dtLevSetlmt = objData.ReadPrevLeaveDetails(objEntitySalary);
                return dtLevSetlmt;
            }
            public DataTable ReadMonthlyLastDate(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtLevSetlmt = new DataTable();
                dtLevSetlmt = objData.ReadMonthlyLastDate(objEntitySalary);
                return dtLevSetlmt;
            }
            public DataTable ReadMonthlyLeaveForMultipleYrs(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtLevSetlmt = new DataTable();
                dtLevSetlmt = objData.ReadMonthlyLeaveForMultipleYrs(objEntitySalary);
                return dtLevSetlmt;
            }
            public DataTable ReadJoinDt(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtEmp = new DataTable();
                dtEmp = objData.ReadJoinDt(objEntitySalary);
                return dtEmp;
            }
            public DataTable ReadCorpSal(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dtLevSetlmt = new DataTable();
                dtLevSetlmt = objData.ReadCorpSal(objEntitySalary);
                return dtLevSetlmt;
            }
            public void DeleteMonthlySalaryProces(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                objData.DeleteMonthlySalaryProces(objEntitySalary);
            }
            public void DeleteMonthlySalaryProcesList(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                objData.DeleteMonthlySalaryProcesList(objEntitySalary);
            }
            public DataTable ReadDialyHourDtl(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dt = new DataTable();
                dt = objData.ReadDialyHourDtl(objEntitySalary);
                return dt;
            }

            public DataTable ReadEmpManualy_AdditionDetails(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dt = new DataTable();
                dt = objData.ReadEmpManualy_AdditionDetails(objEntitySalary);
                return dt;
            }

            public DataTable ReadEmpManualy_DeductionsDetails(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dt = new DataTable();
                dt = objData.ReadEmpManualy_DeductionsDetails(objEntitySalary);
                return dt;
            }

            public DataTable ReadEmpManualy_Add_Dedn_Details(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dt = new DataTable();
                dt = objData.ReadEmpManualy_Add_Dedn_Details(objEntitySalary);
                return dt;
            }

            public DataTable ReadEmpManualy_Add_Dedn_Dtls(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dt = new DataTable();
                dt = objData.ReadEmpManualy_Add_Dedn_Dtls(objEntitySalary);
                return dt;
            }

            public DataTable ReadEmpManualy_Add_Dedn(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dt = new DataTable();
                dt = objData.ReadEmpManualy_Add_Dedn(objEntitySalary);
                return dt;
            }
            public DataTable ReadArrearFromAtt(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dt = new DataTable();
                dt = objData.ReadArrearFromAtt(objEntitySalary);
                return dt;
            }
            public DataTable ReadLeaveCasualRejoin(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dt = new DataTable();
                dt = objData.ReadLeaveCasualRejoin(objEntitySalary);
                return dt;
            }
            public DataTable ReadLeaveCasualRejoinDate(cls_Entity_Monthly_Salary_Process objEntitySalary)
            {
                DataTable dt = new DataTable();
                dt = objData.ReadLeaveCasualRejoinDate(objEntitySalary);
                return dt;
            }
    }
}
