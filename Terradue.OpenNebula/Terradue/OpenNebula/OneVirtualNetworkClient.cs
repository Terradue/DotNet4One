using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    public class OneVirtualNetworkClient : OneClient {

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.OpenNebula.OneVirtualNetworkClient"/> class.
        /// </summary>
        /// <param name="adminUsername">Admin username.</param>
        /// <param name="adminPassword">Admin password.</param>
        public OneVirtualNetworkClient(string adminUsername, string adminPassword) : base(adminUsername, adminPassword){}


        /// <summary>
        /// Adds the lease to VN
        /// </summary>
        /// <returns><c>true</c>, if lease was added, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="leaseTemplate">Lease template.</param>
        public bool AddLeaseToVN(int id, string leaseTemplate){
            bool result = false;
            XmlRpcVirtualNetworkManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualNetworkManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualNetworkAddLeases(this.SessionSHA, id, leaseTemplate);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Holds a virtual network Lease as used.
        /// </summary>
        /// <returns><c>true</c>, if VN was held, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="holdTemplate">Hold template.</param>
        public bool HoldVN(int id, string holdTemplate){
            bool result = false;
            XmlRpcVirtualNetworkManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualNetworkManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualNetworkHold(this.SessionSHA, id, holdTemplate);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Releases a virtual network Lease on hold.
        /// </summary>
        /// <returns><c>true</c>, if V was released, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="releaseTemplate">Release template.</param>
        public bool ReleaseVN(int id, string releaseTemplate){
            bool result = false;
            XmlRpcVirtualNetworkManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualNetworkManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualNetworkRelease(this.SessionSHA, id, releaseTemplate);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Gets the VN info.
        /// </summary>
        /// <returns>The VN info.</returns>
        /// <param name="id">Identifier.</param>
        public VNET GetVNInfo(int id){
            VNET result = null;
            XmlRpcVirtualNetworkManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualNetworkManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualNetworkInfo(this.SessionSHA, id);
            result = (VNET)Deserialize(typeof(VNET), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }


        /// <summary>
        /// Gets the VN list info.
        /// </summary>
        /// <returns>The VN list info.</returns>
        /// <param name="templateFilterFlag">Template filter flag.</param>
        /// <param name="rangeStartId">Range start identifier.</param>
        /// <param name="rangeEndId">Range end identifier.</param>
        public VNET_POOL GetVNListInfo(int templateFilterFlag, int rangeStartId, int rangeEndId){
            VNET_POOL result = null;
            XmlRpcVirtualNetworkManagement xrum = XmlRpcProxyGen.Create<XmlRpcVirtualNetworkManagement>();
            Array openNebulaReturnArr = xrum.oneVirtualNetworkPoolInfo(this.SessionSHA, templateFilterFlag, rangeStartId, rangeEndId);
            result = (VNET_POOL)Deserialize(typeof(VNET_POOL), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

       
    }
}

