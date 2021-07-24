using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit;
using CL_Compzit;
using DL_Compzit;

namespace BL_Compzit
{
 public class clsBusinessLayerDependent
    {
        clsDataLayerDependent objDataLayerdependent = new clsDataLayerDependent();
        public DataTable ReadRelationship()
        {
            DataTable dtReadCountry = objDataLayerdependent.ReadRelationship();
            return dtReadCountry;
        }
        public void insertDependent(clsEntityLayerDependent objEntityDependent)
        {
            objDataLayerdependent.insertDependent(objEntityDependent);
        }
        public DataTable readDependentList(string id)
        {
            DataTable dtReadCountry = objDataLayerdependent.readDependentList(id);
            return dtReadCountry;
        }
        public DataTable ReadDepntById(clsEntityLayerDependent objEntityDependent)
        {
            DataTable dtReadCountry = objDataLayerdependent.ReadDepntById(objEntityDependent);
            return dtReadCountry;
        }
        public void updateDependent(clsEntityLayerDependent objEntityDependent)
        {
            objDataLayerdependent.updateDependent(objEntityDependent);
        } 
        public void DeleteDependent(clsEntityLayerDependent objEntityDependent)
        {
            objDataLayerdependent.DeleteDependent(objEntityDependent);
        }
    }
}
