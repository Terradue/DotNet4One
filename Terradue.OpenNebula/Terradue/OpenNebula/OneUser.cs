using System;
using System.Net;
using System.IO;
using ServiceStack.Text;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    public class OneUser {

        /// <summary>
        /// Gets or sets the admin username.
        /// </summary>
        /// <value>The admin username.</value>
        string AdminUsername { get; set; }

        /// <summary>
        /// Gets or sets the admin password.
        /// </summary>
        /// <value>The admin password.</value>
        string AdminPassword { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.OpenNebula.OneUser"/> class.
        /// </summary>
        /// <param name="adminUsername">Admin username.</param>
        /// <param name="adminPassword">Admin password.</param>
        public OneUser(string adminUsername, string adminPassword) {
            this.AdminUsername = adminUsername;
            this.AdminPassword = adminPassword;
        }

        /// <summary>
        /// Gets the user list info.
        /// </summary>
        /// <returns>The user list info.</returns>
        public USER_POOL GetUserListInfo(){
            USER_POOL result = null;

            XmlRpcUserManagement xrum = XmlRpcProxyGen.Create<XmlRpcUserManagement>();
            Array openNebulaReturnArr = xrum.oneUserPoolInfo(this.AdminUsername+":"+this.AdminPassword);

            string response = openNebulaReturnArr.GetValue(1).ToString();
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(USER_POOL));
            using (MemoryStream s = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(response ?? ""))) {
                result = (USER_POOL)ser.Deserialize(s);
            }

            return result;
        }
            
        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <returns>The user info.</returns>
        /// <param name="id">Identifier.</param>
        public USER GetUserInfo(int id){
            USER result = null;
            string rootMainUserHash = this.AdminUsername+":"+this.AdminPassword;
            XmlRpcUserManagement xrum = XmlRpcProxyGen.Create<XmlRpcUserManagement>();
            Array openNebulaReturnArr = xrum.oneUserInfo(rootMainUserHash, id);

            string response = openNebulaReturnArr.GetValue(1).ToString();
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(USER));
            using (MemoryStream s = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(response ?? ""))) {
                result = (USER)ser.Deserialize(s);
            }

            return result;
        }

        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <returns>The user info.</returns>
        public USER GetUserInfo(){
            return GetUserInfo(-1);
        }

    }
}

