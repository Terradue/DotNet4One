using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    public partial class OneClient {
               
        /// <summary>
        /// Allocates the zone.
        /// </summary>
        /// <returns>The zone.</returns>
        /// <param name="zonename">Zonename.</param>
        public int ZoneAllocate(string zonename){
            int result = 0;
            XmlRpcZoneManagement xrum = (XmlRpcZoneManagement)GetProxy(typeof(XmlRpcZoneManagement));
            Array openNebulaReturnArr = xrum.oneZoneAllocate(this.SessionSHA, zonename);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Deletes the zone.
        /// </summary>
        /// <returns><c>true</c>, if zone was deleted, <c>false</c> otherwise.</returns>
        /// <param name="zoneId">Zone identifier.</param>
        public bool ZoneDelete(int zoneId){
            bool result = false;
            XmlRpcZoneManagement xrum = (XmlRpcZoneManagement)GetProxy(typeof(XmlRpcZoneManagement));
            Array openNebulaReturnArr = xrum.oneZoneDelete(this.SessionSHA, zoneId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }
       
        /// <summary>
        /// Updates the zone.
        /// </summary>
        /// <returns><c>true</c>, if zone was updated, <c>false</c> otherwise.</returns>
        /// <param name="zoneId">Zone identifier.</param>
        public bool ZoneUpdate(int zoneId, string template, int type){
            bool result = false;
            XmlRpcZoneManagement xrum = (XmlRpcZoneManagement)GetProxy(typeof(XmlRpcZoneManagement));
            Array openNebulaReturnArr = xrum.oneZoneUpdate(this.SessionSHA, zoneId, template, type);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Renames the zone.
        /// </summary>
        /// <returns><c>true</c>, if zone was renamed, <c>false</c> otherwise.</returns>
        /// <param name="zoneId">Zone identifier.</param>
        /// <param name="newName">New name.</param>
        public bool ZoneRename(int zoneId, string newName){
            bool result = false;
            XmlRpcZoneManagement xrum = (XmlRpcZoneManagement)GetProxy(typeof(XmlRpcZoneManagement));
            Array openNebulaReturnArr = xrum.oneZoneRename(this.SessionSHA, zoneId, newName);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Gets the zone info.
        /// </summary>
        /// <returns>The zone info.</returns>
        /// <param name="zoneId">Zone identifier.</param>
        public object ZoneGetInfo(int zoneId){
            throw new NotImplementedException("ZONE class not defined in XSD");
        }

        /// <summary>
        /// Gets the zone pool info.
        /// </summary>
        /// <returns>The zone pool info.</returns>
        public object ZoneGetZonePoolInfo(){
            throw new NotImplementedException("ZONE class not defined in XSD");
        }
    }
}

