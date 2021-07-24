using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    public class clsEntityApprovalConsole
    {
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intUserId = 0;
        private int intEmployeeId = 0;
        private int intStatus = 0;
        private int intDocId = 0;
        private DateTime dFromDate;
        private DateTime dToDate;
        private int intPurchsOrdrId = 0;
        private string strRefNo = "";
        private DateTime dOrderDate;
        private string strRejectReason = "";
        private int intWrkFlowId = 0;
        //----------------Pageination--------------------
        private string strCommonSearchTerm = "";
        private string strSearchRef = "";
        private string strSearchWrkflw = "";
        private string strSearchDocumnt = "";
        private string strSearchDate = "";
        private string strSearchReqstor = "";
        private int intOrderColumn = 0;
        private int intOrderMethod = 0;
        private int intPageMaxSize = 0;
        private int intPageNumber = 0;
        //----------------Pageination--------------------
        private int intMode = 0;
        private int intDesignatnId = 0;
        private int intConditionId = 0;
        private string strConditionValues = "";
        private int intConditionMaxVal = 0;
        private int intConditionMinVal = 0;
        private int intConditionType = 0;
        private int intLevel = 0;
        private string strEmployeeIds = "";
        private int intVisibleSts = 0;
        private string strComment = "";
        private string strFileName = "";
        private string strActualFileName = "";
        private string strDescrptn = "";
        private string strNoteMsg = "";
        private int intReplySts = 0;
        private int intNoteId = 0;
        private int intApprvlCnslId = 0;
        private int intAdditionalId = 0;

        public int AdditionalId
        {
            get
            {
                return intAdditionalId;
            }
            set
            {
                intAdditionalId = value;
            }
        }
        public int ApprvlCnslId
        {
            get
            {
                return intApprvlCnslId;
            }
            set
            {
                intApprvlCnslId = value;
            }
        }
        public int NoteId
        {
            get
            {
                return intNoteId;
            }
            set
            {
                intNoteId = value;
            }
        }
        public int ReplySts
        {
            get
            {
                return intReplySts;
            }
            set
            {
                intReplySts = value;
            }
        }
        public string NoteMsg
        {
            get
            {
                return strNoteMsg;
            }
            set
            {
                strNoteMsg = value;
            }
        }
        public string Descrptn
        {
            get
            {
                return strDescrptn;
            }
            set
            {
                strDescrptn = value;
            }
        }
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
        public string Comment
        {
            get
            {
                return strComment;
            }
            set
            {
                strComment = value;
            }
        }
        public int VisibleSts
        {
            get
            {
                return intVisibleSts;
            }
            set
            {
                intVisibleSts = value;
            }
        }
        public string EmployeeIds
        {
            get
            {
                return strEmployeeIds;
            }
            set
            {
                strEmployeeIds = value;
            }
        }
        public int Level
        {
            get
            {
                return intLevel;
            }
            set
            {
                intLevel = value;
            }
        }
        public int ConditionType
        {
            get
            {
                return intConditionType;
            }
            set
            {
                intConditionType = value;
            }
        }
        public int ConditionMinVal
        {
            get
            {
                return intConditionMinVal;
            }
            set
            {
                intConditionMinVal = value;
            }
        }
        public int ConditionMaxVal
        {
            get
            {
                return intConditionMaxVal;
            }
            set
            {
                intConditionMaxVal = value;
            }
        }
        public string ConditionValues
        {
            get
            {
                return strConditionValues;
            }
            set
            {
                strConditionValues = value;
            }
        }
        public int ConditionId
        {
            get
            {
                return intConditionId;
            }
            set
            {
                intConditionId = value;
            }
        }
        public int DesignatnId
        {
            get
            {
                return intDesignatnId;
            }
            set
            {
                intDesignatnId = value;
            }
        }
        public int Mode
        {
            get
            {
                return intMode;
            }
            set
            {
                intMode = value;
            }
        }
        //----------------Pageination--------------------
        public string CommonSearchTerm
        {
            get
            {
                return strCommonSearchTerm;
            }
            set
            {
                strCommonSearchTerm = value;
            }
        }
        public string SearchRef
        {
            get
            {
                return strSearchRef;
            }
            set
            {
                strSearchRef = value;
            }
        }
        public string SearchWrkflw
        {
            get
            {
                return strSearchWrkflw;
            }
            set
            {
                strSearchWrkflw = value;
            }
        }
        public string SearchDocumnt
        {
            get
            {
                return strSearchDocumnt;
            }
            set
            {
                strSearchDocumnt = value;
            }
        }
        public string SearchDate
        {
            get
            {
                return strSearchDate;
            }
            set
            {
                strSearchDate = value;
            }
        }
        public string SearchReqstor
        {
            get
            {
                return strSearchReqstor;
            }
            set
            {
                strSearchReqstor = value;
            }
        }
        public int OrderColumn
        {
            get
            {
                return intOrderColumn;
            }
            set
            {
                intOrderColumn = value;
            }
        }
        public int OrderMethod
        {
            get
            {
                return intOrderMethod;
            }
            set
            {
                intOrderMethod = value;
            }
        }
        public int PageMaxSize
        {
            get
            {
                return intPageMaxSize;
            }
            set
            {
                intPageMaxSize = value;
            }
        }
        public int PageNumber
        {
            get
            {
                return intPageNumber;
            }
            set
            {
                intPageNumber = value;
            }
        }
        //----------------Pageination--------------------
        public int WrkFlowId
        {
            get
            {
                return intWrkFlowId;
            }
            set
            {
                intWrkFlowId = value;
            }
        }
        public string RejectReason
        {
            get
            {
                return strRejectReason;
            }
            set
            {
                strRejectReason = value;
            }
        }
        public DateTime OrderDate
        {
            get
            {
                return dOrderDate;
            }
            set
            {
                dOrderDate = value;
            }
        }
        public string RefNo
        {
            get
            {
                return strRefNo;
            }
            set
            {
                strRefNo = value;
            }
        }
        public int PurchsOrdrId
        {
            get
            {
                return intPurchsOrdrId;
            }
            set
            {
                intPurchsOrdrId = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return dToDate;
            }
            set
            {
                dToDate = value;
            }
        }
        public DateTime FromDate
        {
            get
            {
                return dFromDate;
            }
            set
            {
                dFromDate = value;
            }
        }
        public int DocId
        {
            get
            {
                return intDocId;
            }
            set
            {
                intDocId = value;
            }
        }
        public int Status
        {
            get
            {
                return intStatus;
            }
            set
            {
                intStatus = value;
            }
        }

        public int EmployeeId
        {
            get
            {
                return intEmployeeId;
            }
            set
            {
                intEmployeeId = value;
            }
        }
        public int UserId
        {
            get
            {
                return intUserId;
            }
            set
            {
                intUserId = value;
            }
        }
        public int OrgId
        {
            get
            {
                return intOrgId;
            }
            set
            {
                intOrgId = value;
            }
        }
        public int CorpId
        {
            get
            {
                return intCorpId;
            }
            set
            {
                intCorpId = value;
            }
        }

    }
}
