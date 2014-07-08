using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    public partial class OneClient {

        /// <summary>
        /// Allocates the group.
        /// </summary>
        /// <returns>The group.</returns>
        /// <param name="groupname">Groupname.</param>
        public int GroupAllocate(string groupname){
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
        public bool GroupDelete(int groupId){
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
        public GROUP_POOLGROUP GroupGetInfo(int id){
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
        public bool GroupUpdate(int groupId, string templateContent, int type){
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
        public bool GroupSetQuota(int groupId, string templateContent){
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
        public bool GroupAddProvider(int groupId, int zoneId, int clusterId){
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
        public bool GroupDeleteProvider(int groupId, int zoneId, int clusterId){
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
        public GROUP_POOL GroupGetPoolInfo(){
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
        public GROUP_POOLQUOTAS GroupGetDefaultQuotaInfo(){
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
        public GROUP_POOLQUOTAS GroupUpdateDefaultQuotaInfo(string contentTemplate){
            GROUP_POOLQUOTAS result = null;
            XmlRpcGroupManagement xrum = XmlRpcProxyGen.Create<XmlRpcGroupManagement>();
            Array openNebulaReturnArr = xrum.oneGroupQuotaUpdate(this.SessionSHA, contentTemplate);
            result = (GROUP_POOLQUOTAS)Deserialize(typeof(GROUP_POOLQUOTAS), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }
    }
}

