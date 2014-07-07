using System;
using System.Net;
using System.IO;
using ServiceStack.Text;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    public class OneGroupClient : OneClient {

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.OpenNebula.OneGroupClient"/> class.
        /// </summary>
        /// <param name="adminUsername">Admin username.</param>
        /// <param name="adminPassword">Admin password.</param>
        public OneGroupClient(string adminUsername, string adminPassword) : base(adminUsername, adminPassword){}
       
        /// <summary>
        /// Allocates the group.
        /// </summary>
        /// <returns>The group.</returns>
        /// <param name="groupname">Groupname.</param>
        public int AllocateGroup(string groupname){
            int result = 0;
            XmlRpcGroupManagement xrum = XmlRpcProxyGen.Create<XmlRpcGroupManagement>();
            Array openNebulaReturnArr = xrum.oneGroupAllocate(this.SessionSHA, groupname);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Deletes the group.
        /// </summary>
        /// <returns><c>true</c>, if group was deleted, <c>false</c> otherwise.</returns>
        /// <param name="groupId">Group identifier.</param>
        public bool DeleteGroup(int groupId){
            bool result = false;
            XmlRpcGroupManagement xrum = XmlRpcProxyGen.Create<XmlRpcGroupManagement>();
            Array openNebulaReturnArr = xrum.oneGroupDelete(this.SessionSHA, groupId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Gets the group info.
        /// </summary>
        /// <returns>The group info.</returns>
        /// <param name="id">Identifier.</param>
        public GROUP_POOLGROUP GetGroupInfo(int id){
            GROUP_POOLGROUP result = null;
            XmlRpcGroupManagement xrum = XmlRpcProxyGen.Create<XmlRpcGroupManagement>();
            Array openNebulaReturnArr = xrum.oneGroupInfo(this.SessionSHA, id);
            result = (GROUP_POOLGROUP)Deserialize(typeof(GROUP_POOLGROUP), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

        /// <summary>
        /// Updates the group.
        /// </summary>
        /// <returns><c>true</c>, if group was updated, <c>false</c> otherwise.</returns>
        /// <param name="groupId">Group identifier.</param>
        /// <param name="templateContent">Template content.</param>
        /// <param name="type">Type.</param>
        public bool UpdateGroup(int groupId, string templateContent, int type){
            bool result = false;
            XmlRpcGroupManagement xrum = XmlRpcProxyGen.Create<XmlRpcGroupManagement>();
            Array openNebulaReturnArr = xrum.oneGroupUpdate(this.SessionSHA, groupId, templateContent, type);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Sets the group quota.
        /// </summary>
        /// <returns><c>true</c>, if group quota was set, <c>false</c> otherwise.</returns>
        /// <param name="groupId">Group identifier.</param>
        /// <param name="templateContent">Template content.</param>
        public bool SetGroupQuota(int groupId, string templateContent){
            bool result = false;
            XmlRpcGroupManagement xrum = XmlRpcProxyGen.Create<XmlRpcGroupManagement>();
            Array openNebulaReturnArr = xrum.oneGroupQuota(this.SessionSHA, groupId, templateContent);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Adds the provider to group.
        /// </summary>
        /// <returns><c>true</c>, if provider to group was added, <c>false</c> otherwise.</returns>
        /// <param name="groupId">Group identifier.</param>
        /// <param name="zoneId">Zone identifier.</param>
        /// <param name="clusterId">Cluster identifier.</param>
        public bool AddProviderToGroup(int groupId, int zoneId, int clusterId){
            bool result = false;
            XmlRpcGroupManagement xrum = XmlRpcProxyGen.Create<XmlRpcGroupManagement>();
            Array openNebulaReturnArr = xrum.oneGroupAddProvider(this.SessionSHA, groupId, zoneId, clusterId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Deletes the provider from group.
        /// </summary>
        /// <returns><c>true</c>, if provider from group was deleted, <c>false</c> otherwise.</returns>
        /// <param name="groupId">Group identifier.</param>
        /// <param name="zoneId">Zone identifier.</param>
        /// <param name="clusterId">Cluster identifier.</param>
        public bool DeleteProviderFromGroup(int groupId, int zoneId, int clusterId){
            bool result = false;
            XmlRpcGroupManagement xrum = XmlRpcProxyGen.Create<XmlRpcGroupManagement>();
            Array openNebulaReturnArr = xrum.oneGroupDeleteProvider(this.SessionSHA, groupId, zoneId, clusterId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Gets the group list info.
        /// </summary>
        /// <returns>The group list info.</returns>
        public GROUP_POOL GetGroupListInfo(){
            GROUP_POOL result = null;
            XmlRpcGroupManagement xrum = XmlRpcProxyGen.Create<XmlRpcGroupManagement>();
            Array openNebulaReturnArr = xrum.oneGroupPoolInfo(this.SessionSHA);
            result = (GROUP_POOL)Deserialize(typeof(GROUP_POOL), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

        /// <summary>
        /// Gets the default group quota info.
        /// </summary>
        /// <returns>The default group quota info.</returns>
        public GROUP_POOLQUOTAS GetDefaultGroupQuotaInfo(){
            GROUP_POOLQUOTAS result = null;
            XmlRpcGroupManagement xrum = XmlRpcProxyGen.Create<XmlRpcGroupManagement>();
            Array openNebulaReturnArr = xrum.oneGroupQuotaInfo(this.SessionSHA);
            result = (GROUP_POOLQUOTAS)Deserialize(typeof(GROUP_POOLQUOTAS), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

        /// <summary>
        /// Updates the default group quota info.
        /// </summary>
        /// <returns>The default group quota info.</returns>
        /// <param name="contentTemplate">Content template.</param>
        public GROUP_POOLQUOTAS UpdateDefaultGroupQuotaInfo(string contentTemplate){
            GROUP_POOLQUOTAS result = null;
            XmlRpcGroupManagement xrum = XmlRpcProxyGen.Create<XmlRpcGroupManagement>();
            Array openNebulaReturnArr = xrum.oneGroupQuotaUpdate(this.SessionSHA, contentTemplate);
            result = (GROUP_POOLQUOTAS)Deserialize(typeof(GROUP_POOLQUOTAS), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }
    }
}

