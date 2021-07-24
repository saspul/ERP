using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
   public class clsEntityLayerQuotationAttchmntDtl
   {
       private int intQtnAttchmntDtlId = 0;     
       private string strFileName = "";
       private string strActualFileName = "";
       private int intQtnAttchmntSlNumber = 0;
       private int intQuotationId = 0;
       private int intCorpOffice_Id = 0;
       private int intQtnFileType = 0;
       private int intAttchWthMailsts = 0;
       //property of storing mail attachment sts
       public int AttchWthMailsts
       {
           get
           {
               return intAttchWthMailsts;
           }
           set
           {
               intAttchWthMailsts = value;
           }
       }
       //property of storing Detail id of Quotation attachment
       public int QtnAttchmntDtlId
       {
           get
           {
               return intQtnAttchmntDtlId;
           }
           set
           {
               intQtnAttchmntDtlId = value;
           }
       }


       //Property of storing the file name of attachment
       public string FileName
       {
           get
           {
               return strFileName;
           }
           set
           {
               strFileName = value;
           }
       }
       //property of storing actual file name of attachment 
       public string ActualFileName
       {
           get
           {
               return strActualFileName;
           }
           set
           {
               strActualFileName = value;
           }
       }
       //property of storing Slnumber of Quotation attachment
       public int QtnAttchmntSlNumber
       {
           get
           {
               return intQtnAttchmntSlNumber;
           }
           set
           {
               intQtnAttchmntSlNumber = value;
           }
       }

       public int QuotationId
       {
           get
           {
               return intQuotationId;
           }
           set
           {
               intQuotationId = value;
           }
       }
       public int CorpOffice_Id
       {
           get
           {
               return intCorpOffice_Id;
           }
           set
           {
               intCorpOffice_Id = value;
           }
       }

       public int QtnFileType
       {
           get
           {
               return intQtnFileType;
           }
           set
           {
               intQtnFileType = value;
           }
       }
    }
}
