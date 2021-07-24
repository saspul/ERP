using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL_Compzit.BusineesLayer_HCM
{

   public class clsBusiness_Memo_Reason
    {
       clsData_Memo_Reason_Master objDataLayeMemoReason = new clsData_Memo_Reason_Master();

       public void AddMemoReason(clsEntity_Memo_Reason_Master objEntityMemoReason)
       {
           objDataLayeMemoReason.AddMemoReason(objEntityMemoReason);

       }

       public DataTable ReadLMemoResn(clsEntity_Memo_Reason_Master objEntityMemoReason)
       {
           DataTable dtReadMemoResn = objDataLayeMemoReason.ReadLMemoResn(objEntityMemoReason);
           return dtReadMemoResn;
       }
       public DataTable ReadLMemoResnById(clsEntity_Memo_Reason_Master objEntityMemoReason)
       {
           DataTable dtReadLMemoResnById = objDataLayeMemoReason.ReadLMemoResnById(objEntityMemoReason);
           return dtReadLMemoResnById;
       }
       public void UpdateMemoReason(clsEntity_Memo_Reason_Master objEntityMemoReason)
       {
           objDataLayeMemoReason.UpdateMemoReason(objEntityMemoReason);

       }

       public void CancelMemoReason(clsEntity_Memo_Reason_Master objEntityMemoReason)
       {
           objDataLayeMemoReason.CancelMemoReason(objEntityMemoReason);

       }
       public DataTable ReadMemoResnList(clsEntity_Memo_Reason_Master objEntityMemoReason)
       {
           DataTable dtReadLMemoResnById = objDataLayeMemoReason.ReadMemoResnList(objEntityMemoReason);
           return dtReadLMemoResnById;
       }
       public void ChangeMemoStatus(clsEntity_Memo_Reason_Master objEntityMemoReason)
       {
           objDataLayeMemoReason.ChangeMemoStatus(objEntityMemoReason);

       }
       public string CheckCategoryName(clsEntity_Memo_Reason_Master objEntityMemoReason)
       {
           string count = objDataLayeMemoReason.CheckCategoryName(objEntityMemoReason);
           return count;
       }
    }
}
