using System;
using System.Net;
using System.IO;
using ServiceStack.Text;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    public class OneUserClient : OneClient {

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.OpenNebula.OneUserClient"/> class.
        /// </summary>
        /// <param name="adminUsername">Admin username.</param>
        /// <param name="adminPassword">Admin password.</param>
        public OneUserClient(string adminUsername, string adminPassword) : base(adminUsername, adminPassword){}

        /// <summary>
        /// Gets the user list info.
        /// </summary>
        /// <returns>The user list info.</returns>
        public USER_POOL GetUserListInfo(){
            USER_POOL result = null;
            XmlRpcUserManagement xrum = XmlRpcProxyGen.Create<XmlRpcUserManagement>();
            Array openNebulaReturnArr = xrum.oneUserPoolInfo(this.SessionSHA);
            result = (USER_POOL)Deserialize(typeof(USER_POOL), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }
            
        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <returns>The user info.</returns>
        /// <param name="id">Identifier.</param>
        public USER GetUserInfo(int id){
            USER result = null;
            XmlRpcUserManagement xrum = XmlRpcProxyGen.Create<XmlRpcUserManagement>();
            Array openNebulaReturnArr = xrum.oneUserInfo(this.SessionSHA, id);
            result = (USER)Deserialize(typeof(USER), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

        /// <summary>
        /// Gets the connected user info.
        /// </summary>
        /// <returns>The user info.</returns>
        public USER GetUserInfo(){
            return GetUserInfo(-1);
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="authdriver">Authdriver.</param>
        public int CreateUser(string username, string password, string authdriver){
            int result = 0;
            XmlRpcUserManagement xrum = XmlRpcProxyGen.Create<XmlRpcUserManagement>();
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
        public bool DeleteUser(int id){
            bool result = false;
            XmlRpcUserManagement xrum = XmlRpcProxyGen.Create<XmlRpcUserManagement>();
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
        public bool UpdateUserTemplate(int id, string template){
            bool result = false;
            XmlRpcUserManagement xrum = XmlRpcProxyGen.Create<XmlRpcUserManagement>();
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
        public bool UpdateUserPassword(int id, string newPassword){
            bool result = false;
            XmlRpcUserManagement xrum = XmlRpcProxyGen.Create<XmlRpcUserManagement>();
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
        public bool UpdateUserQuota(int id, string newQuota){
            bool result = false;
            XmlRpcUserManagement xrum = XmlRpcProxyGen.Create<XmlRpcUserManagement>();
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
        public bool UpdateUserGroup(int id, int newGrpId){
            bool result = false;
            XmlRpcUserManagement xrum = XmlRpcProxyGen.Create<XmlRpcUserManagement>();
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
        public bool AddUserToGroup(int id, int newGrpId){
            bool result = false;
            XmlRpcUserManagement xrum = XmlRpcProxyGen.Create<XmlRpcUserManagement>();
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
        public bool RemoveUserFromGroup(int id, int grpId){
            bool result = false;
            XmlRpcUserManagement xrum = XmlRpcProxyGen.Create<XmlRpcUserManagement>();
            Array openNebulaReturnArr = xrum.oneUserDelGroup(this.SessionSHA, id, grpId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

    }
}

