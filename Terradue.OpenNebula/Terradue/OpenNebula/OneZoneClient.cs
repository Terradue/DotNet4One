using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    public class OneZoneClient : OneClient {

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.OpenNebula.OneZoneClient"/> class.
        /// </summary>
        /// <param name="adminUsername">Admin username.</param>
        /// <param name="adminPassword">Admin password.</param>
        public OneZoneClient(string adminUsername, string adminPassword) : base(adminUsername, adminPassword){}
       
        /// <summary>
        /// Allocates the zone.
        /// </summary>
        /// <returns>The zone.</returns>
        /// <param name="zonename">Zonename.</param>
        public int AllocateZone(string zonename){
            int result = 0;
            XmlRpcZoneManagement xrum = XmlRpcProxyGen.Create<XmlRpcZoneManagement>();
            Array openNebulaReturnArr = xrum.oneZoneAllocate(this.SessionSHA, zonename);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Deletes the zone.
        /// </summary>
        /// <returns><c>true</c>, if zone was deleted, <c>false</c> otherwise.</returns>
        /// <param name="zoneId">Zone identifier.</param>
        public bool DeleteZone(int zoneId){
            bool result = false;
            XmlRpcZoneManagement xrum = XmlRpcProxyGen.Create<XmlRpcZoneManagement>();
            Array openNebulaReturnArr = xrum.oneZoneDelete(this.SessionSHA, zoneId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }
       
        /// <summary>
        /// Updates the zone.
        /// </summary>
        /// <returns><c>true</c>, if zone was updated, <c>false</c> otherwise.</returns>
        /// <param name="zoneId">Zone identifier.</param>
        public bool UpdateZone(int zoneId, string template, int type){
            bool result = false;
            XmlRpcZoneManagement xrum = XmlRpcProxyGen.Create<XmlRpcZoneManagement>();
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
        public bool RenameZone(int zoneId, string newName){
            bool result = false;
            XmlRpcZoneManagement xrum = XmlRpcProxyGen.Create<XmlRpcZoneManagement>();
            Array openNebulaReturnArr = xrum.oneZoneRename(this.SessionSHA, zoneId, newName);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Gets the zone info.
        /// </summary>
        /// <returns>The zone info.</returns>
        /// <param name="zoneId">Zone identifier.</param>
        public object GetZoneInfo(int zoneId){
            throw new NotImplementedException("ZONE class not defined in XSD");
        }

        /// <summary>
        /// Gets the zone pool info.
        /// </summary>
        /// <returns>The zone pool info.</returns>
        public object GetZoneListInfo(){
            throw new NotImplementedException("ZONE class not defined in XSD");
        }
    }
}

