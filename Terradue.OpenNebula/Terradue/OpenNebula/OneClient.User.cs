//
//  OneClient.User.cs
//
//  Author:
//       Enguerran Boissier <enguerran.boissier@terradue.com>
//
//  Copyright (c) 2014 Terradue

using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {
    /// <summary>
    /// DotNet4One Client calling XML-RPC requests exposed by an OpenNebula server.
    /// XML-RPC commands for User.
    /// </summary>
    public partial class OneClient {

        /// <summary>
        /// Gets the user list info.
        /// </summary>
        /// <returns>The user list info.</returns>
        public USER_POOL UserGetPoolInfo(){
            USER_POOL result = null;
            XmlRpcUserManagement xrum = (XmlRpcUserManagement)GetProxy(typeof(XmlRpcUserManagement));
            Array openNebulaReturnArr = xrum.oneUserPoolInfo(this.SessionSHA);
            result = (USER_POOL)Deserialize(typeof(USER_POOL), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }
            
        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <returns>The user info.</returns>
        /// <param name="id">Identifier.</param>
        public USER UserGetInfo(int id){
            USER result = null;
            XmlRpcUserManagement xrum = (XmlRpcUserManagement)GetProxy(typeof(XmlRpcUserManagement));
            Array openNebulaReturnArr = xrum.oneUserInfo(this.SessionSHA, id);
            result = (USER)Deserialize(typeof(USER), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

        /// <summary>
        /// Gets the connected user info.
        /// </summary>
        /// <returns>The user info.</returns>
        public USER UserGetInfo(){
            return UserGetInfo(-1);
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="authdriver">Authdriver.</param>
        public int UserAllocate(string username, string password, string authdriver){
            int result = 0;
            XmlRpcUserManagement xrum = (XmlRpcUserManagement)GetProxy(typeof(XmlRpcUserManagement));
            Array openNebulaReturnArr = xrum.oneUserAllocate(this.SessionSHA, username, password, authdriver);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="username">Username.</param>
        /// <param name="id">Identifier.</param>
        public bool UserDelete(int id){
            bool result = false;
            XmlRpcUserManagement xrum = (XmlRpcUserManagement)GetProxy(typeof(XmlRpcUserManagement));
            Array openNebulaReturnArr = xrum.oneUserDelete(this.SessionSHA, id);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Updates the user template.
        /// </summary>
        /// <returns><c>true</c>, if user template was updated, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="template">Template.</param>
        public bool UserUpdate(int id, string template){
            bool result = false;
            XmlRpcUserManagement xrum = (XmlRpcUserManagement)GetProxy(typeof(XmlRpcUserManagement));
            Array openNebulaReturnArr = xrum.oneUserUpdate(this.SessionSHA, id, template);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Updates the user password.
        /// </summary>
        /// <returns><c>true</c>, if user password was updated, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="newPassword">New password.</param>
        public bool UserUpdatePassword(int id, string newPassword){
            bool result = false;
            XmlRpcUserManagement xrum = (XmlRpcUserManagement)GetProxy(typeof(XmlRpcUserManagement));
            Array openNebulaReturnArr = xrum.oneUserPassword(this.SessionSHA, id, newPassword);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Updates the user quota.
        /// </summary>
        /// <returns><c>true</c>, if user quota was updated, <c>false</c> otherwise.</returns>
        /// <param name="id">User Identifier.</param>
        /// <param name="newQuota">New quota.</param>
        public bool UserUpdateQuota(int id, string newQuota){
            bool result = false;
            XmlRpcUserManagement xrum = (XmlRpcUserManagement)GetProxy(typeof(XmlRpcUserManagement));
            Array openNebulaReturnArr = xrum.oneUserQuota(this.SessionSHA, id, newQuota);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Updates the user group.
        /// </summary>
        /// <returns><c>true</c>, if user group was updated, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="newGrpId">New group identifier.</param>
        public bool UserUpdateGroup(int id, int newGrpId){
            bool result = false;
            XmlRpcUserManagement xrum = (XmlRpcUserManagement)GetProxy(typeof(XmlRpcUserManagement));
            Array openNebulaReturnArr = xrum.oneUserChangeGroup(this.SessionSHA, id, newGrpId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Adds the user to a secondarygroup.
        /// </summary>
        /// <returns><c>true</c>, if user to group was added, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="newGrpId">New group identifier.</param>
        public bool UserAddGroup(int id, int newGrpId){
            bool result = false;
            XmlRpcUserManagement xrum = (XmlRpcUserManagement)GetProxy(typeof(XmlRpcUserManagement));
            Array openNebulaReturnArr = xrum.oneUserAddGroup(this.SessionSHA, id, newGrpId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Removes the user from a secondary group.
        /// </summary>
        /// <returns><c>true</c>, if user from group was removed, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="grpId">Group identifier.</param>
        public bool UserDeleteGroup(int id, int grpId){
            bool result = false;
            XmlRpcUserManagement xrum = (XmlRpcUserManagement)GetProxy(typeof(XmlRpcUserManagement));
            Array openNebulaReturnArr = xrum.oneUserDelGroup(this.SessionSHA, id, grpId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Changes the user authentication driver and the password 
        /// </summary>
        /// <returns><c>true</c>, if user auth was changed, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="newAuthDriver">New auth driver.</param>
        /// <param name="newPassword">New password.</param>
        public bool UserChangeAuth(int id, string newAuthDriver, string newPassword){
            bool result = false;
            XmlRpcUserManagement xrum = (XmlRpcUserManagement)GetProxy(typeof(XmlRpcUserManagement));
            Array openNebulaReturnArr = xrum.oneUserChauth(this.SessionSHA, id, newAuthDriver, newPassword);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Get the Users quota info.
        /// </summary>
        /// <returns>The quota info.</returns>
        public USERDEFAULT_USER_QUOTAS UserGetQuotaInfo(){
            USERDEFAULT_USER_QUOTAS result = null;
            XmlRpcUserManagement xrum = (XmlRpcUserManagement)GetProxy(typeof(XmlRpcUserManagement));
            Array openNebulaReturnArr = xrum.oneUserQuotaInfo(this.SessionSHA);
            result = (USERDEFAULT_USER_QUOTAS)Deserialize(typeof(USERDEFAULT_USER_QUOTAS), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

        /// <summary>
        /// Updates the user quota.
        /// </summary>
        /// <returns>The user quota.</returns>
        /// <param name="newQuotaTemplate">New quota template.</param>
        public USERDEFAULT_USER_QUOTAS UserUpdateQuota(string newQuotaTemplate){
            USERDEFAULT_USER_QUOTAS result = null;
            XmlRpcUserManagement xrum = (XmlRpcUserManagement)GetProxy(typeof(XmlRpcUserManagement));
            Array openNebulaReturnArr = xrum.oneUserQuotaUpdate(this.SessionSHA, newQuotaTemplate);
            result = (USERDEFAULT_USER_QUOTAS)Deserialize(typeof(USERDEFAULT_USER_QUOTAS), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

    }
}

