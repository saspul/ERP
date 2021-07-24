// Copyright 2001-2010 - Active Up SPRLU (http://www.agilecomponents.com)
//
// This file is part of MailSystem.NET.
// MailSystem.NET is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// MailSystem.NET is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with SharpMap; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveUp.Net.Dns
{
    class IsdnRecord : IRecordData
    {
        /// <summary>
        /// Implementation Reference RFC 1183
        /// </summary>
        /// <param name="buffer"></param>
         public IsdnRecord(DataBuffer buffer)
        {
            isdnAddress = buffer.ReadCharString();
            subAddress = buffer.ReadCharString();
        }
        /// <summary>
        /// Converts this data record to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("ISDN Address:{0} Sub Address:{1}", isdnAddress, subAddress);
        }

        private string isdnAddress;        
        /// <summary>
        /// Isdn Address of record
        /// </summary>
        public string IsdnAddress       {            get { return isdnAddress; }       }
        private string subAddress;
        /// <summary>
        /// Sub Address of record
        /// </summary>
        public string SubAddress        {            get { return subAddress; }        }
    }
}
